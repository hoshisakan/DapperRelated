using System.Linq.Expressions;

namespace DataAccess.Repositories.IRepository
{
    public interface IRepository<T> where T : class
    {
        public abstract List<T> GetAll();
        public abstract T? GetFirstOrDefault(Expression<Func<T, bool>> predicate);
        public abstract T GetFirst();
        public abstract T GetLast();
        public abstract T GetById(int id);
        public abstract int GetCount();
        public abstract List<T> GetWhere(Expression<Func<T, bool>> predicate);
        public abstract List<T> GetTake(int take);
        public abstract List<T> GetTakeReverse(int take);
        public abstract string GetPrimaryKeyName();
        public abstract T? AddReturnEntity(T entity);
        public abstract int Add(T entity);
        public abstract int AddRange(IEnumerable<T> entities);
        public abstract int Update(T entity);
        public abstract T? UpdateReturnEntity(T entity);
        public abstract int UpdateRange(List<T> entities);
        public abstract int Delete(T entity);
        public abstract int DeleteRange(List<T> entities);
    }
}
