using Autofac;
using FoodAppApi.Data;
using FoodAppApi.DTO;
using FoodAppApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace FoodAppApi
{
    public class AutoFacModule :Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationContext>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(RequestParameters<>)).InstancePerLifetimeScope();
            builder.RegisterType<ControllerParameters>().InstancePerLifetimeScope();
            builder.RegisterType<UserState>().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerLifetimeScope();

        }
    }
}
