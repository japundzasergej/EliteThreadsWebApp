using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
var angular = builder.Configuration["Angular"];
var domain = builder.Configuration["Auth0:Domain"];
builder
    .Services
    .AddCors(options =>
    {
        options.AddPolicy(
            "AllowSpecificOrigin",
            builder =>
            {
                builder.WithOrigins(angular).AllowAnyHeader().AllowAnyMethod();
            }
        );
    });
builder
    .Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = domain;
        options.Audience = builder.Configuration["Auth0:Audience"];
        options.TokenValidationParameters = new TokenValidationParameters
        {
            NameClaimType = ClaimTypes.NameIdentifier
        };
        options.Events = new JwtBearerEvents
        {
            OnChallenge = context =>
            {
                context.HandleResponse();
                context.Response.StatusCode = 401;
                context.Response.ContentType = "text/plain";
                return context.Response.WriteAsync("Unauthorized");
            }
        };
    });
builder
    .Services
    .AddAuthorizationBuilder()
    .AddPolicy(
        "AdminPolicy",
        policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireAssertion(
                context =>
                    context
                        .User
                        .HasClaim(
                            c => c.Type == "userRoles" && c.Value.Split(',').Contains("Admin")
                        )
            );
        }
    );
builder.Services.AddOcelot();
var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("AllowSpecificOrigin");
await app.UseOcelot();

app.Run();
