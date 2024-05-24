using CuallimexManagement.Entities;

namespace CuallimexManagement.Infrastructure.Interfaces
{
    public interface IWorkPdf
    {
        public Task<byte[]> Show(Report report);
        public Task<byte[]> Download(Report report);
        public Task<byte[]> DownloadEvidence(Report report);
    }
}
