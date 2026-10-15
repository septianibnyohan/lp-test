using Soal1_2_3.Models;

namespace Soal1_2_3.Repositories
{
    public interface IJenisBukuRepository
    {
        Task<MasterJenisBuku?> GetByIdAsync(int id);
        Task<IEnumerable<MasterJenisBuku>> GetAllAsync();
        Task AddAsync(MasterJenisBuku product);
        Task UpdateAsync(MasterJenisBuku product);
        Task DeleteAsync(int id);
    }
}
