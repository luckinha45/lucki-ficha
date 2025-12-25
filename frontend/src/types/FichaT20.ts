export interface FichaT20 {
    id: string;
    nome: string;
    classe: string | null;
    raca: string | null;
    imgUrl: string;
    nivel: number | null;
    experiencia: number | null;
    dinheiro: number | null;
    vidaAtual: number | null;
    vidaMaxima: number | null;
    manaAtual: number | null;
    manaMaxima: number | null;
    forca: number | null;
    destreza: number | null;
    constituicao: number | null;
    inteligencia: number | null;
    sabedoria: number | null;
    carisma: number | null;

    // Habilidades: HabilidadeT20Dto[];
    // Equipamentos: EquipamentoT20Dto[];
    // Pericias: PericiaT20Dto[];
}