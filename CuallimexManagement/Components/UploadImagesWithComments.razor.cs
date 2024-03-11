using CuallimexManagement.Entities;
using CuallimexManagement.Utils;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Processing;
using System.Buffers.Text;
using static MongoDB.Driver.WriteConcern;

namespace CuallimexManagement.Components
{
    public partial class UploadImagesWithComments : ComponentBase
    {
        public string? _text;
        [Parameter]
        public string? Text
        {
            get => _text;
            set
            {
                if (_text == value) return;
                _text = value;
                TextChanged.InvokeAsync(value);
            }
        }
        [Parameter]
        public EventCallback<string> TextChanged { get; set; }

        public string? _comments;
        [Parameter]
        public string? Comments
        {
            get => _comments;
            set
            {
                if (_comments == value) return;
                _comments = value;
                CommentsChanged.InvokeAsync(value);
            }
        }
        [Parameter]
        public EventCallback<string> CommentsChanged { get; set; }
        [Parameter] public List<string>? Images { get; set; }
        [Parameter]
        public EventCallback<List<string>> ImagesChanged { get; set; }
        [Parameter] public string? Label { get; set; }
        [Parameter] public List<string> OptionsList { get; set; }

        private IEnumerable<string> Options { get; set; }
        protected override async Task OnParametersSetAsync()
        {
            OptionsList = OptionsList ?? new List<string>();
            if (Text != null)
            {
                Options = Text.Split(", ");
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
                return await ImageUtil.CompressImage(file, 800, 800);
            }

        }
    }
}
