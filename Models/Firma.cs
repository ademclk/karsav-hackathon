namespace enoca.Models
{
    public partial class Firma
    {
        public int Id { get; set; }
        public string FirmaAdi { get; set; } = null!;
        public bool OnayDurumu { get; set; }
        public DateTime SiparisIzinBaslangicTarihi { get; set; }
        public DateTime SiparisIzinBitisTarihi { get; set; }
    }
}
