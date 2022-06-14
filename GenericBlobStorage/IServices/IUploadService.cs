using GenericBlobStorage.Models;

namespace GenericBlobStorage.IServices
{
    public interface IUploadService
    {
        Task<UploadContentResponse> UploadContent(UploadContentRequest request, CancellationToken Token);
    }
}
