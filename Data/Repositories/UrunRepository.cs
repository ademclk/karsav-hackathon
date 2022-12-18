using System.Data.Entity;
using enoca.Data.Interfaces;

namespace enoca.Data.Repositories;

public class UrunRepository : IUrunRepository
{
    public readonly enocaContext _dbContext;
    public UrunRepository(enocaContext context)
    {
        _dbContext = context;
    }
    public async Task<List<Urun>> Get()
    {
        var result = await _dbContext.Urunler.ToListAsync();
        return result;
    }
    public async Task<int> Post(Urun urun)
    {
        _dbContext.Urunler.Add(urun);
        await _dbContext.SaveChangesAsync();
        return urun.Id;
    }
    public async Task<int> Put(Urun urun)
    {
        var result = await _dbContext.Urunler.Where(x => x.Id == urun.Id).FirstOrDefaultAsync();
        result.FirmaId = urun.FirmaId;
        result.UrunAdi = urun.UrunAdi;
        result.Stok = urun.Stok;
        result.Fiyat = urun.Fiyat;
        await _dbContext.SaveChangesAsync();
        return urun.Id;
    }
    public async Task<bool> Delete(int id)
    {
        var result = await _dbContext.Urunler.Where(x => x.Id == id).FirstOrDefaultAsync();
        _dbContext.Urunler.Remove(result);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}