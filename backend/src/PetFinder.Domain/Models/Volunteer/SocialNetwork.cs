using System.Runtime.InteropServices.JavaScript;
using CSharpFunctionalExtensions;
using PetFinder.Domain.Shared;

namespace PetFinder.Domain.Models;

public record SocialNetwork
{
    private SocialNetwork()
    {
    }

    public string Title { get; private set; } = default!;
    public string Url { get; private set; } = default!;

    public static Result<SocialNetwork, Error> Create(string title, string url)
    {
        var validationResult = Validate(
            name: title,
            url: url);

        if (validationResult.IsFailure)
            return validationResult.Error;

        return new SocialNetwork()
        {
            Title = title,
            Url = url
        };
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