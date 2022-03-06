using AutoMapper;

public class PujaProfile : Profile
{
    public PujaProfile()
    {
        CreateMap<PujaDTO, PujaEntity>();
        CreateMap<PujaEntity, PujaDTO>();
        CreateMap<BasePujaDTO, PujaEntity>();
        CreateMap<PujaEntity, BasePujaDTO>();
    }
}
