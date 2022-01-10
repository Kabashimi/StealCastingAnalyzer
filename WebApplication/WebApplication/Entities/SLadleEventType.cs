using System.Collections.Generic;

#nullable disable

namespace da_service.Entities
{
    public partial class SLadleEventType
    {
        public SLadleEventType()
        {
            SLadleEvents = new HashSet<SLadleEvent>();
        }

        public int LadleEventTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SLadleEvent> SLadleEvents { get; set; }
    }
}
