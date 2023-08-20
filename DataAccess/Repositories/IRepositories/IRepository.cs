namespace DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        public List<T> GetAll();
        public T GetFirst();
        public T GetById(int id);
    }
}
