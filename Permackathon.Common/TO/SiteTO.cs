using System.Collections.Generic;

namespace Permackathon.Common.TO
{
    public class SiteTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public CityTO City { get; set; }
        public IList<ActivityTO> Activities { get; set; }
    }
}