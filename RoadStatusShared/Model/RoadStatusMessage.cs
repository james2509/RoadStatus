using System;
using System.Collections.Generic;
using System.Text;

namespace RoadStatusShared.Model
{
    /// <summary>
    /// Hold Road Status Message data
    /// </summary>
    public class RoadStatusMessage
    {
        public bool IsError { get; set; }

        public string Message { get; set; }
    }
}
