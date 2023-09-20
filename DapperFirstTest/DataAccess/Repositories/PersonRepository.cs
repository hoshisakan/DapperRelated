using Dapper;
using DataAccess.Repositories.IRepositories;
using DataAccess.Repositories;
using Models.DataModel;
using System.Data.SqlClient;


namespace DataAccess.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(SqlConnection cnn) : base(cnn)
        {
            this.cnn = cnn;
        }

        private readonly SqlConnection cnn;

        public void ReadAll(List<Person> persons)
        {
            if (persons != null)
            {
                foreach (var person in persons)
                {
                    Console.WriteLine(
                        $"PersonId: {person.PersonId},LastName: {person.LastName},FirstName: {person.FirstName}" +
                        $",Address: {person.Address},City: {person.City},CreateTime: {person.CreateTime}" +
                        $",UpdateTime: {person.UpdateTime}"
                    );
                }
            }
            else
            {
                Console.WriteLine("No data");
            }
        }

        public void ReadFirst(Person person)
        {
            if (person != null)
            {
                Console.WriteLine(
                    $"PersonId: {person.PersonId},LastName: {person.LastName},FirstName: {person.FirstName}" +
                    $",Address: {person.Address},City: {person.City},CreateTime: {person.CreateTime}" +
                    $",UpdateTime: {person.UpdateTime}"
                );
            }
            else
            {
                Console.WriteLine("No data");
            }
        }

        /// <summary>
        /// The method GetTake() add new for hide that base method
        /// </summary>
        /// <param name="skip"></param>
        /// <returns></returns>
        //public new List<Person> GetTake(int take)
        //{
        //    return this.cnn.Query<Person>($"SELECT TOP {take} * FROM Person").ToList();
        //}

        /// <summary>
        /// The method GetTakeReverse() add new for hide that base method
        /// </summary>
        /// <param name="skip"></param>
        /// <returns></returns>
        //public new List<Person> GetTakeReverse(int take)
        //{
        //    return this.cnn.Query<Person>($"SELECT TOP {take} * FROM Person ORDER BY Id DESC").ToList();
        //}

        public List<Person> GetSkip(int skip)
        {
            return this.cnn.Query<Person>($"SELECT * FROM Person ORDER BY Id ASC OFFSET {skip} ROWS").ToList();
        }

        public List<Person> GetSkipReverse(int skip)
        {
            return this.cnn.Query<Person>($"SELECT * FROM Person ORDER BY Id DESC OFFSET {skip} ROWS").ToList();
        }

        public List<Person> GetTakeSkip(int take, int skip)
        {
            return this.cnn.Query<Person>(
                $"SELECT * FROM Person ORDER BY Id ASC OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY"
            ).ToList();
        }

        public List<Person> GetTakeSkipReverse(int take, int skip)
        {
            return this.cnn.Query<Person>(
                $"SELECT * FROM Person ORDER BY Id DESC OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY"
            ).ToList();
        }
    }
}
