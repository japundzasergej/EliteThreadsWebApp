using System.Reflection;
using EliteThreadsWebApp.Services.Emailing.SendGrid;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder
    .Services
    .AddHttpClient(
        "AuthClient",
        options =>
        {
            options.BaseAddress = new Uri(builder.Configuration["ApiUrl"]);
        }
    );
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
builder.Services.Configure<SendGridSettings>(builder.Configuration.GetSection("Sendgrid"));
builder.Services.AddScoped<ISendGridService, SendGridService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
