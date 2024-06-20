using EliteThreadsWebApp.Services.Social.Api.Middleware.Types;
using EliteThreadsWebApp.Services.Social.Business.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace EliteThreadsWebApp.Services.Social.Api.Middleware
{
    public class GlobalErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (InvalidDataException e)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                context.Response.ContentType = "application/json";
                await context
                    .Response
                    .WriteAsync(
                        SerializeProblem.HandleException(
                            e,
                            "Not Found.",
                            StatusCodes.Status404NotFound
                        )
                    );
            }
            catch (Auth0.Core.Exceptions.ApiException e)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                context.Response.ContentType = "application/json";
                await context
                    .Response
                    .WriteAsync(
                        SerializeProblem.HandleException(
                            e,
                            "Not Found.",
                            StatusCodes.Status404NotFound
                        )
                    );
            }
            catch (ValidationException e)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "application/json";

                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status400BadRequest,
                    Type = "ValidationFailure",
                    Title = "Validation error",
                    Detail = "One or more validation errors has occurred"
                };

                if (e.Errors is not null)
                {
                    problemDetails.Extensions["errors"] = e.Errors;
                }

                await context.Response.WriteAsJsonAsync(problemDetails);
            }
            catch (Exception e)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                await context
                    .Response
                    .WriteAsync(
                        SerializeProblem.HandleException(
                            e,
                            "public Server Error",
                            StatusCodes.Status500InternalServerError
                        )
                    );
            }
        }
    }
}
