using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Soal1_2_3.Dto;
using Soal1_2_3.Models;
using Soal1_2_3.Repositories;

namespace Soal1_2_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JenisBukuController : ControllerBase
    {
        private readonly IJenisBukuRepository _repo;
        public JenisBukuController(IJenisBukuRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repo.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(MasterJenisBukuDto dto)
        {
            var item = new MasterJenisBuku { JenisBuku = dto.JenisBuku };
            await _repo.AddAsync(item);
            return Ok(item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MasterJenisBukuDto dto)
        {
            var item = await _repo.GetByIdAsync(id);
            
            if (item == null) return NotFound();

            item.JenisBuku = dto.JenisBuku;
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
