namespace GenericBlobStorage.Models
{
    public class UploadContentResponse
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string OriginalFileName { get; set; }
        public string ContentType { get; set; }
        public string FileUrl { get; set; }
    }
}
