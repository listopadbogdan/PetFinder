using CSharpFunctionalExtensions;
using PetFinder.Domain.Shared;

namespace PetFinder.Domain.Models;

public record SocialNetwork
{
    private SocialNetwork()
    {
    }

    public string Name { get; private set; } = default!;
    public string Url { get; private set; } = default!;

    public Result<SocialNetwork> Create(string name, string url)
    {
        var validationResult = Validate(
            name: name,
            url: url);

        if (validationResult.IsFailure)
            return Result.Failure<SocialNetwork>(validationResult.Error);

        return Result.Success(new SocialNetwork()
        {
            Name = name,
            Url = url
        });
    }

    private static Result Validate(string name, string url)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > Constants.SocialNetwork.MaxNameLength)
            return NameValidationFailureResult;

        if (string.IsNullOrWhiteSpace(url) || name.Length > Constants.SocialNetwork.MaxUrlLength)
            return UrlValidationFailureResult;

        return Constants.ValueObject.SuccessValidationResult;
    }

    private static readonly Result NameValidationFailureResult = Result.Failure(
        StringHelper.GetValueEmptyOrMoreThanNeedString(
            valueName: nameof(Name),
            valueMaxLimit: Constants.SocialNetwork.MaxNameLength));

    private static readonly Result UrlValidationFailureResult = Result.Failure(
        StringHelper.GetValueEmptyOrMoreThanNeedString(
            valueName: nameof(Url),
            valueMaxLimit: Constants.SocialNetwork.MaxUrlLength));
}