using CSharpFunctionalExtensions;
using PetFinder.Domain.Shared;
using PetFinder.Domain.SharedKernel;

namespace PetFinder.Domain.Volunteer.ValueObjects;

public record SocialNetwork
{
    private SocialNetwork()
    {
    }

    private SocialNetwork(string title, string url)
    {
        Title = title;
        Url = url;
    }

    public string Title { get; } = default!;
    public string Url { get; } = default!;

    public static Result<SocialNetwork, Error> Create(string title, string url)
    {
        var validationResult = Validate(
            name: title,
            url: url);

        if (validationResult.IsFailure)
            return validationResult.Error;

        return new SocialNetwork(
            title: title,
            url: url);
    }

    private static UnitResult<Error> Validate(string name, string url)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > Constants.SocialNetwork.MaxNameLength)
            return Errors.General.ValueIsInvalid(
                nameof(Title),
                StringHelper.GetValueEmptyOrMoreThanNeedString(Constants.SocialNetwork.MaxNameLength));

        if (string.IsNullOrWhiteSpace(url) || name.Length > Constants.SocialNetwork.MaxUrlLength)
            return Errors.General.ValueIsInvalid(
                nameof(Url),
                StringHelper.GetValueEmptyOrMoreThanNeedString(Constants.SocialNetwork.MaxUrlLength));

        return UnitResult.Success<Error>();
    }
}