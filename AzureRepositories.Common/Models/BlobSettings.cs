using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureRepositories.Common.Models
{
    public class BlobSettings
    {
        public string? ConnectionString { get; set; }
        public List<BlobNames>? BlobNames { get; set; }
    }
}
