using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using EliteThreadsWebApp.Services.ExternalApi.Helpers;
using EliteThreadsWebApp.Services.ExternalApi.Interfaces;
using Microsoft.Extensions.Options;

namespace EliteThreadsWebApp.Services.ExternalApi.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly  Cloudinary _cloudinary;

        public PhotoService(IOptions<CloudinarySettings> config)
        {
            var account = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
            );
            _cloudinary = new Cloudinary(account);
        }

        private async Task<ImageUploadResult> AddPhotoAsync(FormFile file)
        {
            var uploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream)
                };
                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }
            return uploadResult;
        }

        public async Task<string> CloudinaryUpload(byte[] bytes, string content)
        {
            if (bytes != null && bytes.Length > 0)
            {
                using var memoryStream = new MemoryStream(bytes);
                await memoryStream.WriteAsync(bytes);

                var convertedFile = new FormFile(
                    memoryStream,
                    0,
                    memoryStream.Length,
                    "file",
                    $"image-{Guid.NewGuid()}"
                )
                {
                    Headers = new HeaderDictionary(),
                    ContentType = content
                };

                var result = await AddPhotoAsync(convertedFile);
                return result?.Url.ToString() ?? "";
            }
            return string.Empty;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicUrl)
        {
            var publicId = publicUrl.Split('/').Last().Split('.')[0];
            var deleteParams = new DeletionParams(publicId);
            return await _cloudinary.DestroyAsync(deleteParams);
        }
    }
}
