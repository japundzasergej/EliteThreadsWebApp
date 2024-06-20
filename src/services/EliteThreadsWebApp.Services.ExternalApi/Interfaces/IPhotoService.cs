using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace EliteThreadsWebApp.Services.ExternalApi.Interfaces
{
    public interface IPhotoService
    {
        Task<DeletionResult> DeletePhotoAsync(string publicUrl);
        Task<string> CloudinaryUpload(byte[] bytes, string content);
    }
}
