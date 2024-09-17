using PetFinder.Domain.Shared;

namespace PetFinder.Domain.SharedKernel;

public class Error
{
    // ReSharper disable once InconsistentNaming
    private const string Separator = "|";

    private Error(
        string code,
        string message,
        ErrorType errorType,
        string? invalidField = null)
    {
        Code = code;
        Message = message;
        ErrorType = errorType;
        InvalidField = invalidField;
    }

    public string Code { get; }
    public string Message { get; }
    public ErrorType ErrorType { get; }
    public string? InvalidField { get; }

    public override string ToString()
    {
        return $"Code: {Code}, Message: {Message}, ErrorType: {ErrorType}";
    }

    public static implicit operator string(Error error) => error.ToString();

    public static Error Empty(string code, string message, string? invalidField = null) => new(code, message, ErrorType.Empty, invalidField);

    public static Error Validation(string code, string message, string? invalidField = null) => new(code, message, ErrorType.Validation);

    public static Error NotFound(string code, string message, string? invalidField = null) => new(code, message, ErrorType.NotFound);

    public static Error Failure(string code, string message, string? invalidField = null)
    {
        return new Error(code, message, ErrorType.Failure);
    }

    public static Error Conflict(string code, string message, string? invalidField = null)
    {
        return new Error(code, message, ErrorType.Conflict);
    }

    public string Serialize()
    {
        return string.Join(Separator, Code, Message, ErrorType);
    }

    public static Error Deserialize(string serialized)
    {
        var parts = serialized.Split(Separator);
        if (parts.Length < 2)
            throw new InvalidOperationException("invalid serialize format");

        if (Enum.TryParse<ErrorType>(parts[2], out var type) == false)
            throw new InvalidOperationException("invalid error type format");

        return new Error(parts[0], parts[1], type);
    }

    public ErrorList ToErrorList()
    {
        return new ErrorList([this]);
    }
}

public enum ErrorType
{
    Empty,
    Validation,
    NotFound,
    Failure,
    Conflict
}