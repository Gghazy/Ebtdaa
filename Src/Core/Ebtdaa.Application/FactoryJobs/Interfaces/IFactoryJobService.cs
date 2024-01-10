using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebtdaa.Application.FactoryJobs.Interfaces
{
    public interface IFactoryJobService
    {
        Task<int> FactoryIntegrat();
    }
}
