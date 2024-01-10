using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop2_TeamG.Models;

namespace Webshop2_TeamG.Helpers
{
    internal class Admin
    {
        public static void AdminTools(int menuX, int menuY)
        {
            int i = 0;
            //Console.BackgroundColor = ConsoleColor.DarkBlue; Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(menuX, menuY + i); i++;
            Console.Write("Do you want to:");
            Console.SetCursorPosition(menuX, menuY + i); i++;
            Console.Write("1. Add Game");
            Console.SetCursorPosition(menuX, menuY + i); i++;
            Console.Write("2. Delete Game (placeholder)");
            Console.SetCursorPosition(menuX, menuY + i); i++;
            Console.Write("3. Cancel");
            Console.SetCursorPosition(menuX, menuY + i); i++;
            Console.Write("9. Fill Db with Sample Games");

            var userInputKey = Console.ReadKey(true);
            if (userInputKey.Key == ConsoleKey.D1)
            {
                AddGame(menuX, menuY);
            }
            if (userInputKey.Key == ConsoleKey.D2)
            {
                return;
            }
            if (userInputKey.Key == ConsoleKey.D3)
            {
                return;
            }
            if (userInputKey.Key == ConsoleKey.D9)
            {
                Helpers.Create.FillDatabase();
                return;
            }
            
        }
        private static void AddGame(int menuX, int menuY)
        {
        //    Console.SetCursorPosition(0, 0);
        //    Helpers.Gfx.Frontend();
        //    Console.SetCursorPosition(menuX, menuY);
        //    int i = 1;
        //    Console.BackgroundColor = ConsoleColor.DarkBlue; Console.ForegroundColor = ConsoleColor.Cyan;
        //    using (var database = new ShopDbContext())
        //    {
        //        Console.SetCursorPosition(menuX, menuY + i); i++;
        //        Console.Write("Enter Category: ");
        //        string newCat = Console.ReadLine();
        //        Console.SetCursorPosition(menuX, menuY + i); i++;
        //        Console.Write("Enter Title: ");
        //        string newTit = Console.ReadLine();
        //        Console.SetCursorPosition(menuX, menuY + i); i++;
        //        Console.Write("Enter Price: ");
        //        double newPrice = double.Parse(Console.ReadLine());
        //        Console.SetCursorPosition(menuX, menuY + i); i++;
        //        Console.Write("Enter ShortInfo: ");
        //        string newShort = Console.ReadLine();
        //        Console.SetCursorPosition(menuX, menuY + i); i++;
        //        Console.Write("Enter LongInfo: ");
        //        string newLong = Console.ReadLine();
        //        Console.SetCursorPosition(menuX, menuY + i); i++;

        //        Console.Write("Enter Rating (3, 7, 12, 16, 18): ");
        //        int newRating = 0;
        //        int.TryParse(Console.ReadLine(), out newRating);

        //        Console.SetCursorPosition(menuX, menuY + i); i++;
        //        Console.Write("Enter Publisher ");
        //        string newPub = Console.ReadLine();
        //        Console.SetCursorPosition(menuX, menuY + i); i++;
        //        Console.Write("How many units?: ");
        //        int newStock = int.Parse(Console.ReadLine());

        //        var newGame = new Game
        //        {
        //            Category = newCat,
        //            Title = newTit,
        //            Price = newPrice,
        //            ShortInfo = newShort,
        //            LongInfo = newLong,
        //            AgeRating = ((AgeRating)newRating),
        //            Publisher = newPub,
        //            OnDisplay = false,
        //            Stock = newStock
        //        };

        //        /*
        //                 public int Id { get; set; }
        //public string Title { get; set; }
        //public decimal Price { get; set; }
        //public int GenreId { get; set; }
        //public Genre Genre { get; set; }
        //public int Stock { get; set; }
        //public AgeRating AgeRating { get; set; }
        //public string ShortInfo { get; set; }
        //public string LongInfo { get; set; }
        //         */
        //        database.Games.Add(newGame);
        //        database.SaveChanges();
        //    }
        }
    }
}
