namespace AspNetDependencyInjectionVS
{
    using Autofac;

    public class MyInstanceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(new MyServiceInstance(Startup.InstanceId)).As<IInstance>();
        }
    }
}