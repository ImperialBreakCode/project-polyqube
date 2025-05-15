namespace API.FileStorage.Domain.Models
{
    public class FileObj
    {
        private FileObj() { }

        private FileObj(string objectName, string contentType, string bucketName, Stream content)
        {
            ObjectName = objectName;
            ContentType = contentType;
            BucketName = bucketName;
            Content = content;
        }

        public string ObjectName { get; set; }
        public string ContentType { get; set; }
        public string BucketName { get; set; }
        public Stream Content { get; set; }

        public static FileObj Create(string objectName, string contentType, string bucketName, Stream content)
        {
            return new FileObj(objectName, contentType, bucketName, content);
        }
    }
}
