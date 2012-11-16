namespace NServiceBus.Scheduling.Configuration
{
    using System.Configuration;

    internal class ScheduledTaskConfigurationCollection : ConfigurationElementCollection
    {
        new public ScheduledTaskConfigurationElement this[string key]
        {
            get
            {
                return base.BaseGet(key) as ScheduledTaskConfigurationElement;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ScheduledTaskConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ScheduledTaskConfigurationElement)element).Name;
        }
    }
}
