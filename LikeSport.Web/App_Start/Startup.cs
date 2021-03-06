﻿using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using LikeSport.Data;
using LikeSport.Data.Infrastructure;
using LikeSport.Data.Respositories;
using LikeSport.Model;
using LikeSport.Service;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using Owin;

[assembly: OwinStartup(typeof(LikeSport.Web.App_Start.Startup))]

namespace LikeSport.Web.App_Start
{
    public  partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            ConfigAutofac(app);
            ConfigureAuth(app);

        }
        private void ConfigAutofac(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()); //Register WebApi Controllers

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            builder.RegisterType<ActivitySportDbContext>().AsSelf().InstancePerRequest();


            //Asp.net Identity
            builder.RegisterType<ApplicationUserStore>().As<IUserStore<ApplicationUser>>().InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register(c => app.GetDataProtectionProvider()).InstancePerRequest();

            //Repositories
            builder.RegisterAssemblyTypes(typeof(ActivityRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(ActivityGroupRepository).Assembly)
              .Where(t => t.Name.EndsWith("Repository"))
              .AsImplementedInterfaces().InstancePerRequest(); ;

            builder.RegisterAssemblyTypes(typeof(ServiceRepository).Assembly)
            .Where(t => t.Name.EndsWith("Repository"))
            .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(ActivityInfomationRepository).Assembly)
           .Where(t => t.Name.EndsWith("Repository"))
           .AsImplementedInterfaces().InstancePerRequest(); ;

            // Services
            builder.RegisterAssemblyTypes(typeof(ActivityService).Assembly)
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(ActivityGroupService).Assembly)
             .Where(t => t.Name.EndsWith("Service"))
             .AsImplementedInterfaces().InstancePerRequest(); ;

            builder.RegisterAssemblyTypes(typeof(ServiceService).Assembly)
          .Where(t => t.Name.EndsWith("Service"))
          .AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterAssemblyTypes(typeof(ActivityInfomationService).Assembly)
        .Where(t => t.Name.EndsWith("Service"))
        .AsImplementedInterfaces().InstancePerRequest(); ;

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver

        }
    }
}
