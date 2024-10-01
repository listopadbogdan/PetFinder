using System.Text.Json;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetFinder.Domain.Shared.ValueObjects;

namespace PetFinder.Infrastructure.Extensions;

public static class PropertyBuilderExtensions
{
    public static PropertyBuilder<ValueObjectList<T>> HasDefaultConversionForValueObjectList<T>(
        this PropertyBuilder<ValueObjectList<T>> propertyBuilder) =>
        propertyBuilder.HasConversion<string>(
            list => JsonSerializer.Serialize(list, JsonSerializerOptions.Default),
            json => new ValueObjectList<T>(JsonSerializer
                .Deserialize<List<T>>(json, JsonSerializerOptions.Default)!),
            CreateValueObjectListComparer<T>());
    
    public static PropertyBuilder<ValueObjectList<T>> HasDefaultConversionForValueObjectList<TDto, T>(
        this PropertyBuilder<ValueObjectList<T>> propertyBuilder, 
        Func<TDto, T> valueObjectSelector) =>
        propertyBuilder.HasConversion<string>(
            list => JsonSerializer.Serialize(list, JsonSerializerOptions.Default),
            json => new ValueObjectList<T>(JsonSerializer
                .Deserialize<List<TDto>>(json, JsonSerializerOptions.Default)!.Select(dto => valueObjectSelector(dto)!)),
            CreateValueObjectListComparer<T>());

    private static ValueComparer<ValueObjectList<T>> CreateValueObjectListComparer<T>() =>
        new(
            (left, right) => left!.SequenceEqual(right!),
            list => list.Aggregate(0, (accumulator, currentValue)
                => HashCode.Combine(accumulator, currentValue!.GetHashCode())),
            list => list);
}