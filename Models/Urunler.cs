using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace enoca.Models
{
    public class Urunler
    {
        public Guid Id { get; set; }
        public int FirmaId { get; set; }
        public string? UrunAdi { get; set; }
        public int Stok { get; set; }
        public decimal Fiyat { get; set; }

    }
}
