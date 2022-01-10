using System;
using System.Collections.Generic;

#nullable disable

namespace da_service.Entities
{
    public partial class SLmsdata
    {
        public SLmsdata()
        {
            SChemistries = new HashSet<SChemistry>();
            SLmstemps = new HashSet<SLmstemp>();
        }

        public int LmsdataId { get; set; }
        public int Process { get; set; }
        public string UnitName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double HeatTime { get; set; }
        public double PowerOnTime { get; set; }
        public double DownTime { get; set; }
        public double StirrOnTime { get; set; }
        public int StirrOnVolume { get; set; }
        public double TransTime { get; set; }
        public double Mwh { get; set; }
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
        public virtual ICollection<SChemistry> SChemistries { get; set; }
        public virtual ICollection<SLmstemp> SLmstemps { get; set; }
    }
}
