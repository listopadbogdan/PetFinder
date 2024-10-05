namespace PetFinder.Infrastructure.Options;

public record MinioOptions
{
    public const string SectionName = "Minio";
    
    public string Endpoint { get; init; } = default!;
    public string AccessKey { get; init; } = default!;
    public string SecretKey { get; init; } = default!;
    public bool Ssl { get; init; }
}