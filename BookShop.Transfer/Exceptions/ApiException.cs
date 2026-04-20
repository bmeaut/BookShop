namespace BookShop.Transfer.Exceptions;

public partial class ApiException(string message, int statusCode, string? response, IReadOnlyDictionary<string, IEnumerable<string>> headers, Exception innerException)
    : Exception($"{message}\n\nStatus: {statusCode} \nResponse: n {(response == null ? "(null)" : response[..Math.Min(response.Length, 512)])}", innerException)
{
    public int StatusCode { get; } = statusCode;

    public string? Response { get; } = response;

    public IReadOnlyDictionary<string, IEnumerable<string>> Headers { get; } = headers;

    public override string ToString()
        => $"HTTP Response: \n\n{Response}\n\n{base.ToString()}";
}

public partial class ApiException<TResult>(string message, int statusCode, string response, IReadOnlyDictionary<string, IEnumerable<string>> headers, TResult result, Exception innerException)
    : ApiException(message, statusCode, response, headers, innerException)
{
    public TResult Result { get; } = result;
}