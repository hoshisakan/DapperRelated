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

    List<Card> cards = unitWork.CardRepository.GetAll();

    //CardRepository cardRepository = new CardRepository(cnn);

    //List<Card> cards = cardRepository.GetAll();

    Console.WriteLine($"Number of cards: {cards.Count}");

    //int cardNumber = 1;

    //while (cardNumber <= 100)
    //{
    //    Card card = new Card()
    //    {
    //        Name = $"Card {cardNumber} Update",
    //        Description = $"Description {cardNumber} Update",
    //        Attack = cardNumber,
    //        HealthPoint = cardNumber,
    //        Defense = cardNumber,
    //        Cost = cardNumber
    //    };
    //    //unitWork.CardRepository.Add(card);
    //    cards = unitWork.CardRepository.GetAll();
    //    //cardRepository.AddCard(card);
    //    //cards = cardRepository.GetAll();
    //    cardNumber++;
    //}

    foreach (Card card in cards)
    {
        Console.WriteLine($"Id: {card.Id},Name: {card.Name},Description: {card.Description} Before Update");

        //unitWork.CardRepository.Delete(card);

        card.Name = $"Card {card.Id} Update";
        card.Description = $"Description {card.Id} Update";
        card.HealthPoint = -1;
        unitWork.CardRepository.Update(card);
        Card updatedCard = unitWork.CardRepository.GetById(card.Id);
        Console.WriteLine($"Id: {updatedCard.Id},Name: {updatedCard.Name},Description: {updatedCard.Description} After Update");
    }

    Console.WriteLine("Press any key to exit...");

    Console.ReadKey(true);

    cnn.Close();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}