using AutoMapper;
using Suvoda.TechnicalTest.BLL.Mappings;

namespace Suvoda.TechnicalTest.BLL.Services
{
    public class ServiceBase 
    {
        protected IMapper Mapper = EntityDtoMapper.RegisterMappings();

    }
}