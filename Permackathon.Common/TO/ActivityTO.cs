using System.Collections.Generic;

namespace Permackathon.Common.TO
{
    public class ActivityTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IndicatorTO Indicator { get; set; }
        public IList<SiteTO> Sites { get; set; }
    }
}