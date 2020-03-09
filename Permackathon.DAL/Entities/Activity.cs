using System.Collections.Generic;

namespace Permackathon.DAL.Entities
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Indicator Indicator { get; set; }
        public IList<ActivitySite> ActivitySites { get; set; }
    }
}