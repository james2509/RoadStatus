using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoadStatusShared.Interface;

namespace RoadStatusShared.Service.Builder
{
    /// <summary>
    /// Class to load and return a list of builders
    /// </summary>
    public static class RoadStatusBuilderCreator
    {
        /// <summary>
        /// Get all builders that implement IMessageBuilder interface
        /// </summary>
        /// <returns></returns>
        public static List<IMessageBuilder> CreateBuilders()
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(IMessageBuilder)
                                .IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(t => (IMessageBuilder) Activator.CreateInstance(t))
                .OrderBy(b => b.Order)
                .ToList();
        }
    }
}
