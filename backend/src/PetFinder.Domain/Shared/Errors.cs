namespace PetFinder.Domain.Shared;

public static class Errors
{
    public static class General
    {
        public static Error ValueIsInvalid(string? valueName = null, string? description = null)
        {
            if (string.IsNullOrWhiteSpace(description))
                return Error.Validation(
                    ErrorCodes.ValueIsInvalid,
                    $"{valueName ?? "value"} is invalid - {description}"); 
            
            return Error.Validation(ErrorCodes.ValueIsInvalid, $"{valueName ?? "value"} is invalid");
        }

        public static Error ValueIsRequired(string? valueName = null)
            => Error.Validation(ErrorCodes.ValueIsRequired, $"{valueName ?? "value"} is required");

        public static Error RecordNotFould(string? recordName = null, Guid? id = null)
            => Error.Validation(ErrorCodes.RecordNotFound, $"{recordName ?? "record"} by id {id} not found");
    }
}