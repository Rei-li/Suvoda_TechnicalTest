using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Suvoda.TechnicalTest.Mappings
{
    public interface IDtoModelMapper
    {
        IMapper AutoMapper { get; set; }
    }
}
