using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop2_TeamG.Models;
using Microsoft.EntityFrameworkCore.Storage;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Webshop2_TeamG.Helpers
{
    internal class Admin
    {
        public static void AdminTools(int option)
        {
            SysMenu.ClearMainArea();
            switch (option)
            {
                case 1:
                    //Admin.AddGame();
                    Position.MoveCursorMainStart(0);
                    Console.Write("Add Title");
                    using (var database = new ShopDbContext())
                    {
                        AddGame(database);
                    }
                    return;
                case 2:
                    Position.MoveCursorMainStart(0);
                    using (var database = new ShopDbContext())
                    {
                        RemoveGame();
                    }
                    return;
                case 3:
                    Position.MoveCursorMainStart(0);
                    EditGame();
                    //Console.Write("Change Title");
                    return;
                case 4:
                    Position.MoveCursorMainStart(0);
                    Console.Write("List Titles");
                    return;
                case 5:
                    Position.MoveCursorMainStart(0);
                    try
                    {
                        using (var database = new ShopDbContext())
                        {
                            Console.Write("Checking if database is empty...");
                            Position.MoveCursorMainStart(0);
                            Helpers.Create.FillDatabase(database);
                        }
                    }
                    catch (Exception ex)
                    {
                        Position.MoveCursorMainStart(0);
                        Console.Write("                                ");
                        Position.MoveCursorMainStart(0);
                        Console.Write($"Error occured: {ex.Message}");
                        //Thread.Sleep(3000);
                        //Gfx.Frontend(0, 0);
                        //Gfx.ColorIni();
                    }
                    return;
                case 6:
                    Position.MoveCursorMainStart(0);
                    try
                    {
                        using (var database = new ShopDbContext())
                        {
                            Console.Write("Checking if database is empty...");
                            Position.MoveCursorMainStart(0);
                            Helpers.Create.SampleCustomers(database);
                        }
                    }
                    catch (Exception ex)
                    {
                        Position.MoveCursorMainStart(0);
                        Console.Write("                                ");
                        Position.MoveCursorMainStart(0);
                        Console.Write($"Error occured: {ex.Message}");
                        //Thread.Sleep(3000);
                        //Gfx.Frontend(0, 0);
                        //Gfx.ColorIni();
                    }
                    return;
                case 7:
                    Position.MoveCursorMainStart(0);
                    Console.Write("Top Console");
                    return;
                case 8:
                    Position.MoveCursorMainStart(0);
                    Console.Write("Top Game");
                    return;
                case 9:
                    Position.MoveCursorMainStart(0);
                    Console.Write("Low Stock");
                    return;

            }
        }
        public static void MakeFirstAdmin()
        {
            using (var database = new ShopDbContext())
            {
                Position.MoveCursorMainStart(0);
                Helpers.Create.FirstAdmin(database);
            }
        }
        private static void EditGame()
        {
            SysMenu.SelectGame(2, 666666);
        }
        private static void RemoveGame()
        {
            SysMenu.SelectGame(1, 666666);
        }
        private static void AddGame(ShopDbContext database)
        {
            int menuX = 45;
            int menuY = 12;
            SysMenu.ClearMainArea();
            Position.MoveCursorMainStart(0);
            int i = 1;


            var genreList = database.Genres.ToList();
            for (int j = 0; j < genreList.Count; j++)
            {
                Console.SetCursorPosition(menuX, menuY + i); i++;
                Console.WriteLine("(" + j + ") - " + genreList[j].Name);
            }
            Console.SetCursorPosition(menuX, menuY + i); i++;
            Console.Write("Select Genre: ");
            int genreInt = int.Parse(Console.ReadLine());
            var selectedGenre = genreList[genreInt].Id;



            Console.SetCursorPosition(menuX, menuY + i); i++;
            Console.Write("Enter Title: ");
            string newTit = Console.ReadLine();

            Console.SetCursorPosition(menuX, menuY + i); i++;
            Console.Write("Enter Price: ");
            string priceString = Console.ReadLine();
            string replacedDot = priceString.Replace('.', ',');
            decimal newPrice = decimal.Parse(replacedDot);

            Console.SetCursorPosition(menuX, menuY + i); i++;
            Console.Write("How Many Units?: ");
            int newStock = int.Parse(Console.ReadLine());

            Console.SetCursorPosition(menuX, menuY + i); i++;
            Console.Write("Enter ShortInfo: ");
            string newShort = Console.ReadLine();
            // 46 is current max length of shortinfo rows, maximum total is 4 rows (184).
            // Looks best with 3 rows (138) so ideally truncate to 120 chars
            int shortLen = newShort.Length;
            if (shortLen > 120)
            {
                newShort = newShort.Remove(120) + "...";
            }
            newShort = Create.StringBreak(newShort, 46);


            // 79 is current max length of shortinfo rows, maxiumum total is 7 rows (553).
            // Looks best with 6 rows (474) so ideally truncate to 420 chars due to slitting rows at whole words
            Console.SetCursorPosition(menuX, menuY + i); i++;
            Console.Write("Enter LongInfo: ");
            string newLong = Console.ReadLine();
            int longLen = newShort.Length;
            if (longLen > 420)
            {
                newLong = newLong.Remove(420) + "...";
            }
            newLong = Create.StringBreak(newLong, 79);


            Console.SetCursorPosition(menuX, menuY + i); i++;
            Console.Write("Enter Rating (1) - Everyone, (2) - Teen, (3) - Mature: ");
            int newRating = 0;
            int.TryParse(Console.ReadLine(), out newRating);
            AgeRating ageRating = new AgeRating();

            if (newRating == 1)
            {
                ageRating = AgeRating.Everyone;
            }
            else if (newRating == 2)
            {
                ageRating = AgeRating.Teen;
            }
            else
            {
                ageRating = AgeRating.Mature;
            }

            // --------------------------------------------------------------------------------------------------------------------

            var newGame = new List<Game>
            {
            new Game
            {
                Title = newTit,
                Price = newPrice,
                GenreId = selectedGenre,
                Stock = newStock,
                AgeRating = ageRating,
                ShortInfo = newShort,
                LongInfo = newLong,
            },
            };

            database.Games.AddRange(newGame);

            database.SaveChanges();

            Gfx.WinIni();
            SysMenu.TopMenu(85, 3);
            SysMenu.ClearFullSidemenu(7, 13);
            //SysMenu.SideMenu(7, 13, 1);
            var refreshGameList = database.Games.ToList();
            var lastGame = refreshGameList.Count()-1;
            MainView.DetailGame(lastGame, 0);
            SysMenu.MenuTitle(7, 9, "Admin Menu");
            SysMenu.AdminMenu(7, 13, 3);
        }

    }
}
