using DataAccess.Data;
using DataAccess.Data.IData;
using DataAccess.Repositories;
using DataAccess.Repositories.IRepository;
using Models.DataModel;
using System.Data.SqlClient;

namespace DapperWithDependencyInjection.Test
{
    public class DapperTest
    {
        private readonly string connectionString;
        private readonly IDbContextInitialize dbContext;
        private readonly SqlConnection cnn;
        private readonly IUnitWork unitWork;
        private readonly string[] queryMode = new string[] { "Create", "Update", "Delete", "Select" };


        public DapperTest(string connectionString)
        {
            this.connectionString = connectionString;
            this.dbContext = new DbContextInitialize(this.connectionString);
            this.cnn = dbContext.Initialize();
            this.cnn.Open();
            this.unitWork = new UnitWork(this.cnn);
        }

        //public IAsyncDisposable GetConnection()
        //{
        //    return this.cnn;
        //}

        public void Dispose()
        {
            this.cnn.Close();
            this.cnn.Dispose();
        }

        //public void Test()
        //{
        //    Stopwatch sw = new();
        //    sw.Start();
        //    using (SqlConnection cnn = new(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
        //    {
        //        cnn.Open();
        //        var result = cnn.Query<Person>("SELECT * FROM Person").ToList();
        //        foreach (var item in result)
        //        {
        //            Console.WriteLine($"{item.Id} {item.FirstName} {item.LastName} {item.Age}");
        //        }
        //    }
        //    sw.Stop();
        //    TimeSpan ts = sw.Elapsed;
        //    string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
        //                              ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
        //    Console.WriteLine($"Run time: {elapsedTime}");
        //}

        public void TestByCard()
        {

        }

        public void TestByPerson()
        {

        }

        public void TestSqlRaw()
        {
            Person person;
            List<Person> persons;

            //person = unitWork.PersonRepository.GetFirst();
            //unitWork.PersonRepository.ReadFirst(person);

            //person = unitWork.PersonRepository.GetLast();
            //unitWork.PersonRepository.ReadFirst(person);

            persons = unitWork.PersonRepository.GetTakeReverse(10);
            unitWork.PersonRepository.ReadAll(persons);

            Console.WriteLine("----------------------------------------");

            person = unitWork.PersonRepository.GetById(30000);
            unitWork.PersonRepository.ReadFirst(person);

            Console.WriteLine("----------------------------------------");

            person = unitWork.PersonRepository.GetLast();
            unitWork.PersonRepository.ReadFirst(person);

            Console.WriteLine("----------------------------------------");

            person = unitWork.PersonRepository.GetFirst();
            unitWork.PersonRepository.ReadFirst(person);

            Console.WriteLine("----------------------------------------");
        }

        public void TestByPersonWithUnitWork()
        {
            int objNumber = 1;
            int stopNumber = (int)Math.Pow(10, 4);

            List<Person> persons = new List<Person>();

            Console.WriteLine($"Test by {nameof(UnitWork)} with {nameof(TestCardRepository)}");

            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Start testing single add query");

            /// Add
            Person person = new Person()
            {
                LastName = $"Test {queryMode[0]} LastName {objNumber}",
                FirstName = $"Test {queryMode[0]} FirstName {objNumber}",
                Address = $"Test {queryMode[0]} Address {objNumber}",
                City = $"Test {queryMode[0]} City {objNumber}",
                CreateTime = DateTime.Now
            };
            unitWork.PersonRepository.Add(person);

            Console.WriteLine("End testing single add query");

            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Start testing single update query");

            ///// Update
            ///// 
            //Person oldPerson = unitWork.PersonRepository.GetFirst();

            //oldPerson.LastName = $"Test {queryMode[1]} LastName {oldPerson.PersonId}";
            //oldPerson.FirstName = $"Test {queryMode[1]} FirstName {oldPerson.PersonId}";
            //oldPerson.Address = $"Test {queryMode[1]} Address {oldPerson.PersonId}";
            //oldPerson.City = $"Test {queryMode[1]} City {oldPerson.PersonId}";
            //oldPerson.UpdateTime = DateTime.Now;

            //Console.WriteLine("----------------------------------------");

            //Console.WriteLine("Start testing single delete query");

            ///// Delete
            ///// 
            //Person person1 = unitWork.PersonRepository.GetFirst();

            //unitWork.PersonRepository.Delete(person1);

            //Console.WriteLine("End testing single delete query");

            //Console.WriteLine("----------------------------------------");

            /// AddRange
            while (objNumber < stopNumber)
            {
                person = new Person()
                {
                    LastName = $"Test {queryMode[0]} LastName {objNumber}",
                    FirstName = $"Test {queryMode[0]} FirstName {objNumber}",
                    Address = $"Test {queryMode[0]} Address {objNumber}",
                    City = $"Test {queryMode[0]} City {objNumber}",
                    CreateTime = DateTime.Now
                };
                persons.Add(person);
                objNumber++;
            }

            Console.WriteLine("Start testing multiple add query");

            unitWork.PersonRepository.AddRange(persons);

            Console.WriteLine("End testing multiple add query");

            Console.WriteLine("----------------------------------------");



            //Console.WriteLine("Start testing multiple select query");

            /// Select
            //unitWork.PersonRepository.ReadAll(
            //    unitWork.PersonRepository.GetAll()
            //);

            //int dataCount = unitWork.PersonRepository.GetCount();

            //Console.WriteLine($"Data count: {dataCount}");

            //Console.WriteLine($"End testing multiple select query");

            //Console.WriteLine("----------------------------------------");

            //Console.WriteLine("Start testing multiple update query");

            //List<Person> oldPersons = unitWork.PersonRepository.GetAll();

            //foreach (Person item in oldPersons)
            //{
            //    item.LastName = $"Test {queryMode[1]} LastName {item.PersonId}";
            //    item.FirstName = $"Test {queryMode[1]} FirstName {item.PersonId}";
            //    item.Address = $"Test {queryMode[1]} Address {item.PersonId}";
            //    item.City = $"Test {queryMode[1]} City {item.PersonId}";
            //    item.UpdateTime = DateTime.Now;
            //}

            //unitWork.PersonRepository.UpdateRange(persons);

            //Console.WriteLine("End testing multiple update query");

            //Console.WriteLine("----------------------------------------");

            //Console.WriteLine("Start testing multiple delete query");

            //List<Person> removePeopleList = unitWork.PersonRepository.GetAll();

            //unitWork.PersonRepository.DeleteRange(removePeopleList);

            //Console.WriteLine("End testing multiple delete query");

            //Console.WriteLine("----------------------------------------");
        }

