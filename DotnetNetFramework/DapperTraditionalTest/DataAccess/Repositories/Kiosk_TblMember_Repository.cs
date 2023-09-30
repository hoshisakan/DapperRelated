using DataAccess.Repositories.IRepositories;
using Models.DAO.NEC.Test;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class Kiosk_TblMember_Repository : Repository<Kiosk_tblMember>, IKiosk_TblMember_Repository
    {
        public Kiosk_TblMember_Repository(SqlConnection cnn) : base(cnn)
        {
        }
    }
}
