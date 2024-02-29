using CuallimexManagement.Entities;
using CuallimexManagement.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;
using System.Buffers.Text;

namespace CuallimexManagement.Components
{
    public partial class UploadImagesWithComments : ComponentBase
    {
        [Parameter] public string? Text { get; set; }
        [Parameter] public List<string> OptionsList { get; set; }
        [Parameter] public string? Comments { get; set; }
        [Parameter] public string? Label { get; set; }
        [Parameter] public List<string>? Images { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            if (Images == null)
            {
                Images = new();
            }
        }
        private async void UploadFiles(IBrowserFile file)
        {
            var image = await GetFileBytesAsync(file);
            if (image != null || image.Length > 0)
            {
                Images.Add(Convert.ToBase64String(image));
                StateHasChanged();
            }
        }

        async Task<byte[]> GetFileBytesAsync(IBrowserFile file)
        {
            if (file.Size > 10485760)
            {
                Snackbar.Add($"El archivo {file.Name} excede el tamaño permitido (10MB).", Severity.Error);
                return new byte[] { };
            }
            else
            {
                //  using var memoryStream = new MemoryStream();

                //  await file.OpenReadStream(ImageUtil.MAX_IMAGE_SIZE).CopyToAsync(memoryStream);

                return await ImageUtil.CompressImage(file, 800, 800);
            }

        }
    }
}
