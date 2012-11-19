namespace NServiceBus.Scheduling.ServiceTasks.Configuration
{
    using System;
    using System.Configuration;

    internal class ServiceTaskConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true)]
        public String Name
        {
            get
            {
                return this["name"] as String;
            }
        }

        [ConfigurationProperty("interval", IsRequired = true)]
        public Int32 Interval
        {
            get
            {
                return Convert.ToInt32(this["interval"]);
            }
        }

        [ConfigurationProperty("messageType", IsRequired = true)]
        public String MessageType
        {
            get
            {
                return this["messageType"] as String;
            }
        }

        [ConfigurationProperty("messageAssembly", IsRequired = false)]
        public String MessageAssembly
        {
            get
            {
                return this["messageAssembly"] as String;
            }
        }
    }
}
