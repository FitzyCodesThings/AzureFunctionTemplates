using Business.Interfaces;
using Business.Options;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.Storage.Queue;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class AzureStorageService : IAzureStorageService
    {
        private readonly IOptions<AzureStorageOptions> options;

        private CloudStorageAccount storageAccount;

        public AzureStorageService(IOptions<AzureStorageOptions> options)
        {
            this.options = options;
            this.storageAccount = CloudStorageAccount.Parse(options.Value.ConnectionString);
        }

        public async Task EnqueueMessage(string queueName, string content)
        {
            try
            {
                var q = this.GetQueue(queueName);

                await q.CreateIfNotExistsAsync();

                var message = new CloudQueueMessage(content);

                await q.AddMessageAsync(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UploadFileFromStreamAsync(string containerName, string blobName, Stream stream)
        {
            var container = this.GetBlobContainer(containerName);

            await container.CreateIfNotExistsAsync();

            var blob = container.GetBlockBlobReference(blobName);

            try
            {
                stream.Seek(0, SeekOrigin.Begin);

                await blob.UploadFromStreamAsync(stream);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<MemoryStream> GetFileAsMemoryStreamAsync(string containerName, string blobName)
        {
            try
            {
                var container = this.GetBlobContainer(containerName);

                var blob = container.GetBlockBlobReference(blobName);

                MemoryStream memStream = new MemoryStream();

                await blob.DownloadToStreamAsync(memStream);

                memStream.Seek(0, SeekOrigin.Begin);

                return memStream;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteFileAsync(string containerName, string blobName)
        {
            try
            {
                var container = this.GetBlobContainer(containerName);

                await container.CreateIfNotExistsAsync();

                var blob = container.GetBlockBlobReference(blobName);

                bool success = await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots, null, null, null);

                return success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private CloudQueueClient CreateQueueClient() => storageAccount.CreateCloudQueueClient();

        private CloudQueue GetQueue(string queueName) => this.CreateQueueClient().GetQueueReference(queueName);

        private CloudBlobClient CreateBlobClient() => storageAccount.CreateCloudBlobClient();

        private CloudBlobContainer GetBlobContainer(string containerName) => this.CreateBlobClient().GetContainerReference(containerName);
    }

}
