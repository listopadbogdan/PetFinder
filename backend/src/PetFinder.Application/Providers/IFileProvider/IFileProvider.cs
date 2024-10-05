using CSharpFunctionalExtensions;
using PetFinder.Domain.Shared;
using PetFinder.Domain.SharedKernel;

namespace PetFinder.Application.Providers.IFileProvider;

public interface IFileProvider
{
    Task<UnitResult<Error>> UploadFile(FileContent fileContent, CancellationToken cancellationToken);
    
    IAsyncEnumerable<UnitResult<Error>> UploadFiles(IEnumerable<FileContent> fileContents,
        CancellationToken cancellationToken);
    
    Task<UnitResult<Error>> RemoveFile(string fileName, string bucketName, CancellationToken cancellationToken);
    
    Task<Result<string, Error>> GetFile(string fileName, string bucketName, CancellationToken cancellationToken);
}

