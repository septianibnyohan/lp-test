using Microsoft.EntityFrameworkCore;
using Soal1_2_3.Models;

namespace Soal1_2_3.Repositories
{
    public class BukuRepository : IBukuRepository
    {
        private readonly LPSDbContext _context;

        public BukuRepository(LPSDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Buku>> GetAllAsync(String? search)
        {
            if (!String.IsNullOrWhiteSpace(search))
            {
                return await _context.Buku
                .Where(o => o.Judul.Contains(search) || o.Penulis.Contains(search))
                .Include(b => b.MasterJenisBuku)
                .ToListAsync();
            }

            return await _context.Buku
                .Include(b => b.MasterJenisBuku)
                .ToListAsync();
        }

        public async Task<Buku?> GetByIdAsync(int id)
        {
            return await _context.Buku
                .Include(b => b.MasterJenisBuku)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddAsync(Buku product)
        {
            await _context.Buku.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Buku product)
        {
            _context.Buku.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.Buku.FindAsync(id);
            if (item != null)
            {
                _context.Buku.Remove(item);
                await _context.SaveChangesAsync();
            }
        }
    }
}
