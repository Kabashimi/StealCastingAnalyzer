#nullable disable

namespace da_service.Entities
{
    public partial class SHeatHeatLineUp
    {
        public int HeatLineUpsHeatLineUpId { get; set; }
        public int HeatsHeatId { get; set; }

        public virtual SHeatLineUp HeatLineUpsHeatLineUp { get; set; }
        public virtual SHeat HeatsHeat { get; set; }
    }
}
