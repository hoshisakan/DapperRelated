using System.Linq.Expressions;

namespace DataAccess.Repositories.IRepositories
{
    public interface IRepository<T> where T : class
    {
        public List<T> GetAll();
        public IQueryable GetAllOri();
        public T? GetFirstOrDefault(Expression<Func<T, bool>> predicate);
        public T GetFirst();
        public T GetLast();
        public T GetById(int id);
        public int GetCount();
        public List<T> GetWhere(Expression<Func<T, bool>> predicate);
        public List<T> GetTake(int take);
        public List<T> GetTakeReverse(int take);
        public string GetPrimaryKeyName();
        public T? AddReturnEntity(T entity);
        public int Add(T entity);
        public int AddRange(IEnumerable<T> entities);
        public int AddOrUpdate(T entity);
        public int Update(T entity);
        public T? UpdateReturnEntity(T entity);
        public int UpdateRange(List<T> entities);
        public int Delete(T entity);
        public int DeleteRange(List<T> entities);
    }
}
