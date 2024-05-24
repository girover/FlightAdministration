namespace FlightAdministration.Api.ErrorHandling;

public static class ErrorHandlingMiddlewareExtensions {
    public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder builder) {
        
        return builder.UseMiddleware<ErrorHandlingMiddleware>();
    }
}
