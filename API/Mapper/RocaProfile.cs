using AutoMapper;

public class RocaProfile : Profile
{
    public RocaProfile()
    {
        CreateMap<RocaDTO, RocaEntity>();
        CreateMap<RocaEntity, RocaDTO>();
        CreateMap<BaseRocaDTO, RocaEntity>();
        CreateMap<RocaEntity, BaseRocaDTO>();
    }
}
