using System.ComponentModel.DataAnnotations;

namespace backend.Models;

public class FichaT20 : TimeStampEntity
{
    [Key]
    public Guid Id { get; set; }

    public class GeraisEntity
    {
        public string Nome { get; set; } = null!;
        public string Classe { get; set; } = "";
        public string Raca { get; set; } = "";
        public string Divindade { get; set; } = "";
        public string Origem { get; set; } = "";
        public string ImgUrl { get; set; } = "";
        public int Nivel { get; set; } = 0;
        public int Experiencia { get; set; } = 0;
        public int Dinheiro { get; set; } = 0;
    }
    public GeraisEntity Gerais { get; set; } = new();

    public class PontosEntity
    {
        public int Atual { get; set; } = 0;
        public int Maximo { get; set; } = 0;
        public int Temp { get; set; } = 0;
    }
    public PontosEntity Vida { get; set; } = new();
    public PontosEntity Mana { get; set; } = new();

    public class AtributosEntity
    {
        public int Forca { get; set; } = 0;
        public int Destreza { get; set; } = 0;
        public int Constituicao { get; set; } = 0;
        public int Inteligencia { get; set; } = 0;
        public int Sabedoria { get; set; } = 0;
        public int Carisma { get; set; } = 0;
    }

    public AtributosEntity Atributos { get; set; } = new();

    public List<HabilidadeT20> Habilidades { get; set; } = new List<HabilidadeT20>();
    public List<EquipamentoT20> Equipamentos { get; set; } = new List<EquipamentoT20>();
    public List<PericiaT20> Pericias { get; set; } = new List<PericiaT20>();
}

public class FichaT20Dto
{
    public Guid? Id { get; set; }

    public class GeraisDto
    {
        public string? Nome { get; set; }
        public string? Classe { get; set; }
        public string? Raca { get; set; }
        public string? Divindade { get; set; }
        public string? Origem { get; set; }
        public string? ImgUrl { get; set; }
        public int? Nivel { get; set; }
        public int? Experiencia { get; set; }
        public int? Dinheiro { get; set; }
    }
    public GeraisDto? Gerais { get; set; }

    public class PontosDto
    {
        public int? Atual { get; set; }
        public int? Maximo { get; set; }
        public int? Temp { get; set; }
    }
    public PontosDto? Vida { get; set; }
    public PontosDto? Mana { get; set; }

    public class AtributosDto
    {
        public int? Forca { get; set; }
        public int? Destreza { get; set; }
        public int? Constituicao { get; set; }
        public int? Inteligencia { get; set; }
        public int? Sabedoria { get; set; }
        public int? Carisma { get; set; }
    }

    public AtributosDto? Atributos { get; set; }

    public List<HabilidadeT20Dto>? Habilidades { get; set; }
    public List<EquipamentoT20Dto>? Equipamentos { get; set; }
    public List<PericiaT20Dto>? Pericias { get; set; }
}

class FichaT20Mapper
{
    public static void DtoToEntity(FichaT20Dto dto, FichaT20 entity)
    {
        if (dto == null || entity == null) return;

        // 1. Update Gerais
        if (dto.Gerais != null)
        {
            entity.Gerais.Nome = dto.Gerais.Nome ?? entity.Gerais.Nome;
            entity.Gerais.Classe = dto.Gerais.Classe ?? entity.Gerais.Classe;
            entity.Gerais.Raca = dto.Gerais.Raca ?? entity.Gerais.Raca;
            entity.Gerais.Divindade = dto.Gerais.Divindade ?? entity.Gerais.Divindade;
            entity.Gerais.Origem = dto.Gerais.Origem ?? entity.Gerais.Origem;
            entity.Gerais.ImgUrl = dto.Gerais.ImgUrl ?? entity.Gerais.ImgUrl;
            
            entity.Gerais.Nivel = dto.Gerais.Nivel ?? entity.Gerais.Nivel;
            entity.Gerais.Experiencia = dto.Gerais.Experiencia ?? entity.Gerais.Experiencia;
            entity.Gerais.Dinheiro = dto.Gerais.Dinheiro ?? entity.Gerais.Dinheiro;
        }

        // 2. Update Vida & Mana
        UpdatePontos(dto.Vida, entity.Vida);
        UpdatePontos(dto.Mana, entity.Mana);

        // 3. Update Atributos
        if (dto.Atributos != null)
        {
            entity.Atributos.Forca = dto.Atributos.Forca ?? entity.Atributos.Forca;
            entity.Atributos.Destreza = dto.Atributos.Destreza ?? entity.Atributos.Destreza;
            entity.Atributos.Constituicao = dto.Atributos.Constituicao ?? entity.Atributos.Constituicao;
            entity.Atributos.Inteligencia = dto.Atributos.Inteligencia ?? entity.Atributos.Inteligencia;
            entity.Atributos.Sabedoria = dto.Atributos.Sabedoria ?? entity.Atributos.Sabedoria;
            entity.Atributos.Carisma = dto.Atributos.Carisma ?? entity.Atributos.Carisma;
        }
    }

    private static void UpdatePontos(FichaT20Dto.PontosDto? dto, FichaT20.PontosEntity entity)
    {
        if (dto == null) return;
        entity.Atual = dto.Atual ?? entity.Atual;
        entity.Maximo = dto.Maximo ?? entity.Maximo;
        entity.Temp = dto.Temp ?? entity.Temp;
    }
}
