namespace CuallimexManagement.Entities
{
    public class ImageModel
    {
        public string? FileName { get; set; }
        public byte[] ImageData { get; set; }
        public string Base64Data => Convert.ToBase64String(ImageData);
    }
}
