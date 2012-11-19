namespace NServiceBus.Scheduling.ServiceTasks
{
    using System;
    using log4net;
    using NServiceBus.Scheduling;
    using NServiceBus.Scheduling.ServiceTasks.Configuration;

    public class ScheduleServiceTasksOnStartup : IWantToRunWhenTheBusStarts
    {
        private const String ClassName = "ServiceTasks";
        private readonly IBus bus;
        private readonly ILog logger;
        private readonly ServiceTaskScheduleConfiguration config;

        public ScheduleServiceTasksOnStartup(IBus bus)
        {
            if (null == bus)
                throw new ArgumentNullException("bus");

            this.bus = bus;
            this.config = ServiceTaskScheduleConfiguration.GetConfig();
            this.logger = LogManager.GetLogger(ClassName);
        }

        private void LoadConfiguredCommands()
        {
            if (config != null)
            {
                foreach (ServiceTaskConfigurationElement configTask in config.ScheduledTasks)
                {
                    try
                    {
                        NServiceBus.Schedule.Every(TimeSpan.FromMinutes(configTask.Interval)).Action(() =>
                        {
                            var command = this.bus.CreateInstance(Type.GetType(configTask.MessageType, true));

                            this.bus.SendLocal(command);
                        });
                    }
                    catch (TypeLoadException tle)
                    {
                        logger.Warn(String.Format("Could not load schedule task {0}: {1}", configTask.Name, tle.Message));
                    }
                }
            }
        }

        #region IWantToRunWhenTheBusStarts Members

        public void Run()
        {
            this.LoadConfiguredCommands();
        }

        #endregion

    }
}
