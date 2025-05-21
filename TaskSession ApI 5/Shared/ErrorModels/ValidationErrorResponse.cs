namespace Shared.ErrorModels;

public class ValidationErrorResponse
{
    public int StatusCode { get; set; }
    public string ErorrMessage { get; set; }
    public IEnumerable<ValidationErrors> Errors { get; set; }
}

public class ValidationErrors
{
    public string Field { get; set; }
    public IEnumerable<string> Errors { get; set; }
}