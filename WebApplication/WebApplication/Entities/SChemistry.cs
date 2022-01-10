#nullable disable

namespace da_service.Entities
{
    public partial class SChemistry
    {
        public int ChemistryId { get; set; }
        public string Sample { get; set; }
        public double C { get; set; }
        public double Mn { get; set; }
        public double Si { get; set; }
        public double P { get; set; }
        public double S { get; set; }
        public double Cr { get; set; }
        public double Ni { get; set; }
        public double Cu { get; set; }
        public double Al { get; set; }
        public double Mo { get; set; }
        public double Sn { get; set; }
        public double V { get; set; }
        public double Ti { get; set; }
        public double Nb { get; set; }
        public double B { get; set; }
        public double Zn { get; set; }
        public double N { get; set; }
        public double Pb { get; set; }
        public double Ca { get; set; }
        public double As { get; set; }
        public double Zr { get; set; }
        public double Sb { get; set; }
        public double Ce { get; set; }
        public double CaAl { get; set; }
        public double AlMetAl { get; set; }
        public double MnS { get; set; }
        public double Liquidus { get; set; }
        public double Cu8Sn5Al { get; set; }
        public double ChargeNo { get; set; }
        public int? LmsdataId { get; set; }

        public virtual SLmsdata Lmsdata { get; set; }
    }
}
