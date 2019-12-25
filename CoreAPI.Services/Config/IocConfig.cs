using Autofac;
using CoreAPI.Infrastructure.Data.EF.SQL;
using Util.Datas;
using Util.Datas.Ef;
using Util.DI.Autofac;

namespace CoreAPI.Services.Config
{
   public class IocConfig: ConfigBase
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CoreUnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        }
    }
}
