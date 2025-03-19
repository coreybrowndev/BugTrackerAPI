using System.Text.Json;

namespace BugTracker.Api.Middleware.ExceptionConfig;    


public class ExceptionDetailsConfiguration 
{
    public string ErrorType { get; set; } = string.Empty;
    public string ErrorMessage { get; set; } = string.Empty;
    public int StatusCode { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }

}