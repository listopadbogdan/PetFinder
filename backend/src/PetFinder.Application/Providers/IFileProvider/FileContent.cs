namespace PetFinder.Application.Providers.IFileProvider;

public abstract record FileContent(Stream Stream, string FileName, string BucketName, IDictionary<string, string>? MetaData = null);