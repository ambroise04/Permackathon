namespace Permackathon.DAL.Entities
{
    public class ActivitySite
    {
        public int ActivityId { get; set; }
        public int SiteId { get; set; }
        public Activity Activity { get; set; }
        public Site Site { get; set; }
    }
}