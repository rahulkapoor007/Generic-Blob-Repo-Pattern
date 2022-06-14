using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureRepositories.Abstraction.Contracts
{
    public interface IBlobStorage
    {
        Task<string> UploadContentAsync(string ContainerId, string FileName, BinaryData Data, string contentType = null,
            IDictionary<string, string> metadata = null, IDictionary<string, string> tags = null, CancellationToken Token = default);
    }
}
