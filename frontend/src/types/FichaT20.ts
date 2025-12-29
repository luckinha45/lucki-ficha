export interface FichaT20 {
  id: string | null;
  gerais: {
    nome: string;
    imgUrl: string;
    classe: string | null;
    raca: string | null;
    origem: string | null;
    divindade: string | null;
    nivel: number | null;
    experiencia: number | null;
    dinheiro: number | null;
  };
  pv: {
    atual: number | null;
    maxima: number | null;
    temp: number | null;
  };
  pm: {
    atual: number | null;
    maxima: number | null;
    temp: number | null;
  };

  atributos: {
    forca: number | null;
    destreza: number | null;
    constituicao: number | null;
    inteligencia: number | null;
    sabedoria: number | null;
    carisma: number | null;
  };

  // Habilidades: HabilidadeT20Dto[];
  // Equipamentos: EquipamentoT20Dto[];
  // Pericias: PericiaT20Dto[];
}
