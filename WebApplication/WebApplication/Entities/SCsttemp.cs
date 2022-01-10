using System;
using da_service.Repositories;

#nullable disable

namespace da_service.Entities
{
    public partial class SCsttemp : IEntity
    {
        public int CsttempId { get; set; }
        public string CstunitName { get; set; }
        public DateTime MeasureTime { get; set; }
        public float Value { get; set; }
        public int SeqNum { get; set; }
        public double O2ppm { get; set; }
        public string Type { get; set; }
        public int? CstdataId { get; set; }

        public virtual SCstdata Cstdata { get; set; }
    }
}
