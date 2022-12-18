namespace enoca.Data.Interfaces
{
    public interface IUrunRepository
    {
        Task<List<Urun>> Get();
        Task<int> Post(Urun urun);
        Task<int> Put(Urun urun);
        Task<bool> Delete(int id);
    }
}