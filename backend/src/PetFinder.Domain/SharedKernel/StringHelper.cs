namespace PetFinder.Domain.SharedKernel;

public static class StringHelper
{
    /// <summary>
    /// Return string like "PROPERTY_NAME can not be empty or bigger than MAX_LENGTH " 
    /// </summary>
    /// <param name="valueName">Name of value</param>
    /// <param name="valueMaxLimit">Value </param>
    /// <returns></returns>
    public static string GetValueEmptyOrMoreThanNeedString(int valueMaxLimit)
        => $"can not be empty or more than {valueMaxLimit}";

    public static string GetValueMoreThanNeedString<T>(T valueMaxLimit)
        => $"more than {valueMaxLimit}";

    public static string GetValueLessThanNeedString<T>(T valueMinLimit)
        => $"less then need";
}