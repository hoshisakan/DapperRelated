using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.IData
{
    public interface IDapperConnectionProvider
    {
        public IDbConnection Connect();
        public void Dispose();
        public void Dispose(bool disposing);
    }
}
