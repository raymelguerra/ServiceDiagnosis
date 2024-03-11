using CuallimexManagement.Entities;
using MongoDB.Driver;

namespace CuallimexManagement.Infrastructure.Interfaces;

public interface IReport
{
    public Task<ICollection<Report>> GetAllAsync();
    public Task<Report> GetByIdAsync(string Id);
    public Task<DeleteResult> DeleteAsync(string Id);
    public Task<UpdateResult> UpdateAsync(string Id, Report report);
    public Task<Report> CreateAsync(Report report);
}
