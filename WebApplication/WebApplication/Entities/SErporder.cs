using System.Collections.Generic;

#nullable disable

namespace da_service.Entities
{
    public partial class SErporder
    {
        public SErporder()
        {
            SCstdata = new HashSet<SCstdata>();
            SEafdata = new HashSet<SEafdata>();
            SHeats = new HashSet<SHeat>();
            SLmsdata = new HashSet<SLmsdata>();
        }

        public int ErporderId { get; set; }
        public int Value { get; set; }

        public virtual ICollection<SCstdata> SCstdata { get; set; }
        public virtual ICollection<SEafdata> SEafdata { get; set; }
        public virtual ICollection<SHeat> SHeats { get; set; }
        public virtual ICollection<SLmsdata> SLmsdata { get; set; }
    }
}
