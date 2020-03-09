namespace Permackathon.DAL.Entities
{
    public class ActivitySite
    {
        public int ActivityId { get; set; }
        public int CityId { get; set; }
        public Activity Activity { get; set; }
        public City City { get; set; }
    }
}