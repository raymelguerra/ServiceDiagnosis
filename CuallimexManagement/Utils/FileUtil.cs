using Microsoft.AspNetCore.Components;

namespace CuallimexManagement.Utils;
public static class FileUtil
{
    public static async Task SaveAs(NavigationManager navigationManager, string fileName, byte[] fileContent, string contentType)
    {
        var memoryStream = new MemoryStream(fileContent);
        var buffer = new byte[16 * 1024];
        var resultStream = new MemoryStream();
        int bytesRead;
        while ((bytesRead = await memoryStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
        {
            await resultStream.WriteAsync(buffer, 0, bytesRead);
        }
        resultStream.Position = 0;

        var contentDisposition = $"attachment; filename=\"{fileName}\"";

        // Configurar la descarga usando NavigationManager
        navigationManager.NavigateTo($"data:{contentType};base64,{Convert.ToBase64String(resultStream.ToArray())}", true);
    }
}
