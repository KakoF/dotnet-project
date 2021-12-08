using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Integrator.Interface
{
    public interface IIntegrator
    {
        Task<IEnumerable<Brand>> GetBrand();
        Task<IEnumerable<Model>> GetModel(int brandId);
        Task<IEnumerable<Domain.Models.Version>> GetVersion(int modelId);
    }
}
