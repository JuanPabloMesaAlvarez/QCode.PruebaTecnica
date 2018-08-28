using System;
using QCode.Application.Services.Contract;
using QCode.Application.Services.Impl;
using QCode.Domain.Repositories;
using QCode.DomainServices;
using QCode.Infrastructure.Dependecies;
using QCode.Infrastructure.ExcelHandler;
using QCode.Persistence;

namespace QCode.Application.Utils
{
    public static class RegisterTypes
    {
        public static void RegisterApplicationTypes()
        {
            RegisterDomainRepositories();
            RegisterDomainServices();
            RegisterApplicationServices();
            RegisterInfraestructureServices();
        }

        private static void RegisterInfraestructureServices()
        {
            DependencyFactory.RegisterType<IExcelHandler, ExcelHandler>();
        }

        private static void RegisterDomainRepositories()
        {
            DependencyFactory.RegisterType<IUnitOfWork, UnitOfWork>();
        }

        private static void RegisterDomainServices()
        {
            DependencyFactory.RegisterType<ILoginService, LoginService>();
            DependencyFactory.RegisterType<IVehiculosService, VehiculosService>();
            DependencyFactory.RegisterType<IReparacionService, ReparacionService>();
        }

        private static void RegisterApplicationServices()
        {
            DependencyFactory.RegisterType<ILoginServiceController, LoginServiceController>();
            DependencyFactory.RegisterType<IVehiculosServiceController, VehiculosServiceController>();
            DependencyFactory.RegisterType<IOrdenesReparacionServiceController, OrdenesReparacionServiceController>();
        }
    }
}
