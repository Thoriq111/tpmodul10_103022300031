using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace tpmodul10_103022300031.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : ControllerBase
    {
        public static readonly List<mahasiswa1> mahasiswa = new()
        {
            new mahasiswa1("Muhamad Thoriq Marcello", "103022300031"),
            new mahasiswa1("Ahmad Dillan", "103022300037"),
            new mahasiswa1("Muhammad Zaky Amarullah", "103022300045"),
            new mahasiswa1("Muhammad Reza Ferdinal", "103022300135"),
            new mahasiswa1("Rafa Mufid 'Aqila", "103022300061")

        };
        [HttpGet]
        public ActionResult<IEnumerable<mahasiswa1>> GetAllMahasiswa()
        {
            return Ok(mahasiswa);
        }
        [HttpGet("{id}")]
        public ActionResult<mahasiswa1> GetMahasiswaByIndex(int id)
        {
            if (id < 0 || id >= mahasiswa.Count)
            {
                return NotFound(new { message = "Mahasiswa tidak ditemukan" });
            }
            return Ok(mahasiswa[id]);
        }
        [HttpPost]
        public ActionResult AddMahasiswa([FromBody] mahasiswa1 mhsBaru)
        {
            if (string.IsNullOrWhiteSpace(mhsBaru.Nama) || string.IsNullOrWhiteSpace(mhsBaru.Nim))
            {
                return BadRequest(new { message = "Nama dan NIM harus diisi" });
            }
            mahasiswa.Add(mhsBaru);
            return Ok(new { message = "Mahasiswa telah ditambahkan", id = mahasiswa.Count - 1 });
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMahasiswa(int id)
        {
            if (id < 0 || id >= mahasiswa.Count)
            {
                return NotFound(new { message = "Mahasiswa tidak ditemukan" });
            }
            mahasiswa.RemoveAt(id);
            return Ok(new { message = "Mahasiswa berhasi dihapus" });
        }
    }
}
