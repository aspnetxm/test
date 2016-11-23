﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using System.Web.Mvc;
using System.Reflection;

namespace Galaxy.Web
{
    public class IocConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            var domainServices = Assembly.Load("Galaxy.Domain");
            builder.RegisterAssemblyTypes(domainServices, domainServices)
              .Where(t => t.Name.EndsWith("Repository"))
              .AsImplementedInterfaces().PropertiesAutowired();

            var appServices = Assembly.Load("Galaxy.Application");
            builder.RegisterAssemblyTypes(appServices, appServices)
              .Where(t => t.Name.EndsWith("Service"))
              .AsImplementedInterfaces().PropertiesAutowired();

            //var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //builder.RegisterType<EFProductRepository>().As<IProductRepository>();

            //autofac 注册依赖
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}