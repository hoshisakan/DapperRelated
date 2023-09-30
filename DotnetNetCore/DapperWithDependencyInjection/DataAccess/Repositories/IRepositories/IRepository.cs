using Models.DAO.TestDatabase;
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
        /// <summary>
        /// </summary>
        /// <param name="take"></param>
        /// <returns></returns>
        public List<T> GetTake(int take);
        /// <summary>
        /// </summary>
        /// <param name="take"></param>
        /// <returns></returns>
        public List<T> GetTakeReverse(int take);
        /// <summary>
        /// </summary>
        /// <param name="skip"></param>
        /// <returns></returns>
        public List<T> GetSkip(int skip);
        /// <summary>
        /// </summary>
        /// <param name="skip"></param>
        /// <returns></returns>
        public List<T> GetSkipReverse(int skip);
        /// <summary>
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        public List<T> GetTakeSkip(int take, int skip);
        /// <summary>
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        public List<T> GetTakeSkipReverse(int take, int skip);
        public abstract string GetPrimaryKeyName();
        public abstract T? AddReturnEntity(T entity);
        public abstract int Add(T entity);
        public abstract int AddRange(IEnumerable<T> entities);
        public abstract int Update(T entity);
        public abstract T? UpdateReturnEntity(T entity);
        public abstract int UpdateRange(List<T> entities);
        public abstract int Delete(T entity);
        public abstract int DeleteRange(List<T> entities);
        public bool IsTableExists();
    }
}
