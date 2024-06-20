using System.Reflection;
using Asp.Versioning;
using Asp.Versioning.Builder;
using EliteThreadsWebApp.Services.Payment.Business.DTO;
using EliteThreadsWebApp.Services.Payment.Stripe;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder
    .Services
    .AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1);
        options.ReportApiVersions = true;
        options.ApiVersionReader = new UrlSegmentApiVersionReader();
    })
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'V";
        options.SubstituteApiVersionInUrl = true;
    });
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));
builder.Services.AddScoped<IStripeService, StripeService>();
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

ApiVersionSet apiVersionSet = app.NewApiVersionSet()
    .HasApiVersion(new ApiVersion(1))
    .ReportApiVersions()
    .Build();

app.MapPost(
        "/api/v{apiVersion:apiVersion}/checkout",
        async (IStripeService stripeService, [FromBody] OrderDTO dto) =>
            Results.Ok(await stripeService.Checkout(dto))
    )
    .WithApiVersionSet(apiVersionSet)
    .Accepts<OrderDTO>("application/json")
    .Produces<StripeCheckoutResponse>(201);

app.MapGet(
    "/checkout/success",
    async (
        IStripeService stripeService,
        [FromQuery] string orderHeaderId,
        [FromQuery] string sessionId
    ) =>
    {
        var result = await stripeService.HandleSuccess(orderHeaderId);
        if (result)
        {
            var sessionService = new SessionService();
            var session = sessionService.Get(sessionId);
            return Results.Redirect(
                $"{builder.Configuration["Stripe:ClientUrl"]}/payment-successful?orderHeaderId={orderHeaderId}&total={session.AmountTotal.Value / 100}"
            );
        }
        else
        {
            return Results.BadRequest();
        }
    }
);

app.Run();
