# karsav-hackathon

### Firma ekleme için kullanılması gereken : POST: /api/Firma
```
{
  "id": 0,
  "firmaAdi": "FİRMA ADI",
  "onayDurumu": true,
  "siparisIzinBaslangicTarihi": "TARİH",
  "siparisIzinBitisTarihi": "TARİH"
}
```

### Firma güncelleme için kullanılması gereken : PUT: /api/Firma
```
{
  "id": 0,
  "firmaAdi": "FİRMA ADI",
  "onayDurumu": true,
  "siparisIzinBaslangicTarihi": "TARİH",
  "siparisIzinBitisTarihi": "TARİH"
}
```
### Ürün ekleme için kullanılması gereken : POST : /api/Urun
```
{
  "id": 0,
  "firmaId": 0,
  "urunAdi": "ÜRÜN ADI",
  "stok": 0,
  "fiyat": 0
}
```

### Sipariş oluşturma kısmı için : If ve throw ifadeleri (try catch blokları ilgili controllera eklenmiştir.) 
```
public async Task<int> Post(Siparis siparis)
    {
        var firma = await _dbContext.Firmalar.Where(x => x.Id == siparis.FirmaId).FirstOrDefaultAsync();
        if (firma!.OnayDurumu == false)
        {
            throw new Exception("Onaylanmayan firmalar sipariş oluşturmaz.");
        }
        if (siparis.SiparisTarihi.TimeOfDay < new TimeSpan(8, 30, 0) || siparis.SiparisTarihi.TimeOfDay > new TimeSpan(11, 0, 0))
        {
            throw new Exception("Siparişler 8:30 - 11:00 arasında oluşturulabilir.");
        }
        _dbContext.Siparisler.Add(siparis);
        await _dbContext.SaveChangesAsync();
        return siparis.Id;
    }
```
    
