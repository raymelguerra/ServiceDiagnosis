using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Processing.Processors.Transforms;

namespace CuallimexManagement.Utils
{
    public class ImageUtil
    {
        public static long MAX_IMAGE_SIZE = 10 * 1024 * 1024; // 500 KB (in bytes)
        public static int MAX_WIDTH = 800; // Maximum width
        public static int MAX_HEIGTH = 600; // Maximum height
        public static async Task<byte[]> CompressImage(IBrowserFile file, int maxWidth, int maxHeight)
        {
            // Check file size
            if (file.Size > MAX_IMAGE_SIZE)
            {
                throw new ArgumentException("File size exceeds the maximum allowed size.");
            }

            using var memoryStream = new MemoryStream();
            await file.OpenReadStream(MAX_IMAGE_SIZE).CopyToAsync(memoryStream);

            using var image = Image.Load(memoryStream.ToArray());

            // Resize the image
            image.Mutate(x => x
                .Resize(new ResizeOptions
                {
                    Mode = ResizeMode.Max,
                    Size = new Size(maxWidth, maxHeight)
                }));

            using var outputStream = new MemoryStream();
            image.Save(outputStream, new SixLabors.ImageSharp.Formats.Jpeg.JpegEncoder
            {
                Quality = 100 // Adjust quality (0-100)
            }) ;

            return outputStream.ToArray();
        }
    }
}
