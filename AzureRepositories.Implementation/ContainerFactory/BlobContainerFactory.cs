using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using AzureRepositories.Common.Models;

namespace AzureRepositories.Implementation.ContainerFactory
{
    public class BlobContainerFactory
    {
        private readonly BlobResources _resources;
        List<(string containerId, string containerName, string connectionString)> _containers;
        private IDictionary<string, BlobContainerClient> _clients;
        public BlobContainerFactory(BlobResources resources)
        {
            this._resources = resources ?? throw new ArgumentNullException(nameof(resources));
            this._containers = new List<(string containerId, string containerName, string connectionString)>();
            this._clients = new Dictionary<string, BlobContainerClient>();
            SetContainers();
        }
        private void SetContainers()
        {
            if (_resources.BlobSettings == null) return;
            foreach (var settings in _resources.BlobSettings)
            {
                if (settings.BlobNames == null) continue;
                foreach (var names in settings.BlobNames)
                {
                    if (names == null || names.BlobId==null ||
                    names.BlobName == null || settings.ConnectionString == null) 
                        continue;

                    _containers.Add((names.BlobId, names.BlobName, settings.ConnectionString));
                }
            }
        }
        public BlobContainerClient GetContainer(string containerName)
        {
            var serviceClients = _containers.Where(x => x.containerId.Equals(containerName))?.FirstOrDefault();

            if (serviceClients == null)
            {
                throw new ArgumentException($"Unable to find container: {containerName}");
            }
            if (_clients.ContainsKey(containerName))
                return _clients[containerName];
            var client = serviceClients.GetValueOrDefault();
            BlobContainerClient container = new BlobContainerClient(client.connectionString, client.containerName);
            container.CreateIfNotExistsAsync(PublicAccessType.BlobContainer);
            _clients.Add(client.containerId, container);
            return container;
        }
    }
}
