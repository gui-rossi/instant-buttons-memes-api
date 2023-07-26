using Azure;
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

        public async Task<MemoryStream> GetBlobStreamAsync(string fileName)
        {
            BlobContainerClient containerClient = new BlobContainerClient(m_connectionString, m_containerName);

            try
            {
                BlobClient blobClient = containerClient.GetBlobClient(fileName);
                BlobDownloadInfo download = await blobClient.DownloadAsync();

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    await download.Content.CopyToAsync(memoryStream);
                    memoryStream.Seek(0, SeekOrigin.Begin);

                    return memoryStream;
                }
            }
            catch (RequestFailedException ex)
            {
                if (ex.Status == 404)
                {
                    // The file with the specified name was not found.
                    // Handle this case appropriately (e.g., return null, throw an exception, etc.).
                    return null;
                }
                else
                {
                    // Handle other exceptions, such as authentication errors, etc.
                    // You might want to throw an exception or log the error.
                    throw ex;
                }
            }
        }
    }

}
