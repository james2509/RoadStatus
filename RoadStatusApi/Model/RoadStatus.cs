using System;
using System.Collections.Generic;
using System.Text;

namespace RoadStatusApi.Model
{
    /// <summary>
    /// Class to hold data related to the status of a road returned
    /// from a third party api.
    /// </summary>
    public sealed class RoadStatus
    {
        public string DisplayName { get; set; }

        public string StatusSeverity { get; set; }

        public string StatusSeverityDescription { get; set; }

        public bool RoadFound { get; set; }
    }
}
