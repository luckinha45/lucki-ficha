using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class ModT20 : TimeStampEntity
{
    [Key]
    public Guid Id { get; set; }

    public HabilidadeT20? Habilidade { get; set; }
    public Guid? HabilidadeId { get; set; }

    public EquipamentoT20? Equipamento { get; set; }
    public Guid? EquipamentoId { get; set; }
    
    public string Nome { get; set; } = null!;
    public string AplicaEm { get; set; } = "";
    public int Valor { get; set; } = 0;
    public bool Ativo { get; set; } = true;
}

public class ModT20Dto
{
    public Guid Id { get; set; }
    public Guid? HabilidadeId { get; set; }
    public Guid? EquipamentoId { get; set; }
    public string Nome { get; set; } = null!;
    public string AplicaEm { get; set; } = "";
    public int Valor { get; set; }
    public bool Ativo { get; set; }
}
