namespace enoca.Models
{
    public class Siparis
    {
        public int Id { get; set; }
        public int FirmaId { get; set; }
        public int UrunId { get; set; }
        public string? SiparisVerenKisiAdi { get; set; }
        public DateTime SiparisTarihi { get; set; }
    }
}
