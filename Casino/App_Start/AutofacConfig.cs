using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using DAL.Repositories.Interfaces;
using DAL.Repositories.Implementations;
using System.Web.Http;
using System.Reflection;
using Umbraco.Web;
using Casino.Services.Interfaces;
using Casino.Services.Implementations;

namespace Casino.App_Start
{
    public static class AutofacConfig
    {

        public static void RegisterServices()
        {
            /*
            var builder = new ContainerBuilder();

            // register all controllers found in your assembly
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            // register Umbraco MVC + web API controllers used by the admin site
            builder.RegisterControllers(typeof(Umbraco.Web.UmbracoApplication).Assembly);
            builder.RegisterApiControllers(typeof(Umbraco.Web.UmbracoApplication).Assembly);
            builder.RegisterType<NewsletterRepository>()
                    .As<INewsletterRepository>()
                    .InstancePerRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            */

            var builder = new ContainerBuilder();

            /* MVC Controllers */

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();


            /* WebApi Controllers */
            builder.RegisterApiControllers(typeof(UmbracoApplication).Assembly);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<NewsletterService>()
            .As<INewsletterService>()
            .InstancePerRequest();
            builder.RegisterType<NewsletterRepository>()
            .As<INewsletterRepository>()
            .InstancePerRequest();

            builder.RegisterType<MessageService>()
            .As<IMessageService>()
            .InstancePerRequest();
            builder.RegisterType<MessageRepository>()
            .As<IMessageRepository>()
            .InstancePerRequest();
            //builder.RegisterModule<WebModule>();
            var container = builder.Build();


            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}