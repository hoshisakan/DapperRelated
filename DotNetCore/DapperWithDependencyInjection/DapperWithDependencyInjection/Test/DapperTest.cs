﻿using DapperWithDependencyInjection.Test.ITest;
using DataAccess.Repositories;
using DataAccess.Repositories.IRepository;
using Models.Entity.TestDatabase;
using Utilities.Helper.IHelper;


namespace DapperWithDependencyInjection.Test
{
    public class DapperTest : IDapperTest
    {
        private readonly ILoggerHelper _loggerHelper;
        private readonly IJsonHelper _jsonHelper;
        private readonly IUnitWork _unitWork;
        private readonly string[] queryMode = new string[] { "Create", "Update", "Delete", "Select" };
        private readonly string className = nameof(DapperTest);

        public DapperTest(IUnitWork unitWork, ILoggerHelper loggerHelper, IJsonHelper jsonHelper)
        {
            _loggerHelper = loggerHelper;
            _jsonHelper = jsonHelper;
            _unitWork = unitWork;
        }

        public void TestWriteMessageToLogFile()
        {
            string methodName = nameof(TestWriteMessageToLogFile);

            _loggerHelper.LogDebug(
                $"Write a message to log file for new log write method test.",
                className,
                methodName
            );
            _loggerHelper.LogDebug(
                $"Write a message to log file for new log write method test.",
                className,
                methodName
            );
            _loggerHelper.LogDebug(
                $"Write a message to log file for new log write method test.",
                className,
                methodName
            );
            _loggerHelper.LogDebug($"Write a message to log file for new log write method test.", className, methodName);

            _loggerHelper.LogDebug($"Write a message to log file for new log write method test.", className, methodName);

            _loggerHelper.LogDebug($"Write a message to log file for new log write method test.", className, methodName);

            _loggerHelper.LogDebug($"Write a message to log file for new log write method test.", className, methodName);

            _loggerHelper.LogDebug($"Write a message to log file for new log write method test.", className, methodName);
        }

        public void TestTakeRelatedMethods()
        {
            string methodName = nameof(TestTakeRelatedMethods);

            _loggerHelper.LogDebug(_jsonHelper.Serialize(_unitWork.TestCardRepository.GetTake(10)), className, methodName);
            _loggerHelper.LogDebug(_jsonHelper.Serialize(_unitWork.TestCardRepository.GetTakeReverse(10)), className, methodName);
            _loggerHelper.LogDebug(_jsonHelper.Serialize(_unitWork.PersonRepository.GetTake(10)), className, methodName);
            _loggerHelper.LogDebug(_jsonHelper.Serialize(_unitWork.PersonRepository.GetTakeReverse(10)), className, methodName);
        }

        public void TestSkipRelatedMethods()
        {
            string methodName = nameof(TestSkipRelatedMethods);


            _loggerHelper.LogDebug(_jsonHelper.Serialize(_unitWork.TestCardRepository.GetSkip(10)), className, methodName);
            _loggerHelper.LogDebug(_jsonHelper.Serialize(_unitWork.TestCardRepository.GetSkipReverse(10)), className, methodName);
            _loggerHelper.LogDebug(_jsonHelper.Serialize(_unitWork.PersonRepository.GetSkip(10)), className, methodName);
            _loggerHelper.LogDebug(_jsonHelper.Serialize(_unitWork.PersonRepository.GetSkipReverse(10)), className, methodName);
        }

        public void TestTakeAndSkipRelatedMethods()
        {
            string methodName = nameof(TestTakeAndSkipRelatedMethods);
            _loggerHelper.LogDebug(_jsonHelper.Serialize(_unitWork.TestCardRepository.GetTakeSkip(10, 10)), className, methodName);
            _loggerHelper.LogDebug(_jsonHelper.Serialize(_unitWork.TestCardRepository.GetTakeSkipReverse(10, 10)), className, methodName);
            _loggerHelper.LogDebug(_jsonHelper.Serialize(_unitWork.PersonRepository.GetTakeSkip(10, 10)), className, methodName);
            _loggerHelper.LogDebug(_jsonHelper.Serialize(_unitWork.PersonRepository.GetTakeSkipReverse(10, 10)), className, methodName);
        }

        public void TestIsTableExists()
        {
            string methodName = nameof(TestIsTableExists);

            bool isTestCardTableExist = _unitWork.TestCardRepository.IsTableExists();

            _loggerHelper.LogDebug(_jsonHelper.Serialize(isTestCardTableExist), className, methodName);

            bool isPersonTableExist = _unitWork.PersonRepository.IsTableExists();

            _loggerHelper.LogDebug(_jsonHelper.Serialize(isPersonTableExist), className, methodName);
        }

        public void TestIsTableEmpty()
        {
            Console.WriteLine($"TestCardRepository Table Is Empty? {this._unitWork.TestCardRepository.IsTableEmpty()}");
            Console.WriteLine($"PersonRepository Table Is Empty? {this._unitWork.PersonRepository.IsTableEmpty()}");
        }

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
            string methodName = nameof(TestSqlRaw);

            person = _unitWork.PersonRepository.GetFirst();
            _loggerHelper.LogDebug(_jsonHelper.Serialize(person), className, methodName);

            person = _unitWork.PersonRepository.GetLast();
            _loggerHelper.LogDebug(_jsonHelper.Serialize(person), className, methodName);

            persons = _unitWork.PersonRepository.GetTakeReverse(10);
            _loggerHelper.LogDebug(_jsonHelper.Serialize(persons), className, methodName);

