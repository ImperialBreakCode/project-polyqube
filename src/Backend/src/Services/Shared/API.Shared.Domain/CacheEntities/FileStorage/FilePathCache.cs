namespace API.Shared.Domain.CacheEntities.FileStorage
{
    public class FilePathCache
    {
        private FilePathCache() {}

        private FilePathCache(string filePath, string presignedUrl)
        {
            FilePath = filePath;
            PresignedUrl = presignedUrl;
        }

        public string FilePath { get; set; }
        public string PresignedUrl { get; set; }

        public static FilePathCache Create(string filePath, string presignedUrl)
        {
            return new FilePathCache(filePath, presignedUrl);
        }
    }
}
