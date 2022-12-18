using Microsoft.EntityFrameworkCore;
using enoca.Data.Interfaces;

namespace enoca.Data.Repositories;
public class FirmaRepository : IFirmaRepository
{
    public readonly enocaContext _dbContext;
    public FirmaRepository(enocaContext context)
    {
        _dbContext = context;
    }
    public async Task<List<Firma>> Get()
    {
        var result = await _dbContext.Firmalar.ToListAsync();
        return result;
    }
    public async Task<int> Post(Firma firma)
    {
        _dbContext.Firmalar.Add(firma);
        await _dbContext.SaveChangesAsync();
        return firma.Id;
    }
    public async Task<int> Put(Firma firma)
    {
        var result = await _dbContext.Firmalar.Where(x => x.Id == firma.Id).FirstOrDefaultAsync();
        result!.SiparisIzinBaslangicTarihi = firma.SiparisIzinBaslangicTarihi;
        result.SiparisIzinBitisTarihi = firma.SiparisIzinBitisTarihi;
        result.OnayDurumu = firma.OnayDurumu;
        await _dbContext.SaveChangesAsync();
        return firma.Id;
    }
    public async Task<bool> Delete(int id)
    {
        var result = await _dbContext.Firmalar.Where(x => x.Id == id).FirstOrDefaultAsync();
        _dbContext.Firmalar.Remove(result!);
        await _dbContext.SaveChangesAsync();
        return true;
    }

}
