using System;

#nullable disable

namespace da_service.Entities
{
    public partial class SLadleEvent
    {
        public int LadleEventId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int? LadleEventTypeId { get; set; }
        public int? LadleId { get; set; }
        public int? SpotId { get; set; }

        public virtual SLadle Ladle { get; set; }
        public virtual SLadleEventType LadleEventType { get; set; }
        public virtual SSpot Spot { get; set; }
    }
}
