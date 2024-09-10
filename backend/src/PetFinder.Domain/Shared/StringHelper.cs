namespace PetFinder.Domain.Shared;

public static class StringHelper
{
    /// <summary>
    /// Return string like "PROPERTY_NAME can not be empty or bigger then MAX_LENGTH " 
    /// </summary>
    /// <param name="valueName">Name of value</param>
    /// <param name="valueMaxLimit">Value </param>
    /// <returns></returns>
    public static string GetValueEmptyOrMoreThanNeedString(int valueMaxLimit)
        => $"can not be empty or more than {valueMaxLimit}";

    public static string GetValueMoreThanNeedString(int valueMaxLimit)
        => $"more than {valueMaxLimit}";
}