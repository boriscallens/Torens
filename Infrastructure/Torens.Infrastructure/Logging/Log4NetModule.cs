using Autofac;
using log4net;
using Torens.Domain.Logging;

namespace Torens.Infrastructure.Logging
{
    public class Log4NetModule: Module
    {
        public Log4NetModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.Register(x => new Logger(LogManager.GetLogger(x.GetType()))).As<ILogger>();
        }
    }
}