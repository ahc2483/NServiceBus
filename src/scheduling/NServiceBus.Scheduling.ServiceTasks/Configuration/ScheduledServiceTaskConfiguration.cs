namespace NServiceBus.Scheduling.ServiceTasks.Configuration
{
    using System.Configuration;

    internal class ServiceTaskScheduleConfiguration : ConfigurationSection
    {
        public static ServiceTaskScheduleConfiguration GetConfig()
        {
            return (ServiceTaskScheduleConfiguration)ConfigurationManager.GetSection("TaskSchedule");
        }

        [ConfigurationProperty("Tasks")]
        public ServiceTaskConfigurationCollection ScheduledTasks
        {
            get
            {
                return (ServiceTaskConfigurationCollection)this["Tasks"];
            }
        }
    }
}
