using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class EquipamentoT20 : TimeStampEntity
{
    [Key]
    public Guid Id { get; set; }

    public string Nome { get; set; } = null!;
    public string? Descr { get; set; } = null!;
    public int Peso { get; set; } = 0;
    public int Preco { get; set; }

    public Guid FichaT20Id { get; set; }
    public FichaT20 FichaT20 { get; set; } = null!;

    public List<ModT20> Mods { get; set; } = new List<ModT20>();
}

public class EquipamentoT20Dto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = null!;
    public string? Descr { get; set; }
    public int Peso { get; set; }
    public int Preco { get; set; }
    public Guid FichaT20Id { get; set; }
}
