using ConsoleApp.DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ConsoleApp
{
    class Program
    {
        private static IConfiguration _iconfiguration;

        static void Main(string[] args)
        {
            GetAppSettingsFile();
            ShowAdventurePerson();
            Console.WriteLine("Pressione qualquer tecla para parar.");
            Console.ReadKey();
        }

        static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                                 _iconfiguration = builder.Build();
        }
        static void ShowAdventurePerson()
        {
            var personDAL = new PersonDAL(_iconfiguration);
            var lstPerson = personDAL.GetAllPerson();

            lstPerson.ForEach(item =>
            {
                Console.WriteLine($"BusinessEntityID: {item.BusinessEntityID}");
                Console.WriteLine($"Last Name: {item.LastName}");
                Console.WriteLine($"First Name: {item.FirstName}");
                Console.WriteLine();
            });
        }
    }
}

