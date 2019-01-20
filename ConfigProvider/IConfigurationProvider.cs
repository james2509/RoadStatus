using System;
using System.Collections.Generic;
using System.Text;

namespace ConfigProvider
{
    /// <summary>
    /// Interface to provide configuration from implemented configuration data sources
    /// </summary>
    public interface IConfigurationProvider
    {
        Configuration GetConfiguration();
    }
}
