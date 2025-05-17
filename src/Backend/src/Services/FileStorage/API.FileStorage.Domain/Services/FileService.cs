using API.FileStorage.Common.Constants;
using API.FileStorage.Domain.Models;
using Minio;
using Minio.DataModel.Args;

namespace API.FileStorage.Domain.Services
{
    public class FileService
    {
        private readonly IMinioClient _minioClient;

        public FileService(IMinioClient minioClient)
        {
            _minioClient = minioClient;
        }

        public async Task UploadFile(FileObj fileObj)
        {
            var beArgs = new BucketExistsArgs()
                    .WithBucket(fileObj.BucketName);

            var bucketExists = await _minioClient.BucketExistsAsync(beArgs);
            if (!bucketExists)
            {
                var mbArgs = new MakeBucketArgs()
                    .WithBucket(fileObj.BucketName);
                await _minioClient.MakeBucketAsync(mbArgs);
            }
            
            await _minioClient.PutObjectAsync(new PutObjectArgs()
                .WithBucket(fileObj.BucketName)
                .WithObject(fileObj.ObjectName)
                .WithStreamData(fileObj.Content)
                .WithObjectSize(fileObj.Content.Length)
                .WithContentType(fileObj.ContentType));
        }

        public async Task DeleteFile(string filePath, string bucketName)
        {
            await _minioClient.RemoveObjectAsync(new RemoveObjectArgs()
                .WithBucket(bucketName)
                .WithObject(filePath));
        }

        public async Task<string> GetPresignedUrlAsync(string bucketName, string fileName, int expirySeconds = MinioConstants.DefaultUrlExpirySeconds)
        {
            return await _minioClient.PresignedGetObjectAsync(new PresignedGetObjectArgs()
                .WithBucket(bucketName)
                .WithObject(fileName)
                .WithExpiry(expirySeconds));
        }
    }
}
