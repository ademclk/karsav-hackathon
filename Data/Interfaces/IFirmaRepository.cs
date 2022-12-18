namespace enoca.Data.Interfaces
{
    public interface IFirmaRepository
    {
        Task<List<Firma>> Get();
        Task<int> Post(Firma firma);
        Task<int> Put(Firma firma);
        Task<bool> Delete(int id);
    }
}