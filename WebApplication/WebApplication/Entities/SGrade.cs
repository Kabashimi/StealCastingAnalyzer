using System.Collections.Generic;
using da_service.Repositories;

#nullable disable

namespace da_service.Entities
{
    public partial class SGrade : IEntity
    {
        public SGrade()
        {
            SCstdata = new HashSet<SCstdata>();
            SEafdata = new HashSet<SEafdata>();
            SHeats = new HashSet<SHeat>();
            SLmsdata = new HashSet<SLmsdata>();
        }

        public int GradeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SCstdata> SCstdata { get; set; }
        public virtual ICollection<SEafdata> SEafdata { get; set; }
        public virtual ICollection<SHeat> SHeats { get; set; }
        public virtual ICollection<SLmsdata> SLmsdata { get; set; }
    }
}
