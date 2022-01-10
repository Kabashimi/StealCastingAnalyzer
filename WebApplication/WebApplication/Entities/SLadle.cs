using System.Collections.Generic;

#nullable disable

namespace da_service.Entities
{
    public partial class SLadle
    {
        public SLadle()
        {
            SCstdata = new HashSet<SCstdata>();
            SEafdata = new HashSet<SEafdata>();
            SLadleEvents = new HashSet<SLadleEvent>();
            SLmsdata = new HashSet<SLmsdata>();
        }

        public int LadleId { get; set; }
        public int Number { get; set; }

        public virtual ICollection<SCstdata> SCstdata { get; set; }
        public virtual ICollection<SEafdata> SEafdata { get; set; }
        public virtual ICollection<SLadleEvent> SLadleEvents { get; set; }
        public virtual ICollection<SLmsdata> SLmsdata { get; set; }
    }
}
