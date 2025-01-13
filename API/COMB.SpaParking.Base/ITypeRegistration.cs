using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMB.SpaParking.Base
{
    public interface ITypeRegistration
    {
        void RegisterTypes(IServiceCollection serviceCollection);
    }
}
