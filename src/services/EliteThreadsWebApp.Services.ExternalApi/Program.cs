using System.Net.Http.Headers;
using System.Reflection;
using Asp.Versioning;
using Asp.Versioning.Builder;
using EliteThreadsWebApp.Services.ExternalApi.Commands;
using EliteThreadsWebApp.Services.ExternalApi.DTO;
using EliteThreadsWebApp.Services.ExternalApi.Helpers;
using EliteThreadsWebApp.Services.ExternalApi.Interfaces;
using EliteThreadsWebApp.Services.ExternalApi.Queries;
using EliteThreadsWebApp.Services.ExternalApi.Services;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        "IpApiClient",
        options =>
        {
            options.BaseAddress = new Uri(builder.Configuration["IpApiUrl"]);
        }
    );
builder
    .Services
    .AddHttpClient(
        "GeolocationApiClient",
        options =>
        {
            options.BaseAddress = new Uri(builder.Configuration["GeolocationApiUrl"]);
        }
    );
builder
    .Services
    .AddHttpClient(
        "CountryCityStateApiClient",
        options =>
        {
            options.BaseAddress = new Uri(builder.Configuration["CountryCityStateApi:Url"]);
            options
                .DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            options
                .DefaultRequestHeaders
                .Add("user-email", builder.Configuration["CountryCityStateApi:Email"]);
            options
                .DefaultRequestHeaders
                .Add("api-token", builder.Configuration["CountryCityStateApi:Token"]);
        }
    );
builder.Services.AddValidatorsFromAssembly(typeof(UploadPhotoCommandValidator).Assembly);
builder
    .Services
    .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder
    .Services
    .Configure<CloudinarySettings>(builder.Configuration.GetSection(nameof(CloudinarySettings)));
builder.Services.AddSingleton<IPhotoService, PhotoService>();
builder.Services.AddScoped<IGeolocationService, GeolocationService>();
builder.Services.AddScoped<ICountryCityStateService, CountryCityStateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

ApiVersionSet apiVersionSet = app.NewApiVersionSet()
    .HasApiVersion(new ApiVersion(1))
    .ReportApiVersions()
    .Build();
RouteGroupBuilder versionedGroup = app.MapGroup("/api/v{apiVersion:apiVersion}")
    .WithApiVersionSet(apiVersionSet);

versionedGroup
    .MapGet(
        "/geolocation",
        async (ISender sender) => Results.Ok(await sender.Send(new GetUserGeolocationQuery()))
    )
    .Produces<GeolocationDTO>(200);

versionedGroup
    .MapGet(
        "/countries",
        async (ISender sender) => Results.Ok(await sender.Send(new GetCountriesQuery()))
    )
    .Produces<IEnumerable<CountryDTO>>(200);
versionedGroup
    .MapGet(
        "/states/{country}",
        async (ISender sender, [FromRoute] string country) =>
            Results.Ok(await sender.Send(new GetStatesQuery { Country = country }))
    )
    .Produces<IEnumerable<StateDTO>>(200);
versionedGroup
    .MapGet(
        "/cities/{state}",
        async (ISender sender, [FromRoute] string state) =>
            Results.Ok(await sender.Send(new GetCitiesQuery { State = state }))
    )
    .Produces<IEnumerable<CityDTO>>(200);
versionedGroup
    .MapPost(
        "/image-upload",
        async (ISender sender, [FromBody] ImagesDTO dto) =>
            Results.Ok(await sender.Send(new UploadPhotoCommand { ImagesDTO = dto }))
    )
    .Accepts<ImagesDTO>("application/json")
    .Produces<string>(201);

app.Run();
