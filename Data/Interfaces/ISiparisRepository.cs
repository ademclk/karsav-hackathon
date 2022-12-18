namespace enoca.Data.Interfaces
{
    public interface ISiparisRepository
    {
        Task<List<Siparis>> Get();
        Task<int> Post(Siparis siparis);
        Task<int> Put(Siparis siparis);
        Task<bool> Delete(int id);
    }
}