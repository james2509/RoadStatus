using System;
using System.Collections.Generic;
using System.Text;

namespace RoadStatusShared.Model
{
    /// <summary>
    /// Service response with road status info data
    /// </summary>
    public class RoadStatusResponse
    {
        public int ApplicationReturnCode { get; set; }

        public List<string> InfoMessages { get; set; }
    }
}
