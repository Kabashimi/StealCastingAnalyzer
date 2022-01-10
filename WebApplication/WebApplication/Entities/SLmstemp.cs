using System;

#nullable disable

namespace da_service.Entities
{
    public partial class SLmstemp
    {
        public int LmstempId { get; set; }
        public string LmsunitName { get; set; }
        public DateTime MeasureTime { get; set; }
        public float Value { get; set; }
        public int SeqNum { get; set; }
        public double O2ppm { get; set; }
        public double C { get; set; }
        public double Al { get; set; }
        public int? LmsdataId { get; set; }

        public virtual SLmsdata Lmsdata { get; set; }
    }
}
