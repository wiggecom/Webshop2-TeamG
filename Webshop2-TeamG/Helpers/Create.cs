using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;

namespace Webshop2_TeamG.Helpers
{
    internal class Customer
    {
        public static void CustomerTools(int menuX, int menuY, int infoX, int infoY)
        {
            //Helpers.Gfx.ClearMenu(menuX, menuY);
            int i = 0;
            Console.BackgroundColor = ConsoleColor.DarkBlue; Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(menuX, menuY + i); i++;
            Console.Write("Do you want to:");
            Console.SetCursorPosition(menuX, menuY + i); i++;
            Console.Write("1. Return");
            Console.SetCursorPosition(menuX, menuY + i); i++;
            Console.Write("2. Create Account");
            Console.SetCursorPosition(menuX, menuY + i); i++;
            Console.Write("3. Go to Account");
            Console.SetCursorPosition(menuX, menuY + i); i++;

            var userInputKey = Console.ReadKey(true);
            if (userInputKey.Key == ConsoleKey.D1)
            {
                return;
            }
            if (userInputKey.Key == ConsoleKey.D2)
            {
                AddPerson(menuX, menuY);
                //Helpers.Persons.ListPersons(infoX, infoY);
            }
            if (userInputKey.Key == ConsoleKey.D3)
            {
                Console.WriteLine("Placeholder: Go to account info");
                //RemovePerson(menuX, menuY);
                //Helpers.Persons.ListPersons(infoX, infoY);
            }

        }

        private static void AddPerson(int menuX, int menuY)
        {
            //    //Helpers.Gfx.ClearMenu(menuX, menuY);
            //    Console.SetCursorPosition(menuX, menuY);
            //    Console.Write("Current Members:");
            //    int i = 1;
            //    Console.BackgroundColor = ConsoleColor.DarkBlue; Console.ForegroundColor = ConsoleColor.Cyan;
            //    using (var database = new ShopDbContext())
            //    {
            //        foreach (var person in database.Persons)
            //        {
            //            Console.SetCursorPosition(menuX, menuY + i);
            //            Console.Write(person.Name);
            //            i++;
            //        }
            //        int afterList = database.Persons.Count();
            //        Console.SetCursorPosition(menuX, menuY + 2 + afterList);
            //        Console.Write("Enter the Name to Add: ");
            //        string newName = Console.ReadLine();
            //        var newPerson = new Person
            //        {
            //            Name = newName,
            //            TotalValue = 0
            //        };
            //        database.Persons.Add(newPerson);
            //        database.SaveChanges();
            //    }

        }
    }
}
