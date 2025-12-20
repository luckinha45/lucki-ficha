using AutoMapper;
using backend.Models;

namespace backend;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<FichaT20, FichaT20Dto>();
        CreateMap<FichaT20Dto, FichaT20>()
            .ForAllMembers(opts =>
                opts.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<HabilidadeT20, HabilidadeT20Dto>();
        CreateMap<EquipamentoT20, EquipamentoT20Dto>();
        CreateMap<PericiaT20, PericiaT20Dto>();
    }
}