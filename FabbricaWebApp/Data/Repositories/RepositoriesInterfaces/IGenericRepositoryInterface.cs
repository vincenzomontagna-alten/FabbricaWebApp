namespace FabbricaWebApp.Data.Repositories.RepositoriesInterfaces
{
    public interface IGenericRepositoryInterface<T>
    {
        public List<T> GetAll();
        public T? GetById(int id);
        public void Add(T prodotto);
        public void Update(T prodotto);
        public void Delete(int id);

    }
}
