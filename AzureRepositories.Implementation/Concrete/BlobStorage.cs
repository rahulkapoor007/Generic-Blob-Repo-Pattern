using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using AzureRepositories.Abstraction.Contracts;
using AzureRepositories.Common.Exceptions;
using AzureRepositories.Implementation.ContainerFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureRepositories.Implementation.Concrete
{
    public class BlobStorage : IBlobStorage
    {
        private readonly BlobContainerFactory _containerFactory;

        public BlobStorage(BlobContainerFactory containerFactory)
        {
            this._containerFactory = containerFactory;
        }
        public async Task<string> UploadContentAsync(string ContainerId, string FileName, BinaryData Data, string contentType = null,
            IDictionary<string, string> metadata = null, IDictionary<string, string> tags = null, CancellationToken Token = default)
        {
            try
            {
                BlobContainerClient container = _containerFactory.GetContainer(ContainerId);

                //Getting refernce of the Blob
                var blobClient = container.GetBlobClient(FileName);

                //Setting blob options
                BlobUploadOptions options = new();
                if (metadata != null)
                    options.Metadata = metadata;
                if (tags != null)
                    options.Tags = tags;

                BlobHttpHeaders headers = new();
                if (!string.IsNullOrEmpty(contentType))
                    headers.ContentType = contentType;

                options.HttpHeaders = headers;
                //Uploading content
                await blobClient.UploadAsync(Data, options, Token);

                return blobClient.Uri.ToString();
            }
            catch (Exception ex)
            {
                if (ex is ApplicationErrorException) throw;
                else throw new ApplicationErrorException(ex);
            }
        }

    }
}
