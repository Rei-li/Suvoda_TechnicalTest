using AutoMapper;
using Suvoda.TechnicalTest.BLL.Mappings;

namespace Suvoda.TechnicalTest.BLL.Services
{
    public class BloBase 
    {
        protected IMapper Mapper = EntityDtoMapper.RegisterMappings();

    }
}