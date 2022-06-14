using AzureRepositories.Abstraction.Contracts;
using GenericBlobStorage.Enums;
using GenericBlobStorage.Extensions;
using GenericBlobStorage.IServices;
using GenericBlobStorage.Models;

namespace GenericBlobStorage.Services
{
    public class UploadService : IUploadService
    {
        private readonly IBlobStorage _blobStorage;
        public UploadService(IBlobStorage blobStorage)
        {
            this._blobStorage = blobStorage;
        }
        public async Task<UploadContentResponse> UploadContent(UploadContentRequest request, CancellationToken Token)
        {
            try
            {
                UploadContentResponse response = new UploadContentResponse();
                string Id = Guid.NewGuid().ToString();

                string originalFileName = string.Empty;
                try { originalFileName = Path.GetFileName(request.File.FileName); } catch (Exception) { originalFileName = request.FileName; }

                string imageName = Id + "_" + originalFileName;
                string imagePath = DateTime.Now.ToString("yyyyMMdd") + "/" + imageName;
                string contentType = request.File.ContentType;

                BinaryData data;

                using (var mso = new MemoryStream())
                {
                    request.File.CopyTo(mso);
                    byte[] FileBytes = mso.ToArray();
                    data = BinaryData.FromBytes(FileBytes);
                }

                //Adding Meta Data
                IDictionary<string, string> metaData = new Dictionary<string, string>
                {
                    { "CreatedDateTime", DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss") },
                    { "CcontentType", contentType }
                };

                //Adding Tags
                IDictionary<string, string> tags = new Dictionary<string, string>
                {
                    { "CreatedDateTime", DateTime.UtcNow.ToString("dd-MM-yyyy HH-mm-ss") },
                    { "ContentType", contentType }
                };

                

                var result = await _blobStorage.UploadContentAsync(BlobIds.Content.GetEnumDescription(),
                            imagePath, data, contentType, metaData, tags, Token);

                response.Id = Id;
                response.OriginalFileName = originalFileName;
                response.FileName = imageName;
                response.FilePath = (new Uri(result))?.AbsolutePath;
                response.ContentType = contentType;
                response.FileUrl = result;

                return response;
            }
            catch(Exception)
            {
                throw;
            }
                
        }
    }
}
