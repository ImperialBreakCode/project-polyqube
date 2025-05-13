namespace API.FileStorage.Domain.Models
{
    public class FileObj
    {
        private FileObj() { }

        private FileObj(string objectName, string filePath, string contentType, string bucketName, byte[] content)
        {
            ObjectName = objectName;
            FilePath = filePath;
            ContentType = contentType;
            BucketName = bucketName;
            Content = content;
        }

        public string ObjectName { get; set; }
        public string FilePath { get; set; }
        public string ContentType { get; set; }
        public string BucketName { get; set; }
        public byte[] Content { get; set; }

        public static FileObj Create(string objectName, string filePath, string contentType, string bucketName, byte[] content)
        {
            return new FileObj(objectName, filePath, contentType, bucketName, content);
        }
    }
}