            person = _unitWork.PersonRepository.GetById(30000);
            _loggerHelper.LogDebug(_jsonHelper.Serialize(person), className, methodName);

            person = _unitWork.PersonRepository.GetLast();
            _loggerHelper.LogDebug(_jsonHelper.Serialize(person), className, methodName);

            person = _unitWork.PersonRepository.GetFirst();
            _loggerHelper.LogDebug(_jsonHelper.Serialize(person), className, methodName);
        }

        public void TestByPersonWithUnitWork()
        {
            int objNumber = 1;
            int stopNumber = (int)Math.Pow(10, 4);
            int dataCount = 0;

            List<Person> persons = new List<Person>();

            Console.WriteLine($"Test by {nameof(UnitWork)} with {nameof(TestCardRepository)}");
            _loggerHelper.LogDebug($"Test by {nameof(UnitWork)} with {nameof(TestCardRepository)}", className, nameof(TestByPersonWithUnitWork));

            Console.WriteLine("----------------------------------------");
            _loggerHelper.LogDebug("----------------------------------------", className, nameof(TestByPersonWithUnitWork));

            dataCount = _unitWork.PersonRepository.GetCount();

            Console.WriteLine($"Data count: {dataCount}");
            _loggerHelper.LogDebug($"Data count: {dataCount}", className, nameof(TestByPersonWithUnitWork));

            Console.WriteLine("----------------------------------------");
            _loggerHelper.LogDebug("----------------------------------------", className, nameof(TestByPersonWithUnitWork));

            Console.WriteLine("Start testing single add query");
            _loggerHelper.LogDebug("Start testing single add query", className, nameof(TestByPersonWithUnitWork));

            /// Add
            Person person = new Person()
            {
                LastName = $"Test {queryMode[0]} LastName {objNumber}",
                FirstName = $"Test {queryMode[0]} FirstName {objNumber}",
                Address = $"Test {queryMode[0]} Address {objNumber}",
                City = $"Test {queryMode[0]} City {objNumber}",
                CreateTime = DateTime.Now
            };
            _unitWork.PersonRepository.Add(person);

            Console.WriteLine("End testing single add query");

            _loggerHelper.LogDebug("End testing single add query", className, nameof(TestByPersonWithUnitWork));

            Console.WriteLine("----------------------------------------");

            _loggerHelper.LogDebug("----------------------------------------", className, nameof(TestByPersonWithUnitWork));

            //Console.WriteLine("Start testing single update query");

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

            _loggerHelper.LogDebug("Start testing multiple add query", className, nameof(TestByPersonWithUnitWork));

            _unitWork.PersonRepository.AddRange(persons);

            Console.WriteLine("End testing multiple add query");

            _loggerHelper.LogDebug("End testing multiple add query", className, nameof(TestByPersonWithUnitWork));

            Console.WriteLine("----------------------------------------");

            _loggerHelper.LogDebug("----------------------------------------", className, nameof(TestByPersonWithUnitWork));

            dataCount = _unitWork.PersonRepository.GetCount();

            Console.WriteLine($"Data count: {dataCount}");

            _loggerHelper.LogDebug($"Data count: {dataCount}", className, nameof(TestByPersonWithUnitWork));

            Console.WriteLine("----------------------------------------");

            _loggerHelper.LogDebug("----------------------------------------", className, nameof(TestByPersonWithUnitWork));

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

            ids = _unitWork.TestCardRepository.GetWhere(x => x.Id == 60003).Select(x => x.Id).ToList();

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
            _unitWork.TestCardRepository.Add(card);

            Console.WriteLine("End testing single add query");

            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Start testing single update query");

            /// Select
            card = _unitWork.TestCardRepository.GetFirst();

            /// Update
            currentMode = queryMode[1];
            card.Name = $"Card {cardNumber} {currentMode}";
            card.Description = $"Description {cardNumber} {currentMode}";
            card.Attack = cardNumber;
            card.HealthPoint = cardNumber;
            card.Defense = cardNumber;
            card.Cost = cardNumber;
            _unitWork.TestCardRepository.Update(card);

            Console.WriteLine("End testing single update query");

            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Start testing single delete query");

            /// Delete
            _unitWork.TestCardRepository.Delete(card);

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

            _unitWork.TestCardRepository.AddRange(cards);

            Console.WriteLine("End testing multiple add query");

            Console.WriteLine("----------------------------------------");

            cardNumber = 1;

            /// UpdateRange
            List<TestCard> updateCards = new List<TestCard>();
            /// Get stopNumber amount of cards from database

            Console.WriteLine("Start testing multiple select query");

            List<TestCard> oldCards = _unitWork.TestCardRepository.GetTakeSkipReverse(stopNumber, 0);

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

            _unitWork.TestCardRepository.UpdateRange(oldCards);

            Console.WriteLine("End testing multiple update query");

            Console.WriteLine("----------------------------------------");

            //updateCards = unitWork.TestCardRepository.GetTakeSkipReverse(stopNumber, 0);
            updateCards = _unitWork.TestCardRepository.GetAll();

            Console.WriteLine("Start testing multiple delete query");

            _unitWork.TestCardRepository.DeleteRange(updateCards);

            Console.WriteLine("End testing multiple delete query");

            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Start testing multiple select query");

            cards = _unitWork.TestCardRepository.GetAll();

            Console.WriteLine("End testing multiple select query");

            Console.WriteLine("----------------------------------------");

            Console.WriteLine($"Card count: {cards.Count}");

            Console.WriteLine("----------------------------------------");
        }
    }
}
