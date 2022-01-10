using System;
using System.Collections.Generic;

#nullable disable

namespace da_service.Entities
{
    public partial class SHeatLineUp
    {
        public SHeatLineUp()
        {
            SHeatHeatLineUps = new HashSet<SHeatHeatLineUp>();
        }

        public int HeatLineUpId { get; set; }
        public string FileName { get; set; }
        public DateTime ImportTime { get; set; }

        public virtual ICollection<SHeatHeatLineUp> SHeatHeatLineUps { get; set; }
    }
}
