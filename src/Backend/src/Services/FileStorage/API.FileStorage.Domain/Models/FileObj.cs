namespace API.FileStorage.Domain.Models
{
    public class FileObj
    {
        public string ObjectName { get; set; }
        public string FilePath { get; set; }
        public string ContentType { get; set; }
        public string BucketName { get; set; }
        public byte[] Content { get; set; }
    }
}
