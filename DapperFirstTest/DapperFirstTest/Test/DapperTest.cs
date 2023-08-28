using DataAccess.Data;
using DataAccess.Data.IData;
using DataAccess.Repository;
using DataAccess.Repository.IRepository;
using Models.Model;
using System.Data.SqlClient;

namespace DapperFirstTest.Test
{
    public class DapperTest
    {
        private readonly string connectionString;
        private readonly IDbContextInitialize dbContext;
        private readonly SqlConnection cnn;
        private readonly ICardRepository cardRepository;
        private readonly IUnitWork unitWork;


        public DapperTest(string connectionString)
        {
            this.connectionString = connectionString;
            this.dbContext = new DbContextInitialize(this.connectionString);
            this.cnn = dbContext.Initialize();
            this.cnn.Open();
            this.cardRepository = new CardRepository(this.cnn);
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

        public void TestByPersonWithUnitWork()
        {

        }

        public void TestByCardWithUnitWork()
        {
            int cardNumber = 1;
            int stopNumber = (int)Math.Pow(10, 4);
            string[] queryMode = new string[] { "Create", "Update", "Delete", "Select" };
            string currentMode = queryMode[0];

            List<Card> cards = new List<Card>();

            Console.WriteLine($"Test by {nameof(UnitWork)} with {nameof(CardRepository)}");

            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Start testing single add query");

            /// Add
            Card card = new Card()
            {
                Name = $"Card {cardNumber} {currentMode}",
                Description = $"Description {cardNumber} {currentMode}",
                Attack = cardNumber,
                HealthPoint = cardNumber,
                Defense = cardNumber,
                Cost = cardNumber
            };
            unitWork.CardRepository.Add(card);

            Console.WriteLine("End testing single add query");

            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Start testing single update query");

            /// Select
            card = unitWork.CardRepository.GetFirst();

            /// Update
            currentMode = queryMode[1];
            card.Name = $"Card {cardNumber} {currentMode}";
            card.Description = $"Description {cardNumber} {currentMode}";
            card.Attack = cardNumber;
            card.HealthPoint = cardNumber;
            card.Defense = cardNumber;
            card.Cost = cardNumber;
            unitWork.CardRepository.Update(card);

            Console.WriteLine("End testing single update query");

            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Start testing single delete query");

            /// Delete
            unitWork.CardRepository.Delete(card);

            Console.WriteLine("End testing single delete query");

            Console.WriteLine("----------------------------------------");

            /// AddRange
            while (cardNumber < stopNumber)
            {
                card = new Card()
                {
                    Name = $"Card {cardNumber} {currentMode}",
                    Description = $"Description {cardNumber} {currentMode}",
                    Attack = cardNumber,
                    HealthPoint = cardNumber,
                    Defense = cardNumber,
                    Cost = cardNumber
                };
                cards.Add(card);
                cardNumber++;
            }

            Console.WriteLine("Start testing multiple add query");

            unitWork.CardRepository.AddRange(cards);

            Console.WriteLine("End testing multiple add query");

            Console.WriteLine("----------------------------------------");

            cardNumber = 1;

            /// UpdateRange
            List<Card> updateCards = new List<Card>();
            /// Get stopNumber amount of cards from database

            Console.WriteLine("Start testing multiple select query");

            List<Card> oldCards = unitWork.CardRepository.GetTakeSkipReverse(stopNumber, 0);

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

            unitWork.CardRepository.UpdateRange(oldCards);

            Console.WriteLine("End testing multiple update query");

            Console.WriteLine("----------------------------------------");

            //updateCards = unitWork.CardRepository.GetTakeSkipReverse(stopNumber, 0);
            updateCards = unitWork.CardRepository.GetAll();

            Console.WriteLine("Start testing multiple delete query");

            unitWork.CardRepository.DeleteRange(updateCards);

            Console.WriteLine("End testing multiple delete query");

            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Start testing multiple select query");

            cards = unitWork.CardRepository.GetAll();

            Console.WriteLine("End testing multiple select query");

            Console.WriteLine("----------------------------------------");

            Console.WriteLine($"Card count: {cards.Count}");

            Console.WriteLine("----------------------------------------");
        }
    }
}
