using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop2_TeamG.Models;

namespace Webshop2_TeamG.Helpers
{
    internal class MainView
    {
        public static void MainArea()
        {
            for (int i = 1; i < 4; i++)
            {
                Featured(i);
            }
            //Gfx.LongDNA(175, 2); // static spiral
            Gfx.ColorIni();
            //Gfx.Icons5(170, 8, 1);
            //Gfx.LowDNA(175, 8);
        }
        public static void Featured(int featuredNumber)
        {
            string ratingString = "";
            string infoString = "";
            using (var database = new ShopDbContext())
            {
                if (database.Games.Any() || database.Genres.Any())
                {
                    var games = database.Games.Where(g => g.OnDisplay == featuredNumber).ToList();
                    var genres = database.Genres.ToList();
                    // if game.ondisplay
                    ratingString = Enum.GetName(typeof(AgeRating), games[0].AgeRating);
                    infoString = games[0].ShortInfo;
                    featuredNumber *= 12;
                    featuredNumber -= 1; // raderna ska börja på 11, 23 och 35
                    int featuredStart = featuredNumber;
                    Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
                    Console.Write("█▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█");
                    Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
                    Console.Write("█                                                                            █");
                    Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
                    Console.Write("█                                                                            █");
                    Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
                    Console.Write("█                                                                            █");
                    Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
                    Console.Write("█                                                                            █");
                    Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
                    Console.Write("█                                                                            █");
                    Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
                    Console.Write("█                                                                            █");
                    Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
                    Console.Write("█                                                                            █");
                    Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
                    Console.Write("█                                                                            █");
                    Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
                    Console.Write("█                                                                            █");
                    Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
                    Console.Write("█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█");
                    featuredNumber = featuredStart + 1;


                    int underscoreLength = games[0].Title.Length;
                    string titleUnderscore = new string('▀', underscoreLength);

                    Console.SetCursorPosition(47, featuredNumber); featuredNumber++;
                    Console.Write(games[0].Title);
                    Console.SetCursorPosition(47, featuredNumber); featuredNumber++;
                    Console.Write(titleUnderscore);
                    Console.SetCursorPosition(47, featuredNumber); featuredNumber++;
                    Console.Write("Genre: " + genres[(games[0].GenreId - 1)].Name);
                    Console.SetCursorPosition(47, featuredNumber); featuredNumber++;
                    Console.Write("Rating: " + ratingString);
                    Console.SetCursorPosition(47, featuredNumber); featuredNumber++;
                    Console.Write("Price: " + games[0].Price + " SEK");
                    foreach (var line in infoString.Split('\n'))
                    {
                        Console.SetCursorPosition(49, featuredNumber); featuredNumber++;
                        Console.Write(line);
                    }

                    // Alternativ: lägg in databasens objekt.info direkt med lambda

                    // ▄ ▀
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Black;
                    featuredNumber = featuredStart + 1;
                    Console.SetCursorPosition(97, featuredNumber); featuredNumber++;
                    Console.Write("█▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█");
                    Console.SetCursorPosition(97, featuredNumber); featuredNumber++;
                    Console.Write("█      Incredibly      █");
                    Console.SetCursorPosition(97, featuredNumber); featuredNumber++;
                    Console.Write("█                      █");
                    Console.SetCursorPosition(97, featuredNumber); featuredNumber++;
                    Console.Write("█        Cool          █");
                    Console.SetCursorPosition(97, featuredNumber); featuredNumber++;
                    Console.Write("█                      █");
                    Console.SetCursorPosition(97, featuredNumber); featuredNumber++;
                    Console.Write("█       Image          █");
                    Console.SetCursorPosition(97, featuredNumber); featuredNumber++;
                    Console.Write("█                      █");
                    Console.SetCursorPosition(97, featuredNumber); featuredNumber++;
                    Console.Write("█        Here          █");
                    Console.SetCursorPosition(97, featuredNumber); featuredNumber++;
                    Console.Write("█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█");

                    // CallImage
                    int iconNum = games[0].GenreId;
                    Gfx.Icons5(98, featuredStart + 2, iconNum);
                    //

                    Gfx.ColorIni();
                }
            }
        }
        public static int DetailGame(int idNumber, int browsable)
        {
            string ratingString = "";
            string infoString = "";
            using (var database = new ShopDbContext())
            {
                if (database.Games.Any() && database.Genres.Any())
                {
                    
                    int gamesTotal = database.Games.Count();
                    var allGames = database.Games.ToList();
                    //idNumber = allGames[idNumber].Id;

                    var games = database.Games.Where(g => g.Id == idNumber + 1).ToList(); // idNumber + 1
                    var genres = database.Genres.ToList();
                    // if game.ondisplay
                    ratingString = Enum.GetName(typeof(AgeRating), games[0].AgeRating);
                    infoString = games[0].LongInfo;
                    int posY = 11;
                    int posYReset = posY;
                    //posY -= 1; // raderna ska börja på 11, 23 och 35
                    int idStart = idNumber;
                    #region gfxFrame
                    Console.SetCursorPosition(45, posY); posY++;
                    Console.Write("█▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█");
                    Console.SetCursorPosition(45, posY); posY++;
                    Console.Write("█                                                                                                                    █");
                    Console.SetCursorPosition(45, posY); posY++;
                    Console.Write("█                                                                                                                    █");
                    Console.SetCursorPosition(45, posY); posY++;
                    Console.Write("█                                                                                                                    █");
                    Console.SetCursorPosition(45, posY); posY++;
                    Console.Write("█                                                                                                                    █");
                    Console.SetCursorPosition(45, posY); posY++;
                    Console.Write("█                                                                                                                    █");
                    Console.SetCursorPosition(45, posY); posY++;
                    Console.Write("█                                                                                                                    █");
                    Console.SetCursorPosition(45, posY); posY++;
                    Console.Write("█                                                                                                                    █");
                    Console.SetCursorPosition(45, posY); posY++;
                    Console.Write("█                                                                                                                    █");
                    Console.SetCursorPosition(45, posY); posY++;
                    Console.Write("█                                                                                                                    █");
                    Console.SetCursorPosition(45, posY); posY++;
                    Console.Write("█                                                                                                                    █");
                    Console.SetCursorPosition(45, posY); posY++;
                    Console.Write("█                                                                                                                    █");
                    Console.SetCursorPosition(45, posY); posY++;
                    Console.Write("█                                                                                                                    █");
                    Console.SetCursorPosition(45, posY); posY++;
                    Console.Write("█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█");
                    if (browsable == 1) 
                    { 
                    Console.SetCursorPosition(45, posY); posY++;
                    Console.Write("█     [Left/Right Arrow - Previous/Next Title]        [Spacebar - Add to basket]        [Escape - Exit to Main]      █");
                    Console.SetCursorPosition(45, posY); posY++;
                    Console.Write("█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█");
                    }
                    posY = posYReset + 1;
                    #endregion

                    int underscoreLength = games[0].Title.Length;
                    string titleUnderscore = new string('▀', underscoreLength);

                    Console.SetCursorPosition(47, posY); posY++;
                    Console.Write(games[0].Title);
                    Console.SetCursorPosition(47, posY); posY++;
                    Console.Write(titleUnderscore);
                    Console.SetCursorPosition(47, posY); posY++;
                    Console.Write("Genre: " + genres[(games[0].GenreId - 1)].Name);
                    Console.SetCursorPosition(47, posY); posY++;
                    Console.Write("Rating: " + ratingString);
                    Console.SetCursorPosition(47, posY); posY++;
                    Console.Write("Price: " + games[0].Price + " SEK");
                    foreach (var line in infoString.Split('\n'))
                    {
                        Console.SetCursorPosition(49, posY); posY++;
                        Console.Write(line);
                    }

                    // Alternativ: lägg in databasens objekt.info direkt med lambda

                    // ▄ ▀
                    #region iconFrame
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Black;
                    posY = posYReset + 1;
                    Console.SetCursorPosition(130, posY); posY++;
                    Console.Write("█▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█");
                    Console.SetCursorPosition(130, posY); posY++;
                    Console.Write("█      Incredibly      █");
                    Console.SetCursorPosition(130, posY); posY++;
                    Console.Write("█                      █");
                    Console.SetCursorPosition(130, posY); posY++;
                    Console.Write("█        Cool          █");
                    Console.SetCursorPosition(130, posY); posY++;
                    Console.Write("█                      █");
                    Console.SetCursorPosition(130, posY); posY++;
                    Console.Write("█       Image          █");
                    Console.SetCursorPosition(130, posY); posY++;
                    Console.Write("█                      █");
                    Console.SetCursorPosition(130, posY); posY++;
                    Console.Write("█        Here          █");
                    Console.SetCursorPosition(130, posY); posY++;
                    Console.Write("█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█");

                    // CallImage
                    int iconNum = games[0].GenreId;
                    Gfx.Icons5(131, posYReset + 2, iconNum);
                    //
                    #endregion
                    Gfx.ColorIni();
                    if (browsable == 1)
                    {

                    
                    while (true)
                    {
                        var userInputKey = Console.ReadKey(true);
                        if (userInputKey.Key == ConsoleKey.Escape)
                        {
                                SysMenu.ReturnToMain();
                                return 999999;
                        }
                        if (userInputKey.Key == ConsoleKey.LeftArrow)
                        {
                            idNumber--;
                            if (idNumber < 0)
                            {
                                idNumber = gamesTotal - 1;
                            }
                            return idNumber;
                        }
                        if (userInputKey.Key == ConsoleKey.RightArrow)
                        {
                                idNumber++;
                            if (idNumber >= gamesTotal-1)
                            {
                                idNumber = 0;
                            }
                            //while (true)
                            //    {
                            //        if (database.Games.Any(g => g.Id == idNumber - 1) && idNumber < allGames.Count())
                            //        {
                            //            break;
                            //        }
                            //        else if (database.Games.Any(g => g.Id == idNumber - 1) && idNumber == allGames.Count()) 
                            //        {
                            //            idNumber = 0;
                            //            break; 
                            //        }
                            //        else 
                            //        { 
                            //            idNumber++;
                            //        }
                            //    }
                                //idNumber = games[idNumber-1].Id;
                                return idNumber;
                        }

                    }
                    
                }
                else
                {
                        SysMenu.ReturnToMain();
                    return 999999;
                }
                }
                SysMenu.ReturnToMain();
                return 999999;
            }
        }
        public static void Search()
        {
            int selectedIndex = 0;
            string ratingString = "";
            string infoString = "";
            int rowStep = 0;
            using (var database = new ShopDbContext())
            {
                if (database.Games.Any() || database.Genres.Any())
                {
                    string searchTerm = "exit";
                    SysMenu.ClearAllAreas();
                    Position.MoveCursorMainStart(rowStep);
                    Console.Write("Please enter text to search for, [ENTER] to exit: ");
                    searchTerm = Console.ReadLine();
                    while (searchTerm.Length < 3)
                    {
                        if (searchTerm.Length < 3)
                        {
                            Position.MoveCursorMainStart(rowStep);
                            Console.Write("                                                                                  ");
                            Position.MoveCursorMainStart(rowStep);
                            Console.Write("Minimum search is 3 characters, please try again or [ENTER] to exit: ");
                            searchTerm = Console.ReadLine();
                        }
                        if (searchTerm == "")
                        {
                            SysMenu.ClearAllAreas();
                            SysMenu.ReturnToMain();
                            break;
                        }
                    }
                    rowStep++;
                    rowStep++;
                    int counter = 1;
                    var genres = database.Genres.ToList();
                    var games = database.Games.Where(g => g.Title.Contains(searchTerm) || g.ShortInfo.Contains(searchTerm) || g.LongInfo.Contains(searchTerm) || g.Genre.Name.Contains(searchTerm)).ToList();
                    foreach (var game in games)
                    {
                        Position.MoveCursorMainStart(rowStep); rowStep++;
                        Console.Write(counter + " - " + game.Title + " - [" + genres[game.GenreId-1].Name + "]"); counter++;
                        Position.MoveCursorMainStart(rowStep); rowStep++;
                        string gameDesc = game.ShortInfo.Replace("\r\n", " ");
                        Console.Write(gameDesc); rowStep++;

                    }
                    if (games.Count == 0)
                    {
                        Position.MoveCursorMainStart(rowStep);
                        Console.WriteLine("No games found, press any key to continue");
                        Console.ReadKey();
                        SysMenu.ClearAllAreas();
                        SysMenu.ReturnToMain();
                    }
                    Position.MoveCursorMainStart(rowStep); rowStep++;
                    Console.Write("Enter game number or [ENTER] to X-it: ");
                    Console.CursorVisible = true;
                    int.TryParse(Console.ReadLine(), out selectedIndex);
                    Console.CursorVisible = false;
                    rowStep++;
                    Position.MoveCursorMainStart(rowStep); rowStep++;
                    if (selectedIndex != 0 && selectedIndex != null)
                    {
                        Console.WriteLine("Selected game: " + games[selectedIndex - 1].Title + " - Id: " + games[selectedIndex - 1].Id);
                        int gameId = games[selectedIndex - 1].Id - 1;
                        //Console.ReadKey();
                        SysMenu.ClearAllAreas();
                        SysMenu.SelectGame(0, gameId);
                    }
                    else
                    {
                        SysMenu.ClearAllAreas();
                        SysMenu.ReturnToMain();
                    }
                }
            }
        }
        public static void BasketCase()  // rework to separate method for all info that needs positioning
        {
            string testString = "The quick brown fox jumped over the lazy dog";
            SysMenu.ClearMainArea();
            Position.MoveCursorMainStart(0);
            int rowLength = 20;
            testString = Create.StringBreak(testString, rowLength);
            int posY = 0;
            int posX = 45;
            foreach (var line in testString.Split('\n'))
            {
                Position.MoveCursorTextAnywhere(posX, posY); posY++;
                Console.Write(line);
            }
        }
    }
}

