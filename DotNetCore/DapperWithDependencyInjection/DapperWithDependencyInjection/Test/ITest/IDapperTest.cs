namespace DapperWithDependencyInjection.Test.ITest
{
    public interface IDapperTest
    {
        void TestWriteMessageToLogFile();
        void TestTakeRelatedMethods();
        void TestSkipRelatedMethods();
        void TestTakeAndSkipRelatedMethods();
        void TestIsTableEmpty();
        void TestIsTableExists();
        void TestByCard();
        void TestByPerson();
        void TestSqlRaw();
        void TestByPersonWithUnitWork();
        void TestByCardWhereWithUnitWork();
        void TestByCardWithUnitWork();
    }
}
