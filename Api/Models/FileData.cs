namespace Api.Models
{
    public class FileData
    {
        public string? Extension { get; set; }
        public IFormFile? File { get; set; }
        public byte[]? Bytes { get; set; }
    }
}
