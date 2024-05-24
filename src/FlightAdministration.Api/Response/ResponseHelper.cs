using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FlightAdministration.Api.Response;

public static class ResponseHelper {

    public static IActionResult BadRequest<T>(T data, string message = "") {

        return new BadRequestObjectResult(new ApiResponse<T> {
            Type = "https://tools.ietf.org/html/rfc9110#section-15.5.1",
            Title = "Bad request.",
            Message = message,
            Status = 400,
            Ok = false,
            Errors = CreateErrorDictionary(data)
        });
    }

    public static IActionResult NotFound(string message = "") {

        return new NotFoundObjectResult(new ApiResponse<string> {
            Type = "https://tools.ietf.org/html/rfc9110#section-15.5.1",
            Title = "Not found.",
            Message = message,
            Status = 404,
            Ok = false,
            Errors = null
        });
    }

    public static IActionResult Error<T>(T data, string message = "") {

        return new ObjectResult(new ApiResponse<T> {
            Type = "https://tools.ietf.org/html/rfc9110#section-15.5.1",
            Title = "Internal server error.",
            Message = message,
            Status = 500,
            Ok = false,
            Errors = CreateErrorDictionary(data)
        });
    }

    public static IActionResult Ok<T>(T? data, string message = "") {
        return new ObjectResult(new ApiResponse<T> {
            Type = "https://tools.ietf.org/html/rfc9110#section-15.5.1",
            Title = "Success",
            Message = message,
            Status = 200,
            Ok = true,
            Data = data
        });
    }

    private static Dictionary<string, string[]> CreateErrorDictionary<T>(T data) {
        if (data.Equals(default(T))) {
            return null;
        } else {
            return new Dictionary<string, string[]>
            {
                { "message", new string[] { data.ToString() } }
            };
        }
    }
}

