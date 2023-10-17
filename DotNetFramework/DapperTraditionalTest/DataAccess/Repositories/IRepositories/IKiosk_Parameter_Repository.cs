using DataAccess.Repositories.IRepository;
using Models.Entity.NEC.Test;
using System.Linq.Expressions;

namespace DataAccess.Repositories.IRepositories
{
    public interface IKiosk_Parameter_Repository : IRepository<Kiosk_Parameter>
    {
        public string GetKiosk_ParameterValue(string name);
        public string GetKiosk_ParameterValue(int sn);
        List<Kiosk_Parameter> GetKiosk_ParameterByKeys(string[] keys);
        public void SetKiosk_ParameterValue(string name, string value);
        public void SetKiosk_ParameterValue(int sn, string name, string value);
        public void SetOrUpdateKiosk_ParameterValue(string name, string value);
        public void SetOrUpdateKiosk_ParameterValue(int sn, string name, string value);
        /// <summary>
        /// Because Kiosk_Parameter table of local database is not the same as Kiosk_Parameter table of server database, both of them have different auto increment sn. So, we need to set sn manually.
        /// </summary>
        /// <param name="isTestMode"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetOrUpdateKiosk_ParameterValue(string name, string value, bool isTestMode = false);
        public void UpdateKiosk_ParameterValue(string name, string value);
        public void UpdateKiosk_ParameterValue(int sn, string value);
        public void DeleteKiosk_ParameterValue(string name);
        public void DeleteKiosk_ParameterValue(int sn);
        public void DeleteKiosk_ParameterValue(List<string> names);
        public void DeleteKiosk_ParameterValue(List<int> sns);
        public void DeleteKiosk_ParameterValue(List<Kiosk_Parameter> kiosk_Parameters);
        public void DeleteKiosk_ParameterValue(Kiosk_Parameter kiosk_Parameter);
        public void DeleteKiosk_ParameterValue(Expression<Func<Kiosk_Parameter, bool>> predicate);
        //public void DeleteKiosk_ParameterValue(Expression<Func<Kiosk_Parameter, bool>> predicate, List<Kiosk_Parameter> kiosk_Parameters);
        //public void DeleteKiosk_ParameterValue(Expression<Func<Kiosk_Parameter, bool>> predicate, List<string> names);
        //public void DeleteKiosk_ParameterValue(Expression<Func<Kiosk_Parameter, bool>> predicate, List<int> sns);
        //public void DeleteKiosk_ParameterValue(Expression<Func<Kiosk_Parameter, bool>> predicate, Kiosk_Parameter kiosk_Parameter);
        //public void DeleteKiosk_ParameterValue(Expression<Func<Kiosk_Parameter, bool>> predicate, string name);
        //public void DeleteKiosk_ParameterValue(Expression<Func<Kiosk_Parameter, bool>> predicate, int sn);
    }
}
