using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperWithDependencyInjection.Test.ITest
{
    public interface IDapperTest
    {
        void TestByCard();
        void TestByPerson();
        void TestSqlRaw();
        void TestByPersonWithUnitWork();
        void TestByCardWhereWithUnitWork();
        void TestByCardWithUnitWork();
    }
}
