using System;

#nullable disable

namespace da_service.Entities
{
    public partial class STemperature
    {
        public int TemperatureId { get; set; }
        public string ProcUnit { get; set; }
        public int HeatNumber { get; set; }
        public DateTime MeasureTime { get; set; }
        public float Value { get; set; }
        public string Type { get; set; }
        public string FileName { get; set; }
        public DateTime ImportTime { get; set; }
    }
}
