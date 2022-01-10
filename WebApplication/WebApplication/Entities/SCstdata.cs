using System;
using System.Collections.Generic;
using da_service.Repositories;

#nullable disable

namespace da_service.Entities
{
    public partial class SCstdata : IEntity
    {
        public SCstdata()
        {
            SCsttemps = new HashSet<SCsttemp>();
        }

        public int CstdataId { get; set; }
        public string UnitName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CastMode { get; set; }
        public double CastWeight { get; set; }
        public double Tph { get; set; }
        public double CastTime { get; set; }
        public double TransTime { get; set; }
        public short Size { get; set; }
        public short Strands { get; set; }
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
        public virtual ICollection<SCsttemp> SCsttemps { get; set; }
    }
}
