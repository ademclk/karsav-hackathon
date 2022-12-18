using System.Data.Entity;
using enoca.Data.Interfaces;

namespace enoca.Data.Repositories;
public class SiparisRepository : ISiparisRepository
{
    public readonly enocaContext _dbContext;
    public SiparisRepository(enocaContext context)
    {
        _dbContext = context;
    }
    public async Task<List<Siparis>> Get()
    {
        var result = await _dbContext.Siparisler.ToListAsync();
        return result;
    }
    public async Task<int> Post(Siparis siparis)
    {
        _dbContext.Siparisler.Add(siparis);
        await _dbContext.SaveChangesAsync();
        return siparis.Id;
    }
    public async Task<int> Put(Siparis siparis)
    {
        var result = await _dbContext.Siparisler.Where(x => x.Id == siparis.Id).FirstOrDefaultAsync();
        result.FirmaId = siparis.FirmaId;
        result.SiparisTarihi = siparis.SiparisTarihi;
        result.SiparisVerenKisiAdi = siparis.SiparisVerenKisiAdi;
        result.UrunId = siparis.UrunId;
        await _dbContext.SaveChangesAsync();
        return siparis.Id;
    }
    public async Task<bool> Delete(int id)
    {
        var result = await _dbContext.Siparisler.Where(x => x.Id == id).FirstOrDefaultAsync();
        _dbContext.Siparisler.Remove(result);
        await _dbContext.SaveChangesAsync();
        return true;
    }

}