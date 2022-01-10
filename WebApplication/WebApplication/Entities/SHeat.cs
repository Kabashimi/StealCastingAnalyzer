using System;
using System.Collections.Generic;
using da_service.Repositories;

#nullable disable

namespace da_service.Entities
{
    public partial class SHeat : IEntity
    {
        public SHeat()
        {
            SCstdata = new HashSet<SCstdata>();
            SEafdata = new HashSet<SEafdata>();
            SHeatHeatLineUps = new HashSet<SHeatHeatLineUp>();
            SLmsdata = new HashSet<SLmsdata>();
        }

        public int HeatId { get; set; }
        public int HeatNumber { get; set; }
        public int? ErporderId { get; set; }
        public string Type { get; set; }
        public int? GradeId { get; set; }
        public short Size { get; set; }
        public short Weight { get; set; }
        public short Plan { get; set; }
        public string Destination { get; set; }
        public double InventoryCastWeight { get; set; }
        public DateTime? InvUpdateTime { get; set; }
        public string InvFilename { get; set; }
        public DateTime? ModificationTimestamp { get; set; }

        public virtual SErporder Erporder { get; set; }
        public virtual SGrade Grade { get; set; }
        public virtual ICollection<SCstdata> SCstdata { get; set; }
        public virtual ICollection<SEafdata> SEafdata { get; set; }
        public virtual ICollection<SHeatHeatLineUp> SHeatHeatLineUps { get; set; }
        public virtual ICollection<SLmsdata> SLmsdata { get; set; }
    }
}
