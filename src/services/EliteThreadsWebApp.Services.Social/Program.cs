using System.Net.Http.Headers;
using System.Reflection;
using Asp.Versioning;
using Asp.Versioning.Builder;
using EliteThreadsWebApp.Services.Social.Api.Endpoints;
using EliteThreadsWebApp.Services.Social.Api.Middleware;
using EliteThreadsWebApp.Services.Social.Business.Helpers;
using EliteThreadsWebApp.Services.Social.Business.Interfaces;
using EliteThreadsWebApp.Services.Social.Business.Services;
using EliteThreadsWebApp.Services.Social.Infrastructure;
using EliteThreadsWebApp.Services.Social.Infrastructure.Interface;
using EliteThreadsWebApp.Services.Social.Infrastructure.Repositories;
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
    .AddHttpClient(
        "Auth0ApiClient",
        client =>
        {
            client.BaseAddress = new Uri($"https://{builder.Configuration["Auth0:Domain"]}");
            client.DefaultRequestHeaders.Accept.Clear();
            client
                .DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    );
builder
    .Services
    .AddMassTransit(busConfigurator =>
    {
        busConfigurator.SetKebabCaseEndpointNameFormatter();
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
builder.Services.Configure<Auth0Settings>(builder.Configuration.GetSection("Auth0"));
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder
    .Services
    .AddMediatR(cfg =>
    {
        cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
        cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
    });

builder.Services.AddScoped<IAuth0ManagementService, Auth0ManagementService>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IUserWishlistRepository, UserWishlistRepository>();
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
versionedGroup.ConfigureReviewEndpoints();
versionedGroup.ConfigureUserEndpoints();

app.Run();
