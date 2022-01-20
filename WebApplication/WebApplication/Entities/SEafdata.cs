using System;
using System.Collections.Generic;
using da_service.Repositories;

#nullable disable

namespace da_service.Entities
{
    public partial class SEafdata : IEntity
    {
        public SEafdata()
        {
            SEaftemps = new HashSet<SEaftemp>();
        }

        public int EafdataId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double HeatTime { get; set; }
        public int HeatsinLadle { get; set; }
        public double PowerOnTime { get; set; }
        public double DownTime { get; set; }
        public double SchedDownTime { get; set; }
        public double Tph { get; set; }
        public double Mwh { get; set; }
        public double GasTotal { get; set; }
        public double O2total { get; set; }
        public double Ctotal { get; set; }
        public double GrossWt { get; set; }
        public double MetalicWt { get; set; }
        public double TapWt { get; set; }
        public string FileName { get; set; }
        public DateTime ImportTime { get; set; }
        public int? HeatId { get; set; }
        public int HeatNumber { get; set; }
        public int? LadleId { get; set; }
        public int LadleNumber { get; set; }
        public int? ErporderId { get; set; }
        public int ErporderValue { get; set; }
        public int? GradeId { get; set; }
        public string GradeName { get; set; }

        public virtual SErporder Erporder { get; set; }
        public virtual SGrade Grade { get; set; }
        public virtual SHeat Heat { get; set; }
        public virtual SLadle Ladle { get; set; }
        public virtual ICollection<SEaftemp> SEaftemps { get; set; }
    }
}
