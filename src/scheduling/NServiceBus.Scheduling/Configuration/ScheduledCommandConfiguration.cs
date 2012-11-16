namespace NServiceBus.Scheduling.Configuration
{
    using System.Configuration;

    internal class TaskScheduleConfiguration : ConfigurationSection
    {
        public static TaskScheduleConfiguration GetConfig()
        {
            return (TaskScheduleConfiguration)ConfigurationManager.GetSection("TaskSchedule");
        }

        [ConfigurationProperty("Tasks")]
        public ScheduledTaskConfigurationCollection ScheduledTasks
        {
            get
            {
                return (ScheduledTaskConfigurationCollection)this["Tasks"];
            }
        }
    }
}
