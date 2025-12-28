using System.Reflection;
using System.Text.Json;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("api")]
public class CtrFicha : ControllerBase
{
    private readonly AppDbContext _db;
    
    public CtrFicha(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet("ficha-t20")]
    public async Task<IActionResult> GetFichas()
    {
        var fichas = await _db.FichaT20
            // .Include(f => f.Habilidades)
            // .Include(f => f.Equipamentos)
            // .Include(f => f.Pericias)
            .ToListAsync();

        // var fichasDto = _mapper.Map<List<Models.FichaT20Dto>>(fichas);
        return Ok(fichas.Select(f => new { f.Id, f.Gerais.Nome, f.Gerais.ImgUrl }));
    }

    [HttpGet("ficha-t20/{id}")]
    public async Task<IActionResult> GetFicha(Guid id)
    {
        var ficha = await _db.FichaT20
            .Include(f => f.Habilidades)
            .Include(f => f.Equipamentos)
            .Include(f => f.Pericias)
            .AsSplitQuery()
            .FirstOrDefaultAsync(f => f.Id == id);

        if (ficha == null)
        {
            return NotFound();
        }

        return Ok(ficha);
    }

    [HttpPost("ficha-t20")]
    public async Task<IActionResult> CreateFicha([FromBody] Models.FichaT20Dto dto)
    {
        if (dto.Gerais?.Nome == null) return BadRequest(new {error = "Propriedade [Gerais.Nome] é obrigatório"});

        FichaT20 fichaEntity = new();
        FichaT20Mapper.DtoToEntity(dto, fichaEntity);

        _db.FichaT20.Add(fichaEntity);
        await _db.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetFicha), new { id = fichaEntity.Id }, fichaEntity);
    }

    [HttpPatch("ficha-t20/{id}")]
    public async Task<IActionResult> UpdateFicha(Guid id, [FromBody] Models.FichaT20Dto dto)
    {
        var existingFicha = await _db.FichaT20.FindAsync(id);
        if (existingFicha == null)
        {
            return NotFound();
        }

        FichaT20Mapper.DtoToEntity(dto, existingFicha);

        await _db.SaveChangesAsync();
        return NoContent();
    }
}