using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class PericiaT20 : TimeStampEntity
{
    [Key]
    public Guid Id { get; set; }

    public string Nome { get; set; } = null!;
    public int Valor { get; set; }

    public Guid FichaT20Id { get; set; }
    public FichaT20? FichaT20 { get; set; }
}

public class PericiaT20Dto
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = null!;
    public int Valor { get; set; }
    public Guid FichaT20Id { get; set; }
}
