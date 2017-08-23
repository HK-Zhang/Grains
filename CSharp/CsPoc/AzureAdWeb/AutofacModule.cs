using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using AzureAdWeb.AutofacPoc;

namespace AzureAdWeb
{
    public class AutofacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<Poc>().As<IPoc>();

        }
    }
}
