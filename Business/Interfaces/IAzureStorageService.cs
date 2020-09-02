using System.IO;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IAzureStorageService
    {
        Task<bool> DeleteFileAsync(string containerName, string blobName);
        Task EnqueueMessage(string queueName, string content);
        Task<MemoryStream> GetFileAsMemoryStreamAsync(string containerName, string blobName);
        Task<bool> UploadFileFromStreamAsync(string containerName, string blobName, Stream stream);
    }
}