using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autofac;
using Domain.DAL.Implementations;
using Domain.DAL.Interfaces;
using Autofac.Integration.Mvc;
using System.Reflection;

namespace Domain
{
    public class AutofacConfig : Autofac.Module
    {
        /// <inheritdoc/>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerRequest();

            builder.RegisterGeneric(typeof(GetByKeyQuery<>))
                .As(typeof(IGetByKeyQuery<>));

            builder.RegisterGeneric(typeof(GetListQuery<>))
                .As(typeof(IGetListQuery<>));

            builder.RegisterGeneric(typeof(CreateCommand<>))
                .As(typeof(ICreateCommand<>));

            builder.RegisterGeneric(typeof(UpdateCommand<>))
                .As(typeof(IUpdateCommand<>));
        }
    }
}
