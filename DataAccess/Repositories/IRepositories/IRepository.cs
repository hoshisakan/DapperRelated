namespace DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        public List<T> GetAll();
        public T GetFirst();
        public T GetLast();
        public T GetById(int id);
        public T? AddReturnEntity(T entity);
        public int Add(T entity);
        public int AddRange(List<T> entities);
        public int Update(T entity);
        public T? UpdateReturnEntity(T entity);
        public int UpdateRange(List<T> entities);
        public int Delete(T entity);
        public int DeleteRange(List<T> entities);
        public int Delete(int id);
    }
}