        public void TestByCardWhereWithUnitWork()
        {
            List<int> ids = new List<int>();

            ids = unitWork.TestCardRepository.GetWhere(x => x.Id == 60003).Select(x => x.Id).ToList();

            foreach (int item in ids)
            {
                Console.WriteLine(item);
            }
        }

        public void TestByCardWithUnitWork()
        {
            int cardNumber = 1;
            int stopNumber = (int)Math.Pow(10, 4);
            string[] queryMode = new string[] { "Create", "Update", "Delete", "Select" };
            string currentMode = queryMode[0];

            List<TestCard> cards = new List<TestCard>();

            Console.WriteLine($"Test by {nameof(UnitWork)} with {nameof(TestCardRepository)}");

            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Start testing single add query");

            /// Add
            TestCard card = new TestCard()
            {
                Name = $"Card {cardNumber} {currentMode}",
                Description = $"Description {cardNumber} {currentMode}",
                Attack = cardNumber,
                HealthPoint = cardNumber,
                Defense = cardNumber,
                Cost = cardNumber,
                CreatedTime = DateTime.Now
            };
            unitWork.TestCardRepository.Add(card);

            Console.WriteLine("End testing single add query");

            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Start testing single update query");

            /// Select
            card = unitWork.TestCardRepository.GetFirst();

            /// Update
            currentMode = queryMode[1];
            card.Name = $"Card {cardNumber} {currentMode}";
            card.Description = $"Description {cardNumber} {currentMode}";
            card.Attack = cardNumber;
            card.HealthPoint = cardNumber;
            card.Defense = cardNumber;
            card.Cost = cardNumber;
            unitWork.TestCardRepository.Update(card);

            Console.WriteLine("End testing single update query");

            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Start testing single delete query");

            /// Delete
            unitWork.TestCardRepository.Delete(card);

            Console.WriteLine("End testing single delete query");

            Console.WriteLine("----------------------------------------");

            currentMode = queryMode[0];

            /// AddRange
            while (cardNumber < stopNumber)
            {
                card = new TestCard()
                {
                    Name = $"Card {cardNumber} {currentMode}",
                    Description = $"Description {cardNumber} {currentMode}",
                    Attack = cardNumber,
                    HealthPoint = cardNumber,
                    Defense = cardNumber,
                    Cost = cardNumber,
                    CreatedTime = DateTime.Now
                };
                cards.Add(card);
                cardNumber++;
            }

            Console.WriteLine("Start testing multiple add query");

            unitWork.TestCardRepository.AddRange(cards);

            Console.WriteLine("End testing multiple add query");

            Console.WriteLine("----------------------------------------");

            cardNumber = 1;

            /// UpdateRange
            List<TestCard> updateCards = new List<TestCard>();
            /// Get stopNumber amount of cards from database

            Console.WriteLine("Start testing multiple select query");

            List<TestCard> oldCards = unitWork.TestCardRepository.GetTakeSkipReverse(stopNumber, 0);

            Console.WriteLine("End testing multiple select query");

            Console.WriteLine("----------------------------------------");

            while (cardNumber < stopNumber)
            {
                oldCards[0].Name = $"Card {cardNumber} {currentMode}";
                oldCards[0].Description = $"Description {cardNumber} {currentMode}";
                oldCards[0].Attack = cardNumber;
                oldCards[0].HealthPoint = cardNumber;
                oldCards[0].Defense = cardNumber;
                oldCards[0].Cost = cardNumber;
                cardNumber++;
            }

            Console.WriteLine("Start testing multiple update query");

            unitWork.TestCardRepository.UpdateRange(oldCards);

            Console.WriteLine("End testing multiple update query");

            Console.WriteLine("----------------------------------------");

            //updateCards = unitWork.TestCardRepository.GetTakeSkipReverse(stopNumber, 0);
            updateCards = unitWork.TestCardRepository.GetAll();

            Console.WriteLine("Start testing multiple delete query");

            unitWork.TestCardRepository.DeleteRange(updateCards);

            Console.WriteLine("End testing multiple delete query");

            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Start testing multiple select query");

            cards = unitWork.TestCardRepository.GetAll();

            Console.WriteLine("End testing multiple select query");

            Console.WriteLine("----------------------------------------");

            Console.WriteLine($"Card count: {cards.Count}");

            Console.WriteLine("----------------------------------------");
        }
    }
}
