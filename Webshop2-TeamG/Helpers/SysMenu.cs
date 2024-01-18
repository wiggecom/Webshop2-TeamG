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
            Console.SetCursorPosition(topX + i, topY);
            Console.Write("[User Name]");
            Console.SetCursorPosition(topX + i, topY + 1);
            Console.Write("                       ");
            Console.SetCursorPosition(topX + i, topY + 1);
            Console.Write("[Basket has ## Items]");
            Console.SetCursorPosition(topX + i, topY + 2);
            Console.Write("                       ");
            Console.SetCursorPosition(topX + i, topY + 2);
            Console.Write("[Basket ####SEK Total]");
        }
        public static int SideMenu(int winX, int winY, int menuLevel)
        {
            // Stay in each submenu unless menuLevel changes
            switch (menuLevel)
            {
                case 1:
                    {
                        MenuTitle(winX, winY, "Main Menu");
                        ClearMainArea();
                        menuLevel = MainMenu(winX, winY + 4, menuLevel);
                        break;
                    }
                case 2:
                    {
                        MenuTitle(winX, winY, "Shopping Basket");
                        ClearMainArea();
                        menuLevel = BasketMenu(winX, winY + 4, menuLevel);
                        break;
                    }
                case 3:
                    {
                        MenuTitle(winX, winY, "Admin Menu");
                        ClearMainArea();
                        menuLevel = AdminMenu(winX, winY + 4, menuLevel);
                        break;
                    }

            }
            return menuLevel;
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
        public static int MainMenu(int winX, int winY, int menuLevel)
        {
            int i = 0;
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("A) Show All");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("S) Select Category");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("D) Search");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("F) Add to Basket");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("*1-9) Select Item");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("   * Unused");
            //------------------------------
            CopyrightMenu(winX, winY + 32);
            MainView.MainArea();
            menuLevel = KeyInput(40, 12, menuLevel);
            return menuLevel;
        }
        public static int BasketMenu(int winX, int winY, int menuLevel)
        {
            //ClearFullSidemenu(winX, winY);
            int i = 0;
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("1-9) Select Item");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("A) Add Item");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("S) Empty Basket");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("D) Delete Item");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("F) Checkout");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("");
            //------------------------------
            CopyrightMenu(winX, winY + 32);
            menuLevel = KeyInput(40, 12, menuLevel);
            return menuLevel;
        }
        public static int AdminMenu(int winX, int winY, int menuLevel)
        {
            //ClearFullSidemenu(winX, winY);
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
            Console.Write("G) Add Sample Data");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("H) Sample Customers");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("--- Queries ---");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("J) Top Console");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("K) Top Game");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("L) Low Stock");

            //------------------------------
            CopyrightMenu(winX, winY + 32);
            menuLevel = KeyInput(40, 12, menuLevel);
            return menuLevel;
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
                                ClearMainArea();
                                int nxtRow = 0;
                                int selectedIndex = 0;
                                int pageLength = 8; // -------------------------------------  SET TO NUMBER OF GAMES LISTED PER PAGE ---------------------------
                                using (var database = new ShopDbContext())
                                {
                                    var games = database.Games.ToList();
                                    for (int i = 0; i < games.Count; i++)
                                    {
                                        Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                        Console.WriteLine($"{i + 1}. {games[i].Title}");
                                        if (nxtRow >= pageLength)
                                        {
                                            Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                            Console.Write("Enter Game Number or [ENTER] to Continue: ");
                                            Console.CursorVisible = true;
                                            int.TryParse(Console.ReadLine(), out selectedIndex);
                                            Console.CursorVisible = false;
                                            if (selectedIndex >= 1 && selectedIndex <= games.Count)
                                            {
                                                selectedIndex -= 1;
                                                Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                                Console.WriteLine("Selected Game: " + games[selectedIndex].Title);
                                                //MainView.DetailGame(selectedIndex);
                                                while (selectedIndex != 999999)
                                                {
                                                    ClearMainArea();
                                                    selectedIndex = MainView.DetailGame(selectedIndex);
                                                }
                                                if (selectedIndex == 999999)
                                                {
                                                    ClearMainArea();
                                                    MainView.MainArea();
                                                    Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                                }
                                                break;
                                            }
                                            Console.CursorVisible = false;
                                            ClearMainArea();
                                            nxtRow = 0;
                                        }
                                    }
                                    Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                    Console.CursorSize = 100;
                                    Console.CursorVisible = true;
                                    Console.Write("Enter Game Number or [ENTER] to Exit: ");
                                    int.TryParse(Console.ReadLine(), out selectedIndex);
                                    Console.CursorVisible = false;
                                    if (selectedIndex >= 1 && selectedIndex <= games.Count)
                                    {
                                        selectedIndex -= 1;
                                        Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                        Console.WriteLine("Selected Game: " +games[selectedIndex].Title);
                                        //MainView.DetailGame(selectedIndex);
                                        while (selectedIndex != 999999)
                                        {
                                            ClearMainArea();
                                            selectedIndex = MainView.DetailGame(selectedIndex);
                                        }
                                        if (selectedIndex == 999999)
                                        {
                                            ClearMainArea();
                                            MainView.MainArea();
                                            Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                        }
                                        //return games[selectedIndex - 1];
                                    }
                                    else
                                    {
                                        MainView.MainArea();
                                        Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                        //Console.WriteLine("Invalid selection. Returning null.");
                                        //return null;
                                    }
                                    Console.CursorVisible = false;
                                }
                            //Console.Write("Show All");
                            } // Show All
                            if (userInputKey.Key == ConsoleKey.S)
                            {
                                //ClearMainArea();
                                //Position.MoveCursorMainStart(0);
                                //Console.Write("Select Category");

                                ClearMainArea();
                                int nxtRow = 0;
                                using (var database = new ShopDbContext())
                                {
                                    var genres = database.Genres.ToList();
                                    for (int i = 0; i < genres.Count; i++)
                                    {
                                        Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                        Console.WriteLine($"{i + 1}. {genres[i].Name}");
                                    }
                                    Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                    Console.CursorSize = 100;
                                    Console.CursorVisible = true;
                                    Console.Write("Enter the number of the genre: ");
                                    if (int.TryParse(Console.ReadLine(), out int selectedIndex) && selectedIndex >= 1 && selectedIndex <= genres.Count)
                                    {
                                        selectedIndex -= 1;
                                        Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                        Console.WriteLine("Selected Genre: " + genres[selectedIndex].Name);
                                        //return games[selectedIndex - 1];
                                    }
                                    else
                                    {
                                        Position.MoveCursorMainStart(nxtRow); nxtRow++;
                                        Console.WriteLine("Invalid selection. Returning null.");
                                        //return null;
                                    }
                                    Console.CursorVisible = false;
                                }
                            } // Select Category
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
                            if (userInputKey.Key == ConsoleKey.D4)
                            {
                                ClearMainArea();
                                Position.MoveCursorMainStart(0);
                                Console.Write("Selecting Game 4");
                            }
                            if (userInputKey.Key == ConsoleKey.D5)
                            {
                                ClearMainArea();
                                Position.MoveCursorMainStart(0);
                                Console.Write("Selecting Game 5");
                            }
                            if (userInputKey.Key == ConsoleKey.D6)
                            {
                                ClearMainArea();
                                Position.MoveCursorMainStart(0);
                                Console.Write("Selecting Game 6");
                            }
                            if (userInputKey.Key == ConsoleKey.D7)
                            {
                                ClearMainArea();
                                Position.MoveCursorMainStart(0);
                                Console.Write("Selecting Game 7");
                            }
                            if (userInputKey.Key == ConsoleKey.D8)
                            {
                                ClearMainArea();
                                Position.MoveCursorMainStart(0);
                                Console.Write("Selecting Game 8");
                            }
                            if (userInputKey.Key == ConsoleKey.D9)
                            {
                                ClearMainArea();
                                Position.MoveCursorMainStart(0);
                                Console.Write("Selecting Game 9");
                            }
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
                                Console.Write("Add Item");
                            }
                            if (userInputKey.Key == ConsoleKey.S)
                            {
                                ClearMainArea();
                                Position.MoveCursorMainStart(0);
                                Console.Write("Empty Basket");
                            }
                            if (userInputKey.Key == ConsoleKey.D)
                            {
                                ClearMainArea();
                                Position.MoveCursorMainStart(0);
                                Console.Write("Delete Item");
                            }
                            if (userInputKey.Key == ConsoleKey.F)
                            {
                                ClearMainArea();
                                Position.MoveCursorMainStart(0);
                                Console.Write("Checkout");
                            }
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
                            if (userInputKey.Key == ConsoleKey.D4)
                            {
                                ClearMainArea();
                                Position.MoveCursorMainStart(0);
                                Console.Write("Selecting Game 4");
                            }
                            if (userInputKey.Key == ConsoleKey.D5)
                            {
                                ClearMainArea();
                                Position.MoveCursorMainStart(0);
                                Console.Write("Selecting Game 5");
                            }
                            if (userInputKey.Key == ConsoleKey.D6)
                            {
                                ClearMainArea();
                                Position.MoveCursorMainStart(0);
                                Console.Write("Selecting Game 6");
                            }
                            if (userInputKey.Key == ConsoleKey.D7)
                            {
                                ClearMainArea();
                                Position.MoveCursorMainStart(0);
                                Console.Write("Selecting Game 7");
                            }
                            if (userInputKey.Key == ConsoleKey.D8)
                            {
                                ClearMainArea();
                                Position.MoveCursorMainStart(0);
                                Console.Write("Selecting Game 8");
                            }
                            if (userInputKey.Key == ConsoleKey.D9)
                            {
                                ClearMainArea();
                                Position.MoveCursorMainStart(0);
                                Console.Write("Selecting Game 9");
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
                                Admin.AdminTools(1);
                            }
                            if (userInputKey.Key == ConsoleKey.S)
                            {
                                Admin.AdminTools(2);
                            }
                            if (userInputKey.Key == ConsoleKey.D)
                            {
                                Admin.AdminTools(3);
                            }
                            if (userInputKey.Key == ConsoleKey.F)
                            {
                                Admin.AdminTools(4);
                            }
                            if (userInputKey.Key == ConsoleKey.G)
                            {
                                Admin.AdminTools(5);
                            }
                            if (userInputKey.Key == ConsoleKey.H)
                            {
                                Admin.AdminTools(6);
                            }
                            if (userInputKey.Key == ConsoleKey.J)
                            {
                                Admin.AdminTools(7);
                            }
                            if (userInputKey.Key == ConsoleKey.K)
                            {
                                Admin.AdminTools(8);
                            }
                            if (userInputKey.Key == ConsoleKey.L)
                            {
                                Admin.AdminTools(9);
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
