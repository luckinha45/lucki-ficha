using System.Reflection;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("api")]
public class CtrHabT20 : ControllerBase
{
    private readonly AppDbContext _db;
    
    public CtrHabT20(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet("hab-t20")]
    public async Task<IActionResult> GetHabilidades()
    {
        var habilidades = await _db.HabilidadeT20.ToListAsync();
        return Ok(habilidades);
    }

    [HttpPost("hab-t20")]
    public async Task<IActionResult> CreateHabilidade([FromBody] Models.HabilidadeT20Dto habilidade)
    {
        var hab = new Models.HabilidadeT20
        {
            FichaId = habilidade.FichaId,
            Nome = habilidade.Nome,
            Tipo = habilidade.Tipo,
            Descricao = habilidade.Descricao ?? ""
        };

        _db.HabilidadeT20.Add(hab);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetHabilidades), new { id = hab.Id }, hab);
    }

    [HttpPatch("hab-t20/{id}")]
    public async Task<IActionResult> UpdateHabilidade(Guid id, [FromBody] JsonElement patchDoc)
    {
        var existingHab = await _db.HabilidadeT20.FindAsync(id);
        if (existingHab == null)
        {
            return NotFound();
        }
        
        var habType = existingHab.GetType();

        foreach (var prop in patchDoc.EnumerateObject())
        {
            var property = habType.GetProperty(prop.Name, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (property != null && property.CanWrite)
            {
                object? value = null;
                if (property.PropertyType == typeof(string))
                    value = prop.Value.GetString();
                else if (property.PropertyType == typeof(int))
                    value = prop.Value.GetInt32();
                else if (property.PropertyType == typeof(Guid))
                    value = prop.Value.GetGuid();
                else if (property.PropertyType == typeof(bool))
                    value = prop.Value.GetBoolean();

                if (value != null)
                    property.SetValue(existingHab, value);
            }
        }

        await _db.SaveChangesAsync();
        return NoContent();
    }
}