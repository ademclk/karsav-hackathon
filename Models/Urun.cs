namespace enoca.Models
{
    public class Urun
    {
        public int Id { get; set; }
        public int FirmaId { get; set; }
        public string? UrunAdi { get; set; }
        public int Stok { get; set; }
        public float Fiyat { get; set; }
    }
}
