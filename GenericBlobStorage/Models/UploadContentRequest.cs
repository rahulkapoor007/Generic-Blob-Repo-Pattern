namespace GenericBlobStorage.Models
{
    public class UploadContentRequest
    {
        public string FileName { get; set; }
        public IFormFile File { get; set; }
    }
}
