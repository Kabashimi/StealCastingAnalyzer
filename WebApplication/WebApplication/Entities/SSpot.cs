using System.Collections.Generic;

#nullable disable

namespace da_service.Entities
{
    public partial class SSpot
    {
        public SSpot()
        {
            SLadleEvents = new HashSet<SLadleEvent>();
        }

        public int SpotId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SLadleEvent> SLadleEvents { get; set; }
    }
}
