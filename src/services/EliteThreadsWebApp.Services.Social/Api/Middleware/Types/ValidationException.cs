﻿namespace EliteThreadsWebApp.Services.Social.Api.Middleware.Types
{
    public class ValidationException : Exception
    {
        public IEnumerable<ValidationError> Errors { get; }

        public ValidationException(IEnumerable<ValidationError> errors)
            : base("One or more validation errors occurred.")
        {
            Errors = errors;
        }
    }
}
