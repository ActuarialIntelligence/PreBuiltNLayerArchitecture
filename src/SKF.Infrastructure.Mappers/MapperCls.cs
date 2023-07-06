using AutoMapper;
using AML.infrastructure.Data.Dto;
using AML.Infrastructure.Data.EF;

namespace SKF.Infrastructure.Mappers;

public class MapperCls
{
    public void Configure()// needs to be called on start
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<RECEPTION, ReceptionDto>();
        });

        IMapper mapper = config.CreateMapper();

        // Now you can use the mapper to perform the mapping
        var sourceReception = new RECEPTION();
        var destinationDto = mapper.Map<ReceptionDto>(sourceReception);
    }
}