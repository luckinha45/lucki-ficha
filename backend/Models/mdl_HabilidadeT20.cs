using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class HabilidadeT20 : TimeStampEntity
{
    [Key]
    public Guid Id { get; set; }

    public FichaT20? Ficha { get; set; }
    public required Guid FichaId { get; set; }

    public List<ModT20> Mods { get; set; } = new List<ModT20>();

    public string Nome { get; set; } = null!;
    public string Descricao { get; set; } = "";
    public string Tipo { get; set; } = null!;
}

public class HabilidadeT20Dto
{
    public Guid Id { get; set; }
    public Guid FichaId { get; set; }
    public string Nome { get; set; } = null!;
    public string Tipo { get; set; } = null!;
    public string? Descricao { get; set; }
}
