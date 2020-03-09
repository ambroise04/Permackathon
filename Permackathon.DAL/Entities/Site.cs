using System.Collections.Generic;

namespace Permackathon.DAL.Entities
{
    public class Site
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public City City { get; set; }
        public IList<ActivitySite> ActivitySites { get; set; }
    }
}