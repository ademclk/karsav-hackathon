﻿using System.ComponentModel.DataAnnotations.Schema;

namespace enoca.Models
{
    public class Siparis
    {
        public Guid Id { get; set; }
        public int FirmaId { get; set; }
        public Firma? Firma { get; set; }
        public int UrunId { get; set; }
        public string? SiparisVerenKisiAdi { get; set; }
        public DateTime SiparisTarihi { get; set; }

    }
}
