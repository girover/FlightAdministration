using FlightAdministration.Api.Response;
using System.Text.Json;

namespace FlightAdministration.Api.ErrorHandling;

public class ErrorHandlingMiddleware(RequestDelegate next) {

    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context) {
        try {
            await _next(context);
        } catch (Exception ex) {

            // Set the response status code
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            // Return a generic error response
            var response = new ApiResponse<string> {
                Type = "https://tools.ietf.org/html/rfc9110#section-15.5.1",
                Title = "Problem.",
                Status = 500,
                Ok = false,
                Errors = new Dictionary<string, string[]> {
                    { "message", new string[] { ex.Message } }
                }
            };


            // Serialize the error response to JSON
            var jsonResponse = JsonSerializer.Serialize(response);

            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
