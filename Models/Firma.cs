using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace enoca.Models
{
    public class Firma
    {
        public Guid Id { get; set; }
        public string? FirmaAdi { get; set; }
        public bool OnayDurumu { get; set; }
        public DateTime SiparisIzinBaslangicTarihi { get; set; }
        public DateTime SiparisIzinBitisTarihi { get; set; }

    }
}

