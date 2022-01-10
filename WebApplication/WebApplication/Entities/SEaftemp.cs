using System;

#nullable disable

namespace da_service.Entities
{
    public partial class SEaftemp
    {
        public int EaftempId { get; set; }
        public DateTime MeasureTime { get; set; }
        public float Value { get; set; }
        public int SeqNum { get; set; }
        public double O2ppm { get; set; }
        public double C { get; set; }
        public double Al { get; set; }
        public int? EafdataId { get; set; }

        public virtual SEafdata Eafdata { get; set; }
    }
}
