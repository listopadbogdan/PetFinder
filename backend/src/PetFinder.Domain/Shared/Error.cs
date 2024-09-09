namespace PetFinder.Domain.Shared;

public class Error
{
    public string Code { get; }
    public string Message { get; }
    public ErrorType ErrorType { get; }

    private Error(string code, string message, ErrorType errorType)
    {
        Code = code;
        Message = message;
        ErrorType = errorType;
    }
    
    public override string ToString()
        => $"Code: {Code}, Message: {Message}, ErrorType: {ErrorType}";
    
    public static  implicit operator string(Error error) => error.ToString();
    
    
    public static Error Empty(string code, string message)
        => new Error(code, message, ErrorType.Empty);

    public static Error Validation(string code, string message)
        => new Error(code, message, ErrorType.Validation);

    public static Error NotFound(string code, string message)
        => new Error(code, message, ErrorType.NotFound);

    public static Error Failure(string code, string message)
        => new Error(code, message, ErrorType.Failure);

    public static Error Conflict(string code, string message)
        => new Error(code, message, ErrorType.Conflict);

}

public enum ErrorType
{
    Empty,
    Validation,
    NotFound,
    Failure,
    Conflict
}