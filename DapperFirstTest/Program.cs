// See https://aka.ms/new-console-template for more information

using DataAccess.Data;
using DataAccess.Data.IData;
using DataAccess.Repository;
using Models.Model;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

Dictionary<string, string> connectionStringDict = new Dictionary<string, string>()
{
    {"localhost", "Server=localhost;User ID=sa;Password=2wsx1qaz`;Database=TestDatabase;Encrypt=false"}
};

try
{
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

    int cardNumber = 64;

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

    while (cardNumber <= 100)
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

        newData = unitWork.CardRepository.AddReturnEntity(card);

        if (newData == null)
        {
            Console.WriteLine($"Add card {cardNumber} not found");
            cardNumber++;
            continue;
        }

        Console.WriteLine($"newData.Id: {newData.Id}");

        //unitWork.CardRepository.ReadFirst(unitWork.CardRepository.GetById(newData.Id));
        unitWork.CardRepository.ReadFirst(newData);

        currentMode = "Update";

        Console.WriteLine(queryMode[currentMode]);

        oldData = unitWork.CardRepository.GetById(newData.Id);

        if (oldData == null)
        {
            Console.WriteLine($"Card {cardNumber} not found");
            cardNumber++;
            continue;
        }

        oldData.Name = $"Card {cardNumber} {queryMode[currentMode]}";
        oldData.Description = $"Description {cardNumber} {queryMode[currentMode]}";
        oldData.Attack = cardNumber;
        oldData.HealthPoint = cardNumber;
        oldData.Defense = cardNumber;
        oldData.Cost = cardNumber;

        editData = unitWork.CardRepository.UpdateReturnEntity(oldData);

        if (editData == null)
        {
            Console.WriteLine($"Update card {cardNumber} not found");
            cardNumber++;
            continue;
        }

        unitWork.CardRepository.ReadFirst(editData);
        //unitWork.CardRepository.ReadFirst(unitWork.CardRepository.GetById(editData.Id));

        //unitWork.CardRepository.ReadFirst(unitWork.CardRepository.GetById(card.Id));

        //unitWork.CardRepository.Delete(card);

        cardNumber++;
    }

    //allCards = unitWork.CardRepository.GetAll();

    //Console.WriteLine($"Number of cards: {allCards.Count}");

    Console.WriteLine("Press any key to exit...");

    Console.ReadKey(true);

    cnn.Close();
}
catch (Exception ex)
{
    Console.WriteLine($"Message: {ex.Message}\nStacktrace: {ex.StackTrace}");
}