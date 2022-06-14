using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureRepositories.Common.Models
{
    public class BlobResources
    {
        public List<BlobSettings>? BlobSettings { get; set; }
    }
    public static class BlobOptions
    {
        public static BlobResources? Options;
    }
}
