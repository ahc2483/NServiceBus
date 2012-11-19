namespace NServiceBus.Scheduling.ServiceTasks.Configuration
{
    using System.Configuration;

    internal class ServiceTaskConfigurationCollection : ConfigurationElementCollection
    {
        new public ServiceTaskConfigurationElement this[string key]
        {
            get
            {
                return base.BaseGet(key) as ServiceTaskConfigurationElement;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ServiceTaskConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ServiceTaskConfigurationElement)element).Name;
        }
    }
}
