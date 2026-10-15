using Soal1_2_3.Models;

namespace Soal1_2_3.Repositories
{
    public interface IBukuRepository
    {
        Task<Buku?> GetByIdAsync(int id);
        Task<IEnumerable<Buku>> GetAllAsync(string? search);
        Task AddAsync(Buku product);
        Task UpdateAsync(Buku product);
        Task DeleteAsync(int id);
    }
}
