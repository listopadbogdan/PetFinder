namespace PetFinder.Domain.Shared;

public static class StringHelper
{
    /// <summary>
    /// Return string like "PROPERTY_NAME can not be empty or bigger then MAX_LENGTH " 
    /// </summary>
    /// <param name="valueName">Name of value</param>
    /// <param name="valueMaxLimit">Value </param>
    /// <returns></returns>
    public static string GetValueEmptyOrMoreThanNeedString(string valueName, int valueMaxLimit)
        => $"{valueName} can not be empty or more than {valueMaxLimit}";

    public static string GetValueMoreThanNeedString(string valueName, int valueMaxLimit)
        => $"{valueName} more than {valueMaxLimit}";
}