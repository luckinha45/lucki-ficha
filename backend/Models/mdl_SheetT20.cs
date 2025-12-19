using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public class FichaT20 : TimeStampEntity
{
    [Key]
    public Guid Id { get; set; }

    public required string Nome { get; set; }
    public string Classe { get; set; } = "";
    public string Raca { get; set; } = "";

    public string ImgUrl { get; set; } = "";

    public int Nivel { get; set; } = 0;
    public int Experiencia { get; set; } = 0;
    public int Dinheiro { get; set; } = 0;

    public int VidaAtual { get; set; } = 0;
    public int VidaMaxima { get; set; } = 0;

    public int ManaAtual { get; set; } = 0;
    public int ManaMaxima { get; set; } = 0;

    public int Forca { get; set; } = 0;
    public int Destreza { get; set; } = 0;
    public int Constituicao { get; set; } = 0;
    public int Inteligencia { get; set; } = 0;
    public int Sabedoria { get; set; } = 0;
    public int Carisma { get; set; } = 0;

    public List<HabilidadeT20> Habilidades { get; set; } = new List<HabilidadeT20>();
    public List<EquipamentoT20> Equipamentos { get; set; } = new List<EquipamentoT20>();
    public List<PericiaT20> Pericias { get; set; } = new List<PericiaT20>();
    
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
}

public class PericiaT20 : TimeStampEntity
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = null!;
    public int Valor { get; set; }

    public Guid FichaT20Id { get; set; }
    public FichaT20 FichaT20 { get; set; } = null!;
    
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
}

public class HabilidadeT20 : TimeStampEntity
{
    [Key]
    public Guid Id { get; set; }

    public required FichaT20 Ficha { get; set; }
    public required Guid FichaId { get; set; }

    public List<ModT20> Mods { get; set; } = new List<ModT20>();

    public required string Nome { get; set; }
    public string Descricao { get; set; } = "";
    public required string Tipo { get; set; }
    
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
}

public class EquipamentoT20 : TimeStampEntity
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = null!;
    public string Descr { get; set; } = null!;
    public string Peso { get; set; } = null!;
    public int Preco { get; set; }

    public Guid FichaT20Id { get; set; }
    public FichaT20 FichaT20 { get; set; } = null!;

    public List<ModT20> Mods { get; set; } = new List<ModT20>();
    
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
}

public class ModT20 : TimeStampEntity
{
    [Key]
    public Guid Id { get; set; }

    public HabilidadeT20? Habilidade { get; set; }
    public Guid? HabilidadeId { get; set; }

    public EquipamentoT20? Equipamento { get; set; }
    public Guid? EquipamentoId { get; set; }
    
    public required string Nome { get; set; }
    public string AplicaEm { get; set; } = "";
    public int Valor { get; set; } = 0;
    public bool Ativo { get; set; } = true;
    
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
}
