namespace PetFinder.Domain.SharedKernel;

public static class Errors
{
    public static class General
    {
        public static Error ValueIsInvalid(string? valueName = default, string? description = default) =>
            Error.Validation(
                ErrorCodes.ValueIsInvalid,
                !string.IsNullOrWhiteSpace(description)
                    ? $"{valueName ?? "value"} is invalid - {description}"
                    : $"{valueName ?? "value"} is invalid");

        public static Error ValueIsRequired(string? valueName = default)
            => Error.Validation(ErrorCodes.ValueIsRequired, $"{valueName ?? "value"} is required");

        public static Error RecordNotFound(string? recordName = default, Guid? id = default)
            => Error.Validation(ErrorCodes.RecordNotFound, $"{recordName ?? "record"} by id {id} not found");

        public static Error RecordWithValueIsNotUnique<T>(string recordName, string valueName, T value)
            => Error.Failure(ErrorCodes.RecordIsExists, $"{recordName} with {valueName} = {value} already exists");
    }
}