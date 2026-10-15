using Microsoft.EntityFrameworkCore;
using Soal1_2_3.Models;

namespace Soal1_2_3.Repositories
{
    public class JenisBukuRepository : IJenisBukuRepository
    {
        private readonly LPSDbContext _context;
        public JenisBukuRepository(LPSDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(MasterJenisBuku product)
        {
            await _context.MasterJenisBukus.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.MasterJenisBukus.FindAsync(id);
            if (item != null)
            {
                _context.MasterJenisBukus.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MasterJenisBuku>> GetAllAsync()
        {
            return await _context.MasterJenisBukus.ToListAsync();
        }

        public async Task<MasterJenisBuku?> GetByIdAsync(int id)
        {
            return await _context.MasterJenisBukus.FindAsync(id);
        }

        public async Task UpdateAsync(MasterJenisBuku product)
        {
            _context.MasterJenisBukus.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
