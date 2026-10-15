using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Soal1_2_3.Dto;
using Soal1_2_3.Models;
using Soal1_2_3.Repositories;

namespace Soal1_2_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BukuController : ControllerBase
    {
        private readonly IBukuRepository _repo;
        public BukuController(IBukuRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? search)
        {
            return Ok(await _repo.GetAllAsync(search));
        }

        [HttpPost]
        public async Task<IActionResult> Create(BukuDto dto)
        {
            var item = new Buku { 
                Judul = dto.Judul,
                Penulis = dto.Penulis,
                JenisBukuId = dto.JenisBukuId,
                TanggalRilis = dto.TanggalRilis,
                JumlahHalaman = dto.JumlahHalaman
            };
            await _repo.AddAsync(item);
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, BukuDto dto)
        {
            var item = await _repo.GetByIdAsync(id);

            if (item == null) return NotFound();

            item.Judul = dto.Judul;
            item.Penulis = dto.Penulis;
            item.JenisBukuId = dto.JenisBukuId;
            item.TanggalRilis = dto.TanggalRilis;
            item.JumlahHalaman = dto.JumlahHalaman;

            await _repo.UpdateAsync(item);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteAsync(id);
            return Ok();
        }
    }
}
