﻿namespace EliteThreadsWebApp.Services.ExternalApi.Middleware.Types
{
    public class ValidationError(string propertyName, string errorMessage)
    {
        public string PropertyName { get; private set; } = propertyName;
        public string ErrorMessage { get; private set; } = errorMessage;
    }
}
