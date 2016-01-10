namespace AspNetDependencyInjectionVS
{
    using Autofac;

    public class MyServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(s => new MyService()).As<ISingleton>().SingleInstance();
            builder.Register(s => new MyService()).As<IScoped>().InstancePerLifetimeScope();
            builder.Register(s => new MyService()).As<ITransient>().InstancePerDependency();

            /* note for scoped:
                attempting to use a lifetime of InstancePerRequest, as we would have done
                with earlier versions of ASP.NET, results in an error when we try to get
                and instance:

                "No scope with a Tag matching 'AutofacWebRequest' is visible from the scope in which the 
                instance was requested. This generally indicates that a component registered as per-HTTP 
                request is being requested by a SingleInstance() component (or a similar scenario.) 
                Under the web integration always request dependencies from the DependencyResolver.Current 
                or ILifetimeScopeProvider.RequestLifetime, never from the container itself."

                DependencyResolver.Current is specific to MVC 5, and apparently IServiceProvider is not
                begin resolved to the type returned by ILifetimeScopeProvider.RequestLifetime.
            */
        }
    }
}