using System.Net.Http.Headers;
using System.Reflection;
using Asp.Versioning;
using Asp.Versioning.Builder;
using EliteThreadsWebApp.Services.Products.Api;
using EliteThreadsWebApp.Services.Products.Api.Middleware;
using EliteThreadsWebApp.Services.Products.Business;
using EliteThreadsWebApp.Services.Products.Business.Mapper;
using EliteThreadsWebApp.Services.Products.Business.MessagingConsumers;
using EliteThreadsWebApp.Services.Products.Infrastructure;
using EliteThreadsWebApp.Services.Products.Infrastructure.Repository;
using FluentValidation;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<GlobalErrorHandlingMiddleware>();
builder
    .Services
    .AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1);
        options.ApiVersionReader = new UrlSegmentApiVersionReader();
    })
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'V";
        options.SubstituteApiVersionInUrl = true;
    });
builder
    .Services
    .AddMassTransit(busConfigurator =>
    {
        busConfigurator.SetKebabCaseEndpointNameFormatter();
        busConfigurator.AddConsumers(Assembly.GetExecutingAssembly());
        busConfigurator.UsingRabbitMq(
            (context, configurator) =>
            {
                configurator.Host(
                    builder.Configuration["RabbitMq:Host"],
                    "/",
                    h =>
                    {
                        h.Username(builder.Configuration["RabbitMq:Username"]);
                        h.Password(builder.Configuration["RabbitMq:Password"]);
                    }
                );
                configurator.ConfigureEndpoints(context);
            }
        );
    });
builder
    .Services
    .AddHttpClient(
        "SocialApiClient",
        client =>
        {
            client.BaseAddress = new Uri(builder.Configuration["SocialApiUrl"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client
                .DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    );
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder
    .Services
    .AddMediatR(cfg =>
    {
        cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
        cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
    });
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder
    .Services
    .AddDbContext<ApplicationDbContext>(
        options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalErrorHandlingMiddleware>();
app.UseHttpsRedirection();
ApiVersionSet apiVersionSet = app.NewApiVersionSet()
    .HasApiVersion(new ApiVersion(1))
    .ReportApiVersions()
    .Build();
RouteGroupBuilder versionedGroup = app.MapGroup("/api/v{apiVersion:apiVersion}")
    .WithApiVersionSet(apiVersionSet);
versionedGroup.ConfigureProductEndpoints();

app.Run();
