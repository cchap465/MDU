using SimpleInjector;
using System.Reflection;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using SimpleInjector.Lifestyles;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using SimpleInjector.Integration.AspNetCore.Mvc;

namespace MyDutchUncle.Configuration
{
    public class SimpleInjectorRegistration
    {
        static readonly Container container = new Container();

        public void IntegrateSimpleInjector(IServiceCollection services)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(
                new SimpleInjectorControllerActivator(container));
            services.AddSingleton<IViewComponentActivator>(
                new SimpleInjectorViewComponentActivator(container));

            services.EnableSimpleInjectorCrossWiring(container);
            services.UseSimpleInjectorAspNetRequestScoping(container);
        }

        public void InitializeContainer(IApplicationBuilder app)
        {
            // Add application presentation components:
            container.RegisterMvcControllers(app);
            container.RegisterMvcViewComponents(app);

            SimpleInjectorRegistrations();           

            // Allow Simple Injector to resolve services from ASP.NET Core.
            container.AutoCrossWireAspNetComponents(app);
        }

        private void SimpleInjectorRegistrations()
        {
            var Assemblies = new[]
            {
                Assembly.Load("MyDutchUncle"),
                Assembly.Load("MyDutchUncle.DataAccess"),
                Assembly.Load("MyDutchUncle.Manufacture"),
                Assembly.Load("MyDutchUncle.Transport")
            };

            foreach (var assembly in Assemblies)
            {
                var registrations =
                from type in assembly.GetExportedTypes()
                from i in type.GetInterfaces()
                    //where type.Namespace == assembly.
                where type.GetInterfaces().Any()
                select new { Service = i, Implementation = type };

                foreach (var reg in registrations)
                {
                    container.Register(reg.Service, reg.Implementation, Lifestyle.Transient);
                }
            }

        //    foreach (var assembly in Assemblies)
        //    {
        //        var registrations =
        //        from type in assembly.GetExportedTypes()
        //        from i in type.GetInterfaces()
        //            //where type.Namespace == .
        //        where type.GetInterfaces().Any()
        //        //select registrat;
        //        select new { Service = i, Implementation = type };

        //        foreach (var reg in assembly.GetExportedTypes())
        //        {
        //            container.Register(reg, reg.Implementation, Lifestyle.Transient);


        //            container.Verify();
        }
    }
}
