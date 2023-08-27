// See https://aka.ms/new-console-template for more information

using DataAccess.Data;
using DataAccess.Data.IData;
using DataAccess.Repository;
using Models.Model;
using System.Data.SqlClient;
using System.Diagnostics;

Console.WriteLine("Hello, World!");

Dictionary<string, string> connectionStringDict = new Dictionary<string, string>()
{
    {"localhost", "Server=localhost;User ID=sa;Password=2wsx1qaz`;Database=TestDatabase;Encrypt=false"}
};

try
{
    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();

    IDbContextInitialize dbContext = new DbContextInitialize(connectionStringDict["localhost"]);

    SqlConnection cnn = dbContext.Initialize();

    cnn.Open();

    string clientConnectionId = cnn.ClientConnectionId.ToString();

    Console.WriteLine($"Connection ID: {clientConnectionId}");

    UnitWork unitWork = new UnitWork(cnn);

    //List<Card> cards = unitWork.CardRepository.GetAll();

    //CardRepository cardRepository = new CardRepository(cnn);

    //List<Card> cards = cardRepository.GetAll();

    //Console.WriteLine($"Number of cards: {cards.Count}");

    int cardNumber = 1;
    //int stopNumber = (int)Math.Pow(5, 8);
    int stopNumber = (int)Math.Pow(10, 2);

    Dictionary<string, string> queryMode = new Dictionary<string, string>()
    {
        {"Add", "Create"},
        {"Update", "Update"}
    };
    string currentMode = "Add";
    //string currentMode = "Update";

    //int result = unitWork.CardRepository.Delete(99999);
    //Console.WriteLine($"Delete result: {result}");

    //List<Card> allCards = new List<Card>();

    //allCards = unitWork.CardRepository.GetAll();

    //Console.WriteLine($"Number of cards: {allCards.Count}");

    Card? oldData = new Card();
    Card? newData = new Card();
    Card? editData = new Card();

    List<Card> bulkInsertTestCards = new List<Card>();
    List<Card> bulkUpdateTestCards = new List<Card>();

    while (cardNumber <= stopNumber)
    {
        Card card = new Card()
        {
            Name = $"Card {cardNumber} {queryMode[currentMode]}",
            Description = $"Description {cardNumber} {queryMode[currentMode]}",
            Attack = cardNumber,
            HealthPoint = cardNumber,
            Defense = cardNumber,
            Cost = cardNumber
        };

        /// For bulk insert test
        bulkInsertTestCards.Add(card);

        /// The following code is for testing add, update, delete
        //newData = unitWork.CardRepository.AddReturnEntity(card);

        //if (newData == null)
        //{
        //    Console.WriteLine($"Add card {cardNumber} not found");
        //    cardNumber++;
        //    continue;
        //}
        //else
        //{
        //    Console.WriteLine($"Add card {newData.Id} success");
        //}

        //unitWork.CardRepository.ReadFirst(newData);

        //currentMode = "Update";

        //oldData = unitWork.CardRepository.GetById(newData.Id);

        //if (oldData == null)
        //{
        //    Console.WriteLine($"Old card {newData.Id} not found, not allow to execute update query.");
        //    cardNumber++;
        //    continue;
        //}

        //oldData.Name = $"Card {cardNumber} {queryMode[currentMode]}";
        //oldData.Description = $"Description {cardNumber} {queryMode[currentMode]}";
        //oldData.Attack = cardNumber;
        //oldData.HealthPoint = cardNumber;
        //oldData.Defense = cardNumber;
        //oldData.Cost = cardNumber;

        //editData = unitWork.CardRepository.UpdateReturnEntity(oldData);

        //if (editData == null)
        //{
        //    Console.WriteLine($"Update card {oldData.Id} not found");
        //    cardNumber++;
        //    continue;
        //}
        //else
        //{
        //    Console.WriteLine($"Update card {oldData.Id} success");
        //}

        //unitWork.CardRepository.ReadFirst(editData);

        //int deleteResult = unitWork.CardRepository.Delete(editData);

        //if (deleteResult == -1)
        //{
        //    Console.WriteLine($"Delete card {editData.Id} not found");
        //}
        //else
        //{
        //    Console.WriteLine($"Delete card {editData.Id} success");
        //}

        //oldData = new Card();
        //newData = new Card();
        //editData = new Card();

        //currentMode = "Add";

        //Console.WriteLine("--------------------------------------------------");

        //Console.WriteLine($"Card {cardNumber} {queryMode[currentMode]} success");

        cardNumber++;
    }

    int bulkInsertResult = unitWork.CardRepository.AddRange(bulkInsertTestCards);

    Console.WriteLine($"Bulk insert result: {bulkInsertResult}");

    bulkUpdateTestCards = unitWork.CardRepository.GetTakeReverse(stopNumber);

    Console.WriteLine($"Number of cards: {bulkUpdateTestCards.Count}");

    foreach (Card edit in bulkUpdateTestCards)
    {
        edit.Name = $"Card {edit.Id} {queryMode["Update"]}";
        edit.Description = $"Description {edit.Id} {queryMode["Update"]}";
        edit.Attack = edit.Id;
        edit.HealthPoint = edit.Id;
        edit.Defense = edit.Id;
        edit.Cost = edit.Id;
    }

    int bulkUpdateResult = unitWork.CardRepository.UpdateRange(bulkUpdateTestCards);

    Console.WriteLine($"Bulk update result: {bulkUpdateResult}");


    //allCards = unitWork.CardRepository.GetAll();

    //Console.WriteLine($"Number of cards: {allCards.Count}");

    cnn.Close();

    stopWatch.Stop();

    TimeSpan ts = stopWatch.Elapsed;

    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
               ts.Hours, ts.Minutes, ts.Seconds,
                      ts.Milliseconds / 10);

    Console.WriteLine($"Run time: {elapsedTime}");
}
catch (Exception ex)
{
    Console.WriteLine($"Message: {ex.Message}\nStacktrace: {ex.StackTrace}");
}