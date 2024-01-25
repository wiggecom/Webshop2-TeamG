using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop2_TeamG.Models;

namespace Webshop2_TeamG.Helpers
{
    internal class SysMenu
    {
        public static void TopMenu(int topX, int topY)
        {
            using (var database = new ShopDbContext())
            {
                int i = 60;
                Console.SetCursorPosition(topX, topY);
                Console.Write("                       ");
                Console.SetCursorPosition(topX, topY);
                Console.Write("F1. Main Menu");
                Console.SetCursorPosition(topX, topY + 1);
                Console.Write("                       ");
                Console.SetCursorPosition(topX, topY + 1);
                Console.Write("F2. Shopping Basket");
                Console.SetCursorPosition(topX, topY + 2);
                Console.Write("                       ");
                Console.SetCursorPosition(topX, topY + 2);
                Console.Write("F3. Admin");
                Console.SetCursorPosition(topX + i, topY);
                Console.Write("                       ");

                if (database.Customers.Any() && database.Baskets.Any() &! database.BasketEntries.Any())
                {
                    var customers = database.Customers.ToList();
                    var customer = customers.FirstOrDefault();
                    Console.SetCursorPosition(topX + i, topY);
                Console.Write(customer.Name);
                Console.SetCursorPosition(topX + i, topY + 1);
                Console.Write("                       ");
                Console.SetCursorPosition(topX + i, topY + 1);
                Console.Write("Basket is empty");
                Console.SetCursorPosition(topX + i, topY + 2);
                Console.Write("                       ");
                Console.SetCursorPosition(topX + i, topY + 2);
                Console.Write("                       ");
                }

                else if (database.Customers.Any() && database.Baskets.Any() && database.BasketEntries.Any()) 
                { 
                var customers = database.Customers.ToList();
                var customer = customers.FirstOrDefault();
                var baskets = database.Baskets.ToList();
                var entries = database.BasketEntries.ToList();
                int lastBasket = baskets.Count - 1;
                string userName = customers[0].Name;
                int totalItems = baskets[lastBasket].BasketEntries.Count;

                    //decimal totalAmount = 0;
                    //totalAmount = BasketView.BasketTotalAmount(database, customers[0]);

                    decimal totalAmount = BasketView.CalculateTotalAmount(database, customer);


                    Console.SetCursorPosition(topX + i, topY);
                    Console.Write("                       ");
                    Console.SetCursorPosition(topX + i, topY);
                    Console.Write("User: " + userName);
                    Console.SetCursorPosition(topX + i, topY + 1);
                    Console.Write("                       ");
                    Console.SetCursorPosition(topX + i, topY + 1);
                    if (totalItems > 0)
                    {
                        Console.Write(totalItems + " items in basket");
                        Console.SetCursorPosition(topX + i, topY + 2);
                        Console.Write("Total: " + totalAmount + " SEK");
                    }
                    else
                    {
                        Console.Write("Basket is empty");
                        Console.SetCursorPosition(topX + i, topY + 2);
                        Console.Write("                       ");
                    }
                    //Console.SetCursorPosition(topX + i, topY + 2);
                    //Console.Write("Basket total: " + totalAmount + " SEK");
                }
                else
                {
                    var customers = database.Customers.ToList();
                    var customer = customers.FirstOrDefault();
                    Console.SetCursorPosition(topX + i, topY);
                    Console.Write(customer.Name + " Logged In");
                    Console.SetCursorPosition(topX + i, topY + 1);
                    Console.Write("                       ");
                    Console.SetCursorPosition(topX + i, topY + 1);
                    Console.Write("");
                    Console.SetCursorPosition(topX + i, topY + 2);
                    Console.Write("                       ");
                    Console.SetCursorPosition(topX + i, topY + 2);
                    Console.Write("");

                }




            }
        }
        public static void SideMenu(int menuLevel)
        {
            int winX = Position.sideX;
            int winY = Position.sideY;
            // Stay in each submenu unless menuLevel changes
            switch (menuLevel)
            {
                case 1:
                    {
                        MenuTitle(winX, winY, "Main Menu");
                        ClearMainArea();
                        MainMenu(winX, winY + 4, menuLevel);
                        break;
                    }
                case 2:
                    {
                        MenuTitle(winX, winY, "Shopping Basket");
                        ClearMainArea();
                        BasketMenu(winX, winY + 4, menuLevel);
                        break;
                    }
                case 3:
                    {
                        MenuTitle(winX, winY, "Admin Menu");
                        ClearMainArea();
                        AdminMenu(winX, winY + 4, menuLevel);
                        break;
                    }

            }
        }
        public static void MenuTitle(int winX, int winY, string title)
        {
            Console.SetCursorPosition(winX, winY);
            Console.Write("                       ");
            Console.SetCursorPosition(winX, winY);
            Console.Write(title);
            Console.SetCursorPosition(winX, winY + 1);
            Console.Write("                       ");
            int countX = title.Length;
            string underScore = new string('▀', countX);
            Console.SetCursorPosition(winX, winY + 1);
            Console.Write(underScore);
        }
        public static void MainMenu(int winX, int winY, int menuLevel)
        {
            int i = 0;
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("A) Show All");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("S) Select Category");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("D) Search");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("1-3) Select Featured");

            //------------------------------
            CopyrightMenu(winX, winY + 32);
            MainView.MainArea();
            //return menuLevel;
        }  // ------------ SETS SET VIEW ON MAIN AREA ------------
        public static void BasketMenu(int winX, int winY, int menuLevel)
        {
            //ClearFullSidemenu(winX, winY);
            int i = 0;
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("A) Edit Basket");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("S) Checkout");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("D) History");


            //------------------------------
            CopyrightMenu(winX, winY + 32);
            BasketView.BasketViewDefault();
            //menuLevel = KeyInput(40, 12, menuLevel);
            //return menuLevel;
        }
        public static void AdminMenu(int winX, int winY, int menuLevel)
        {
            int i = 0;
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("A) Add Title");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("S) Remove Title");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("D) Change Title");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("F) List Titles");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("G) Admin Data");
            CopyrightMenu(winX, winY + 32);
        }
        public static void CopyrightMenu(int winX, int winY)
        {
            int i = 0;
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("(C) 2024");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("House of Games");
        }
        public static void ClearFullSidemenu(int winX, int winY)
        {
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(winX, winY + i);
                Console.Write("                       ");
            }
        }
        public static void ClearMainArea()
        {
            int startX = 45;
            int lengthX = Console.WindowWidth - (startX + 28);
            string wiper = new string(' ', lengthX);
            int startY = 10;
            int endY = 48;
            for (int i = startY; i < endY; i++)
            {
                Console.SetCursorPosition(startX, i);
                Console.Write(wiper);
            }
        }
        public static void ClearAllAreas()
        {
            ClearMainArea();
            ClearTopArea();
            ClearFullSidemenu(Position.sideX, Position.sideYMenu);
            MenuTitle(Position.sideX, Position.sideY, "");
        }
        public static void ClearTopArea()
        {
            int startX = Position.topX;
            int lengthX = Console.WindowWidth - (Position.topX + 60);
            string wiper = new string(' ', lengthX);
            int endY = 6;
            for (int i = Position.topY; i < endY; i++)
            {
                Console.SetCursorPosition(startX, i);
                Console.Write(wiper);
            }
            TopMenu(Position.topX, Position.topY);
        }
        public static void SelectGame(int edit, int gameId)
        { // edit 0 = browse, 1 = delete, 2 = edit
            ClearAllAreas();
            int nxtRow = 0;
            int selectedIndex = gameId;
            int pageLength = 18; // -------------------------------------  SET TO NUMBER OF GAMES LISTED PER PAGE ---------------------------
            using (var database = new ShopDbContext())
            {
                var games = database.Games.ToList();
                for (int i = 0; i < games.Count; i++)
                {
                    Position.MoveCursorMainStart(nxtRow); nxtRow++;
                    Console.WriteLine($"{i + 1}. {games[i].Title}");
                    if (nxtRow >= pageLength || gameId != 666666 || gameId != 999999)
                    {
                        if (gameId == 666666 && nxtRow >= pageLength || gameId == 999999 && nxtRow >= pageLength)
                        {
                            Position.MoveCursorMainStart(nxtRow); nxtRow++;
                            Console.Write("Enter Game Number or [ENTER] to Continue: ");
                            Console.CursorVisible = true;
                            int.TryParse(Console.ReadLine(), out selectedIndex);
                            Console.CursorVisible = false;
                        }
                        if (gameId != 666666)
                        {
                            selectedIndex = gameId + 1;
                            gameId = 666666;
                        }
                        if (selectedIndex >= 1 && selectedIndex <= games.Count)
                        {
                            selectedIndex -= 1;
                            while (selectedIndex != 999999)
                            {
                                if (edit == 0 && gameId == 666666)
                                {
                                    ClearMainArea();
                                    selectedIndex = MainView.DetailGame(selectedIndex, 1);
                                }
                                else if (edit == 0 && gameId != 666666)
                                {
                                    ClearMainArea();
                                    selectedIndex = MainView.DetailGame(gameId, 1);
                                }
                                else if (edit == 1)
                                {
                                    Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                    Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                    Console.Write("Selected title: " + games[selectedIndex].Title);
                                    Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                    Console.Write("Do you want to delete this title? (Y) to delete, [ENTER] to skip: ");
                                    string inputDelete = Console.ReadLine();
                                    if (inputDelete == "y" || inputDelete == "Y")
                                    {
                                        var deleteGame = games[selectedIndex];
                                        database.Games.Remove(deleteGame);
                                        database.SaveChanges();
                                        inputDelete = "";
                                        selectedIndex = 999999;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                                else if (edit == 2)
                                {
                                    EditGame(selectedIndex, 0);
                                    EditGame(selectedIndex, 1);
                                    selectedIndex = 666666;
                                    break;
                                }
                            }
                            if (selectedIndex == 999999)
                            {
                                //ClearMainArea();
                                //MainView.MainArea();
                                //MainMenu(7, 13, 1);
                                //Position.MoveCursorMainStart(nxtRow); nxtRow++;
                            }
                            break;
                        }
                        if (nxtRow >= pageLength)
                        {
                            Console.CursorVisible = false;
                            ClearMainArea();
                            nxtRow = 0;
                        }
                    }
                }
                if (selectedIndex == 0)
                {


                    Position.MoveCursorMainStart(nxtRow); nxtRow++;
                    Console.CursorSize = 100;
                    Console.CursorVisible = true;
                    Console.Write("Enter Game Number or [ENTER] to Exit: ");
                    int.TryParse(Console.ReadLine(), out selectedIndex);
                    Console.CursorVisible = false;


                    if (selectedIndex >= 1 && selectedIndex <= games.Count)
                    {
                        selectedIndex -= 1;
                        while (selectedIndex != 999999)
                        {
                            if (edit == 0)
                            {
                                ClearMainArea();
                                selectedIndex = MainView.DetailGame(selectedIndex, 1);
                            }
                            else if (edit == 1)
                            {
                                Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                Console.WriteLine("Selected title: " + games[selectedIndex].Title);
                                Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                Console.Write("Do you want to delete this title? (Y) to delete, [ENTER] to skip: ");
                                string inputDelete = Console.ReadLine();
                                if (inputDelete == "y" || inputDelete == "Y")
                                {
                                    var deleteGame = games[selectedIndex];
                                    database.Games.Remove(deleteGame);
                                    database.SaveChanges();
                                    inputDelete = "";
                                    selectedIndex = 999999;
                                }
                                else
                                {
                                    ReturnToMainWithMenu(edit);
                                    return;
                                }
                            }
                            else if (edit == 2)
                            {
                                EditGame(selectedIndex, 0);
                                EditGame(selectedIndex, 1);
                                selectedIndex = 666666;
                                break;
                            }
                        }
                        if (selectedIndex == 999999)
                        {
                            ReturnToMainWithMenu(edit);
                            return;
                        }
                    }
                    else
                    {
                        ReturnToMainWithMenu(edit);
                        return;
                    }
                }
                else
                {
                    ReturnToMainWithMenu(edit);
                    return;
                }
                Console.CursorVisible = false;
            }
        }
        public static void ReturnToMainWithMenu(int edit)
        {
            if (edit == 1 || edit == 2)
            {
                ReturnToMain(3);
            }
            else if (edit == 0)
            {
                ReturnToMain(1);
            }
        }
        public static void EditGame(int selectedIndex, int updated)
        {
            using (var database = new ShopDbContext())
            {
                var games = database.Games.ToList();
                var genres = database.Genres.ToList();
                var ratings = Enum.GetValues(typeof(AgeRating)).Cast<AgeRating>().ToList();
                while (updated <= 1)
                {

                    ClearMainArea();
                    int nxtRow = 0;
                    int genreRow = 0;
                    int ratingRow = 0;
                    //Position.MoveCursorTextAnywhere(140, ratingRow);
                    //Position.MoveCursorTextAnywhere(140, genreRow);
                    Position.MoveCursorMainStart(nxtRow); nxtRow++;
                    Console.Write("Selected title: " + games[selectedIndex].Title);
                    Position.MoveCursorMainStart(nxtRow); nxtRow++;
                    // -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
                    Console.Write("1 - Title: " + games[selectedIndex].Title);
                    Position.MoveCursorMainStart(nxtRow); nxtRow++;
                    Console.Write("2 - Price: " + games[selectedIndex].Price);
                    Position.MoveCursorMainStart(nxtRow); nxtRow++;
                    Console.Write("3 - GenreId: " + games[selectedIndex].GenreId);
                    Position.MoveCursorMainStart(nxtRow); nxtRow++;
                    Console.Write("4 - Stock: " + games[selectedIndex].Stock);
                    Position.MoveCursorMainStart(nxtRow); nxtRow++;
                    Console.Write("5 - SoldTotal: " + games[selectedIndex].SoldTotal);
                    Position.MoveCursorMainStart(nxtRow); nxtRow++;
                    Console.Write("6 - Age Rating: " + games[selectedIndex].AgeRating);
                    Position.MoveCursorMainStart(nxtRow); nxtRow++;
                    Console.Write("7 - Featured Game: " + games[selectedIndex].OnDisplay);
                    Position.MoveCursorMainStart(nxtRow); nxtRow++;
                    Position.MoveCursorMainStart(nxtRow); nxtRow++;
                    Console.Write("8 - Short Info: ");
                    //Position.MoveCursorMainStart(nxtRow); nxtRow++;
                    foreach (var sRow in games[selectedIndex].ShortInfo.Split('\n'))
                    {//foreach (var line in testString.Split('\n'))
                        Position.MoveCursorMainStart(nxtRow); nxtRow++;
                        Console.Write(sRow);
                    }
                    Position.MoveCursorMainStart(nxtRow); nxtRow++;
                    Position.MoveCursorMainStart(nxtRow); nxtRow++;
                    Console.Write("9 - Long Info: ");
                    foreach (var lRow in games[selectedIndex].LongInfo.Split('\n'))
                    {
                        Position.MoveCursorMainStart(nxtRow); nxtRow++;
                        Console.Write(lRow);
                    }
                    Position.MoveCursorMainStart(nxtRow); nxtRow++;
                    Position.MoveCursorMainStart(nxtRow); nxtRow++;
                    if (updated == 0)
                    {
                        Console.Write("Please enter field to edit [ENTER to exit]: ");
                        string inputEdit = Console.ReadLine();
                        Position.MoveCursorMainStart(nxtRow); nxtRow++;
                        if (inputEdit == "1")
                        {
                            Position.MoveCursorMainStart(nxtRow); nxtRow++;
                            Console.Write("Current Title: " + games[selectedIndex].Title);
                            Position.MoveCursorMainStart(nxtRow); nxtRow++;
                            Console.Write("Enter New Title: ");
                            string newTitle = Console.ReadLine();
                            database.Games.Where(g => g.Id == selectedIndex + 1).ExecuteUpdate(a => a.SetProperty(b => b.Title, newTitle));
                            database.SaveChanges();
                        }
                        else if (inputEdit == "2")
                        {
                            decimal newPrice = 0;
                            Position.MoveCursorMainStart(nxtRow); nxtRow++;
                            Console.Write("Current Price: " + games[selectedIndex].Price);
                            Position.MoveCursorMainStart(nxtRow); nxtRow++;
                            Console.Write("Enter New Price: ");
                            string strPrice = Console.ReadLine();
                            string strPriceChecked = strPrice.Replace('.', ',');
                            decimal.TryParse(strPriceChecked, out newPrice);
                            if (newPrice > 0)
                            {
                                database.Games.Where(g => g.Id == selectedIndex + 1).ExecuteUpdate(a => a.SetProperty(b => b.Price, newPrice));
                                database.SaveChanges();
                            }
                        }
                        else if (inputEdit == "3")
                        {
                            int newGenre = 0;
                            int genreCounter = 1;
                            foreach (var gId in genres)
                            {
                                Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                Console.Write(genreCounter + ": " + gId.Name); genreCounter++;
                            }
                            Position.MoveCursorMainStart(nxtRow); nxtRow++;
                            Console.Write("Current Genre: " + games[selectedIndex].GenreId);
                            Position.MoveCursorMainStart(nxtRow); nxtRow++;
                            Console.Write("Enter New Genre: ");
                            string strGenre = Console.ReadLine();
                            int.TryParse(strGenre, out newGenre);
                            if (newGenre >= 1)
                            {
                                database.Games.Where(g => g.Id == selectedIndex + 1).ExecuteUpdate(a => a.SetProperty(b => b.GenreId, newGenre));
                                database.SaveChanges();
                            }
                        }
                        else if (inputEdit == "4")
                        {
                            int newStock = 0;
                            Position.MoveCursorMainStart(nxtRow); nxtRow++;
                            Console.Write("Current Stock: " + games[selectedIndex].Stock);
                            Position.MoveCursorMainStart(nxtRow); nxtRow++;
                            Console.Write("Enter New Stock: ");
                            string strStock = Console.ReadLine();
                            int.TryParse(strStock, out newStock);
                            if (newStock > 0)
                            {
                                database.Games.Where(g => g.Id == selectedIndex + 1).ExecuteUpdate(a => a.SetProperty(b => b.Stock, newStock));
                                database.SaveChanges();
                            }
                        }
                        else if (inputEdit == "5")
                        {
                            int newSold = 0;
                            Position.MoveCursorMainStart(nxtRow); nxtRow++;
                            Console.Write("Current Total Sold: " + games[selectedIndex].SoldTotal);
                            Position.MoveCursorMainStart(nxtRow); nxtRow++;
                            Console.Write("Enter New Total Sold: ");
                            string strSold = Console.ReadLine();
                            int.TryParse(strSold, out newSold);
                            if (newSold > 0)
                            {
                                database.Games.Where(g => g.Id == selectedIndex + 1).ExecuteUpdate(a => a.SetProperty(b => b.SoldTotal, newSold));
                                database.SaveChanges();
                            }
                        }
                        else if (inputEdit == "6")
                        {
                            int newRating = 0;
                            int ratingCounter = 1;
                            AgeRating newAgeRating = AgeRating.Mature;
                            foreach (var rating in ratings)
                            {
                                Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                Console.Write(ratingCounter + ": " + rating); ratingCounter++;
                            }
                            Position.MoveCursorMainStart(nxtRow); nxtRow++;
                            Console.Write("Current Rating: " + games[selectedIndex].AgeRating);
                            Position.MoveCursorMainStart(nxtRow); nxtRow++;
                            Console.Write("Enter New Rating: ");
                            string strRating = Console.ReadLine();
                            int.TryParse(strRating, out newRating);
                            if (newRating >= 1 && newRating <= 3)
                            {
                                if (newRating == 1)
                                {
                                    newAgeRating = AgeRating.Everyone;
                                }
                                if (newRating == 2)
                                {
                                    newAgeRating = AgeRating.Teen;
                                }
                                if (newRating == 3)
                                {
                                    newAgeRating = AgeRating.Mature;
                                }
                                database.Games.Where(g => g.Id == selectedIndex + 1).ExecuteUpdate(a => a.SetProperty(b => b.AgeRating, newAgeRating));
                                database.SaveChanges();
                            }
                        }
                        else if (inputEdit == "7")
                        {
                            if (games[selectedIndex].OnDisplay != 0)
                            {
                                Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                Console.Write("This game is already featured on the front page");
                                Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                Console.Write("Press [ANY] key to continue");
                                Console.ReadKey();
                                updated = 2;
                                break;
                            }
                            else
                            {


                                int newFeatured = 0;
                                int oldFeatured = 0;
                                for (int i = 1; i <= 3; i++)
                                {
                                    Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                    var gameTmp = database.Games.Where(g => g.OnDisplay == i).ToList();
                                    Console.Write(gameTmp[0].OnDisplay + " - " + gameTmp[0].Title);
                                }
                                Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                Console.Write("Current Featured Number: " + games[selectedIndex].OnDisplay);
                                Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                Console.Write("Enter New Placement: ");
                                string strFeatured = Console.ReadLine();
                                int.TryParse(strFeatured, out newFeatured);
                                if (newFeatured >= 1 && newFeatured <= 3)
                                {
                                    if (newFeatured == 1)
                                    {
                                        database.Games.Where(g => g.OnDisplay == 1).ExecuteUpdate(a => a.SetProperty(b => b.OnDisplay, 0));
                                        database.SaveChanges();
                                    }
                                    else if (newFeatured == 2)
                                    {
                                        database.Games.Where(g => g.OnDisplay == 2).ExecuteUpdate(a => a.SetProperty(b => b.OnDisplay, 0));
                                        database.SaveChanges();
                                    }
                                    else if (newFeatured == 3)
                                    {
                                        database.Games.Where(g => g.OnDisplay == 3).ExecuteUpdate(a => a.SetProperty(b => b.OnDisplay, 0));
                                        database.SaveChanges();
                                    }
                                    database.Games.Where(g => g.Id == selectedIndex + 1).ExecuteUpdate(a => a.SetProperty(b => b.OnDisplay, newFeatured));
                                    database.SaveChanges();
                                }
                            }
                        }
                        if (inputEdit == "8")
                        {
                            Position.MoveCursorMainStart(nxtRow); nxtRow++;
                            Console.Write("Enter New Short Info (Limited to 120 characters): ");
                            string newShort = Console.ReadLine();
                            if (newShort != "")
                            {
                                int shortLen = newShort.Length;
                                if (shortLen > 120)
                                {
                                    newShort = newShort.Remove(120) + "...";
                                }
                                newShort = Create.StringBreak(newShort, 46); // break lines at 46 chars
                                database.Games.Where(g => g.Id == selectedIndex + 1).ExecuteUpdate(a => a.SetProperty(b => b.ShortInfo, newShort));
                                database.SaveChanges();
                            }

                        }
                        if (inputEdit == "9")
                        {
                            Position.MoveCursorMainStart(nxtRow); nxtRow++;
                            Console.Write("Enter New Long Info (Limited to 420 characters): ");
                            string newLong = Console.ReadLine();
                            if (newLong != "")
                            {
                                int longLen = newLong.Length;
                                if (longLen > 420)
                                {
                                    newLong = newLong.Remove(420) + "...";
                                }
                                newLong = Create.StringBreak(newLong, 49); // break lines at 79 chars
                                database.Games.Where(g => g.Id == selectedIndex + 1).ExecuteUpdate(a => a.SetProperty(b => b.LongInfo, newLong));
                                database.SaveChanges();
                            }

                        }
                        updated = 2;
                    }
                    else if (updated == 1)
                    {
                        Position.MoveCursorMainStart(nxtRow); nxtRow++;
                        Console.WriteLine("Database Updated");
                        Position.MoveCursorMainStart(nxtRow); nxtRow++;
                        Console.WriteLine("Press [ANY] key to continue");
                        Console.ReadKey();
                        updated = 2; break;
                    }

                }
                return;
            }
        }
        public static void ReturnToMain(int menuLevel)
        {
            Gfx.WinIni();
            Gfx.ColorIni();
            TopMenu(Position.topX, Position.topY);
            SideMenu(menuLevel);
            Position.MoveCursorMainStart(0);
        }
        public static int KeyInput(int winX, int winY, int menuLevel)
        {
            int selectedGameId = 0;
            switch (menuLevel)
            {
                // Main Menu
                case 1:
                    {
                        while (true)
                        {

                            var userInputKey = Console.ReadKey(true);
                            if (userInputKey.Key == ConsoleKey.F1)
                            {
                                menuLevel = 1;
                                return menuLevel;
                            }
                            if (userInputKey.Key == ConsoleKey.F2)
                            {
                                menuLevel = 2;
                                return menuLevel;
                            }
                            if (userInputKey.Key == ConsoleKey.F3)
                            {
                                menuLevel = 3;
                                return menuLevel;
                            }
                            if (userInputKey.Key == ConsoleKey.A)
                            {
                                SelectGame(0, 666666);
                            } // Show All


                            if (userInputKey.Key == ConsoleKey.S)
                            {
                                ClearMainArea();
                                ClearFullSidemenu(7, 13);
                                int nxtRow = 0;
                                int selectedIndex = 0;
                                int selectedGenre = 0;
                                int pageLength = 8; // -------------------------------------  SET TO NUMBER OF GAMES LISTED PER PAGE ---------------------------
                                using (var database = new ShopDbContext())
                                {
                                    var genres = database.Genres.ToList();
                                    var games = database.Games.ToList();
                                    List<Game> genreGames = new List<Game>();

                                    for (int i = 0; i < genres.Count; i++)
                                    {
                                        Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                        Console.WriteLine($"{i + 1}. {genres[i].Name}");
                                    }
                                    Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                    Console.CursorSize = 100;
                                    Console.CursorVisible = true;
                                    Console.Write("Enter the number of the genre: ");
                                    if (int.TryParse(Console.ReadLine(), out selectedGenre) && selectedGenre >= 1 && selectedGenre <= genres.Count)
                                    {
                                        Console.CursorVisible = false;
                                        Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                        Console.WriteLine("Selected Genre: " + genres[selectedGenre - 1].Name);
                                        foreach (Game g in games)
                                        {
                                            if (g.GenreId == selectedGenre)
                                            {
                                                genreGames.Add(g);
                                            }
                                        }
                                        ClearMainArea();
                                        nxtRow = 0;
                                        for (int c = 0; c < genreGames.Count; c++)
                                        {
                                            Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                            Console.WriteLine($"{c + 1}. {genreGames[c].Title}");
                                        }
                                        Position.MoveCursorMainStart(nxtRow); nxtRow++;

                                        Console.Write("Enter Game Number or [ENTER] to Exit: ");
                                        if (int.TryParse(Console.ReadLine(), out selectedIndex) && selectedIndex >= 1 && selectedIndex <= games.Count)
                                        {
                                            selectedIndex -= 1;
                                            selectedIndex = genreGames[selectedIndex].Id;
                                            selectedIndex -= 1;
                                            while (selectedIndex != 999999)
                                            {
                                                ClearMainArea();
                                                if (selectedIndex < 0)
                                                {
                                                    selectedIndex = games.Count;
                                                }
                                                selectedIndex = MainView.DetailGame(selectedIndex, 1);
                                            }
                                            if (selectedIndex == 999999)
                                            {
                                                ClearMainArea();
                                                MainView.MainArea();
                                                MainMenu(7, 13, 1);
                                                Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                            }
                                            Console.CursorVisible = false;
                                        }
                                        else
                                        {
                                            MainView.MainArea();
                                            MainMenu(7, 13, 1);
                                            Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                        }
                                        Console.CursorVisible = false;
                                    }
                                } // Select Category



                                // --------------------------------------------------------------------------------------------------------------------


                                if (userInputKey.Key == ConsoleKey.D)
                                {
                                    ClearMainArea();
                                    Position.MoveCursorMainStart(0);
                                    Console.Write("Search");
                                } // Search
                                if (userInputKey.Key == ConsoleKey.F)
                                {
                                    ClearMainArea();
                                    Position.MoveCursorMainStart(0);
                                    Console.Write("Add to Basket");
                                } // Add to Basket
                                if (userInputKey.Key == ConsoleKey.D1)
                                {
                                    ClearMainArea();
                                    Position.MoveCursorMainStart(0);
                                    Console.Write("Selecting Game 1");
                                }
                                if (userInputKey.Key == ConsoleKey.D2)
                                {
                                    ClearMainArea();
                                    Position.MoveCursorMainStart(0);
                                    Console.Write("Selecting Game 2");
                                }
                                if (userInputKey.Key == ConsoleKey.D3)
                                {
                                    ClearMainArea();
                                    Position.MoveCursorMainStart(0);
                                    Console.Write("Selecting Game 3");
                                }
                            }
                            if (userInputKey.Key == ConsoleKey.D)
                            {
                                MainView.Search();
                            }
                            if (userInputKey.Key == ConsoleKey.D1)
                            {
                                MainView.FeaturedDetail(1);
                            }
                            if (userInputKey.Key == ConsoleKey.D2)
                            {
                                MainView.FeaturedDetail(2);
                            }
                            if (userInputKey.Key == ConsoleKey.D3)
                            {
                                MainView.FeaturedDetail(3);
                            }
                            // Show All
                        }
                    }

                // Shopping Basket
                case 2:
                    {
                        while (true)
                        {

                            var userInputKey = Console.ReadKey(true);
                            if (userInputKey.Key == ConsoleKey.F1)
                            {
                                menuLevel = 1;
                                return menuLevel;
                            }
                            if (userInputKey.Key == ConsoleKey.F2)
                            {
                                menuLevel = 2;
                                return menuLevel;
                            }
                            if (userInputKey.Key == ConsoleKey.F3)
                            {
                                menuLevel = 3;
                                return menuLevel;
                            }
                            if (userInputKey.Key == ConsoleKey.A)
                            {
                                ClearMainArea();
                                Position.MoveCursorMainStart(0);
                                using (var database = new ShopDbContext())
                                {
                                    var customers = database.Customers.ToList();
                                    var customer = customers.FirstOrDefault();
                                    ClearMainArea();
                                    BasketView.RemoveItemFromBasket(database, customer);
                                }
                                menuLevel = 2;
                                return menuLevel;
                            }
                            if (userInputKey.Key == ConsoleKey.S)
                            {
                                ClearMainArea();
                                Position.MoveCursorMainStart(0);
                                using (var database = new ShopDbContext())
                                {
                                    var customers = database.Customers.ToList();
                                    var customer = customers.FirstOrDefault();
                                    ClearMainArea();
                                    BasketView.PurchaseItems(database, customer);
                                }
                                menuLevel = 2;
                                return menuLevel;
                            }
                            if (userInputKey.Key == ConsoleKey.D)
                            {
                                ClearMainArea();
                                Position.MoveCursorMainStart(0);
                                using (var database = new ShopDbContext())
                                {
                                    var customers = database.Customers.ToList();
                                    var customer = customers.FirstOrDefault();
                                    ClearMainArea();
                                    BasketView.PurchaseHistory(database, customer);
                                }
                                menuLevel = 2;
                                return menuLevel;
                            }
                        }
                    }

                // Admin
                case 3:
                    {
                        while (true)
                        {

                            var userInputKey = Console.ReadKey(true);
                            if (userInputKey.Key == ConsoleKey.F1)
                            {
                                menuLevel = 1;
                                return menuLevel;
                            }
                            if (userInputKey.Key == ConsoleKey.F2)
                            {
                                menuLevel = 2;
                                return menuLevel;
                            }
                            if (userInputKey.Key == ConsoleKey.F3)
                            {
                                menuLevel = 3;
                                return menuLevel;
                            }
                            if (userInputKey.Key == ConsoleKey.A)
                            {
                                // Add Title
                                Admin.AdminTools(1);
                                menuLevel = 3;
                                return menuLevel;
                            }
                            if (userInputKey.Key == ConsoleKey.S)
                            {
                                // Remove Title
                                Admin.AdminTools(2);
                                menuLevel = 3;
                                return menuLevel;
                            }
                            if (userInputKey.Key == ConsoleKey.D)
                            {
                                // Change Title
                                Admin.AdminTools(3);
                                menuLevel = 3;
                                return menuLevel;
                            }
                            if (userInputKey.Key == ConsoleKey.F)
                            {
                                // List Titles
                                SelectGame(0, 666666);
                                menuLevel = 3;
                                return menuLevel;
                            }
                            if (userInputKey.Key == ConsoleKey.F)
                            {
                                // List Titles
                                SelectGame(0, 666666);
                                menuLevel = 3;
                                return menuLevel;
                            }
                            if (userInputKey.Key == ConsoleKey.G)
                            {
                                Admin.AdminTools(6);
                                menuLevel = 3;
                                return menuLevel;
                            }

                        }
                    }
                default:
                    break;

            }

            return menuLevel;
        }
    }
}
