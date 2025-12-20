using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class FichaT20 : TimeStampEntity
{
    [Key]
    public Guid Id { get; set; }

    public string Nome { get; set; } = null!;
    public string Classe { get; set; } = "";
    public string Raca { get; set; } = "";

    public string? ImgUrl { get; set; }

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
}

public class FichaT20Dto
{
    public Guid? Id { get; set; }
    public string? Nome { get; set; }
    public string? Classe { get; set; }
    public string? Raca { get; set; }
    public string? ImgUrl { get; set; }
    public int? Nivel { get; set; }
    public int? Experiencia { get; set; }
    public int? Dinheiro { get; set; }
    public int? VidaAtual { get; set; }
    public int? VidaMaxima { get; set; }
    public int? ManaAtual { get; set; }
    public int? ManaMaxima { get; set; }
    public int? Forca { get; set; }
    public int? Destreza { get; set; }
    public int? Constituicao { get; set; }
    public int? Inteligencia { get; set; }
    public int? Sabedoria { get; set; }
    public int? Carisma { get; set; }

    public List<HabilidadeT20Dto> Habilidades { get; set; } = new List<HabilidadeT20Dto>();
    public List<EquipamentoT20Dto> Equipamentos { get; set; } = new List<EquipamentoT20Dto>();
    public List<PericiaT20Dto> Pericias { get; set; } = new List<PericiaT20Dto>();
}
