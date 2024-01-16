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
                        menuLevel = MainMenu(winX, winY + 4, menuLevel);
                        break;
                    }
                case 2:
                    {
                        MenuTitle(winX, winY, "Shopping Basket");
                        menuLevel = BasketMenu(winX, winY + 4, menuLevel);
                        break;
                    }
                case 3:
                    {
                        MenuTitle(winX, winY, "Admin Menu");
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
            ClearFullSidemenu(winX, winY);
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
            Console.Write("1-9) Select Item");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("");
            //------------------------------
            CopyrightMenu(winX, winY + 32);
            menuLevel = KeyInput(40, 12, menuLevel);
            return menuLevel;
        }
        public static int BasketMenu(int winX, int winY, int menuLevel)
        {
            ClearFullSidemenu(winX, winY);
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
            ClearFullSidemenu(winX, winY);
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
            Console.Write("H) Add Sample Customer");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("--- Queries ---");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("J) Top Console");
            Console.SetCursorPosition(winX, winY + i); i++;
            Console.Write("K) Top Game");
            Console.SetCursorPosition(winX, winY + i); i++;
<<<<<<< Updated upstream
            Console.Write("K) Low Stock");
=======
            Console.Write("L) Low Stock");

>>>>>>> Stashed changes
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
        //public static void ClearMenuRow(int winX, int winY)
        //{
        //    Console.SetCursorPosition(winX, winY);
        //    Console.Write("                       ");
        //    Console.SetCursorPosition(winX, winY);
        //}
        public static void ClearFullSidemenu(int winX, int winY)
        {
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(winX, winY+i);
                Console.Write("                       ");
            }
        }
        public static int KeyInput(int winX, int winY, int menuLevel)
        {
            switch (menuLevel)
            {
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
<<<<<<< Updated upstream
                            if (userInputKey.Key == ConsoleKey.D1)
                            {
                                Admin.AdminTools(1);
                                //Admin.AddGame(menuX, menuY);
                            }
                            if (userInputKey.Key == ConsoleKey.D2)
                            {
                                break;
                            }
                            if (userInputKey.Key == ConsoleKey.D3)
                            {
                                break;
                            }
                            if (userInputKey.Key == ConsoleKey.D9)
                            {
                                try
                                {
                                    using (var database = new ShopDbContext())
                                    {
                                        Helpers.Create.FillDatabase(database);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.SetCursorPosition(30, 0);
                                    Console.WriteLine($"Error occured: {ex.Message}");
                                    Thread.Sleep(3000);
                                    Gfx.Frontend(0, 0);
                                    Gfx.ColorIni();
                                }

                                break;
=======
                            if (userInputKey.Key == ConsoleKey.A)
                            {
                                ClearMainArea();
                                MainView.MoveCursorMainStart();
                                Console.Write("Show All");
                            }
                            if (userInputKey.Key == ConsoleKey.S)
                            {
                                ClearMainArea();
                                MainView.MoveCursorMainStart();
                                Console.Write("Select Category");
                            }
                            if (userInputKey.Key == ConsoleKey.D)
                            {
                                ClearMainArea();
                                MainView.MoveCursorMainStart();
                                Console.Write("Search");
                            }
                            if (userInputKey.Key == ConsoleKey.F)
                            {
                                ClearMainArea();
                                MainView.MoveCursorMainStart();
                                Console.Write("Add to Basket");
                            }
                            if (userInputKey.Key == ConsoleKey.D1)
                            {
                                ClearMainArea();
                                MainView.MoveCursorMainStart();
                                Console.Write("Selecting Game 1");
                            }
                            if (userInputKey.Key == ConsoleKey.D2)
                            {
                                ClearMainArea();
                                MainView.MoveCursorMainStart();
                                Console.Write("Selecting Game 2");
                            }
                            if (userInputKey.Key == ConsoleKey.D3)
                            {
                                ClearMainArea();
                                MainView.MoveCursorMainStart();
                                Console.Write("Selecting Game 3");
                            }
                            if (userInputKey.Key == ConsoleKey.D4)
                            {
                                ClearMainArea();
                                MainView.MoveCursorMainStart();
                                Console.Write("Selecting Game 4");
                            }
                            if (userInputKey.Key == ConsoleKey.D5)
                            {
                                ClearMainArea();
                                MainView.MoveCursorMainStart();
                                Console.Write("Selecting Game 5");
                            }
                            if (userInputKey.Key == ConsoleKey.D6)
                            {
                                ClearMainArea();
                                MainView.MoveCursorMainStart();
                                Console.Write("Selecting Game 6");
                            }
                            if (userInputKey.Key == ConsoleKey.D7)
                            {
                                ClearMainArea();
                                MainView.MoveCursorMainStart();
                                Console.Write("Selecting Game 7");
                            }
                            if (userInputKey.Key == ConsoleKey.D8)
                            {
                                ClearMainArea();
                                MainView.MoveCursorMainStart();
                                Console.Write("Selecting Game 8");
                            }
                            if (userInputKey.Key == ConsoleKey.D9)
                            {
                                ClearMainArea();
                                MainView.MoveCursorMainStart();
                                Console.Write("Selecting Game 9");
>>>>>>> Stashed changes
                            }
                        }
                        break;
                    }
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
<<<<<<< Updated upstream
                            if (userInputKey.Key == ConsoleKey.D1)
                            {
                                Admin.AdminTools(1);
                                //Admin.AddGame(menuX, menuY);
                            }
                            if (userInputKey.Key == ConsoleKey.D2)
                            {
                                break;
                            }
                            if (userInputKey.Key == ConsoleKey.D3)
                            {
                                break;
                            }
                            if (userInputKey.Key == ConsoleKey.D9)
                            {
                                try
                                {
                                    using (var database = new ShopDbContext())
                                    {
                                        Helpers.Create.FillDatabase(database);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.SetCursorPosition(30, 0);
                                    Console.WriteLine($"Error occured: {ex.Message}");
                                    Thread.Sleep(3000);
                                    Gfx.Frontend(0, 0);
                                    Gfx.ColorIni();
                                }

                                break;
=======
                            if (userInputKey.Key == ConsoleKey.A)
                            {
                                ClearMainArea();
                                MainView.MoveCursorMainStart();
                                Console.Write("Add Item");
                            }
                            if (userInputKey.Key == ConsoleKey.S)
                            {
                                ClearMainArea();
                                MainView.MoveCursorMainStart();
                                Console.Write("Empty Basket");
                            }
                            if (userInputKey.Key == ConsoleKey.D)
                            {
                                ClearMainArea();
                                MainView.MoveCursorMainStart();
                                Console.Write("Delete Item");
                            }
                            if (userInputKey.Key == ConsoleKey.F)
                            {
                                ClearMainArea();
                                MainView.MoveCursorMainStart();
                                Console.Write("Checkout");
                            }
                            if (userInputKey.Key == ConsoleKey.D1)
                            {
                                ClearMainArea();
                                MainView.MoveCursorMainStart();
                                Console.Write("Selecting Game 1");
                            }
                            if (userInputKey.Key == ConsoleKey.D2)
                            {
                                ClearMainArea();
                                MainView.MoveCursorMainStart();
                                Console.Write("Selecting Game 2");
                            }
                            if (userInputKey.Key == ConsoleKey.D3)
                            {
                                ClearMainArea();
                                MainView.MoveCursorMainStart();
                                Console.Write("Selecting Game 3");
                            }
                            if (userInputKey.Key == ConsoleKey.D4)
                            {
                                ClearMainArea();
                                MainView.MoveCursorMainStart();
                                Console.Write("Selecting Game 4");
                            }
                            if (userInputKey.Key == ConsoleKey.D5)
                            {
                                ClearMainArea();
                                MainView.MoveCursorMainStart();
                                Console.Write("Selecting Game 5");
                            }
                            if (userInputKey.Key == ConsoleKey.D6)
                            {
                                ClearMainArea();
                                MainView.MoveCursorMainStart();
                                Console.Write("Selecting Game 6");
                            }
                            if (userInputKey.Key == ConsoleKey.D7)
                            {
                                ClearMainArea();
                                MainView.MoveCursorMainStart();
                                Console.Write("Selecting Game 7");
                            }
                            if (userInputKey.Key == ConsoleKey.D8)
                            {
                                ClearMainArea();
                                MainView.MoveCursorMainStart();
                                Console.Write("Selecting Game 8");
                            }
                            if (userInputKey.Key == ConsoleKey.D9)
                            {
                                ClearMainArea();
                                MainView.MoveCursorMainStart();
                                Console.Write("Selecting Game 9");
>>>>>>> Stashed changes
                            }
                        }
                        break;
                    }
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
                            if (userInputKey.Key == ConsoleKey.D1)
                            {
                                Admin.AdminTools(1);
                                //Admin.AddGame(menuX, menuY);
                            }
                            if (userInputKey.Key == ConsoleKey.D2)
                            {
                                break;
                            }
                            if (userInputKey.Key == ConsoleKey.D3)
                            {
                                break;
                            }
                            if (userInputKey.Key == ConsoleKey.D9)
                            {
                                try
                                {
                                    using (var database = new ShopDbContext())
                                    {
                                        Helpers.Create.FillDatabase(database);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.SetCursorPosition(30, 0);
                                    Console.WriteLine($"Error occured: {ex.Message}");
                                    Thread.Sleep(3000);
                                    Gfx.Frontend(0, 0);
                                    Gfx.ColorIni();
                                }

                                break;
                            }
                        }
                        break;
                    }
            }
            return menuLevel;
        }
    }
}
