namespace FlightAdministration.Api.Response;

public class ApiResponse<T> {
    public string Type { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public int Status { get; set; }
    public bool Ok { get; set; }
    public T? Data { get; set; }
    public Dictionary<string, string[]>? Errors { get; set; }
}

