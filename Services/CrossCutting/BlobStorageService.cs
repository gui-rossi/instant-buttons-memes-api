using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using Services.Interfaces;

namespace Services.CrossCutting
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly string m_connectionString;
        private string m_containerName => "instant-buttons-container";

        public BlobStorageService(IConfiguration configuration)
        {
            m_connectionString = configuration["ConnectionStrings:StorageAccountConnectionString"];
        }

        public async Task<List<Stream>> GetBlobStreamsAsync()
        {
            BlobContainerClient containerClient = new BlobContainerClient(m_connectionString, m_containerName);

            List<Stream> blobStreams = new List<Stream>();

            await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
            {
                BlobClient blobClient = containerClient.GetBlobClient(blobItem.Name);
                BlobDownloadInfo download = await blobClient.DownloadAsync();
                MemoryStream memoryStream = new MemoryStream();
                await download.Content.CopyToAsync(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);
                blobStreams.Add(memoryStream);
            }

            return blobStreams;
        }
    }

}
