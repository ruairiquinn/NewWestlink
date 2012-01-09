using System;
using System.Collections.Generic;
using Core.Enumerations;
using NewWestlink.Infrastructure;
using NewWestlink.Models;

namespace TestHarness
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Bootstrapper.ConfigureDependencies();

            Console.WriteLine(@"Starting...");

            var forenames = new List<string>
                                {
                                    "John",
                                    "Paul",
                                    "Bill",
                                    "Matthew",
                                    "Mark",
                                    "Luke",
                                    "Ringo",
                                    "Simon",
                                    "Alvin",
                                    "Theodore",
                                    "Luis"
                                };

            var surnames = new List<string>
                                {
                                    "Red", "Orange", "Yellow", "Green", "Blue", "Indigo", "Violet", "January", "February", "March"
                                };

            foreach (var forename in forenames)
            {
                foreach (var surname in surnames)
                {
                    var client = new Client
                                     {
                                         Forename = forename,
                                         Surname = surname,
                                         Age = new Random().Next(18, 100),
                                         Gender = Enumerations.Gender.Male,
                                         IsEmployed = true,
                                         LastUpdated = DateTime.Now
                                     };
                    var clientRepo = new ClientRepository(new EventPublisher(new List<object>()));
                    clientRepo.Add(client);
                    Console.WriteLine("{0} {1}", client.Forename, client.Surname);
                }   
            }

            Console.ReadLine();
        }
    }
}
