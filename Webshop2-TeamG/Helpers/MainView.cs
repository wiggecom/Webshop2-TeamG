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
            Gfx.LongDNA(175, 2); // static spiral
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
        public static int DetailGame(int idNumber)
        {
            string ratingString = "";
            string infoString = "";
            using (var database = new ShopDbContext())
            {
                if (database.Games.Any() || database.Genres.Any())
                {
                    int gamesTotal = database.Games.Count();
                    var games = database.Games.Where(g => g.Id == idNumber + 1).ToList();
                    var genres = database.Genres.ToList();
                    // if game.ondisplay
                    ratingString = Enum.GetName(typeof(AgeRating), games[0].AgeRating);
                    infoString = games[0].LongInfo;
                    int posY = 11;
                    int posYReset = posY;
                    //posY -= 1; // raderna ska börja på 11, 23 och 35
                    int idStart = idNumber;
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

                    Console.SetCursorPosition(45, posY); posY++;
                    Console.Write("█     [Left/Right Arrow - Previous/Next Title]        [Spacebar - Add to basket]        [Escape - Exit to Main]      █");
                    Console.SetCursorPosition(45, posY); posY++;
                    Console.Write("█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█");
                    posY = posYReset + 1;


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

                    Gfx.ColorIni();
                    while (true)
                    {
                        var userInputKey = Console.ReadKey(true);
                        if (userInputKey.Key == ConsoleKey.Escape)
                        {
                            return 999999;
                        }
                        if (userInputKey.Key == ConsoleKey.LeftArrow)
                        {
                            idNumber--;
                            if (idNumber < 0)
                            {
                                idNumber = gamesTotal - 1;
                            }
                            //else
                            //{
                            //    idNumber = gamesTotal-1;
                            //}
                            return idNumber;
                        }
                        if (userInputKey.Key == ConsoleKey.RightArrow)
                        {
                            if (idNumber >= gamesTotal-1)
                            {
                                idNumber = 0;
                            }
                            else
                            {
                                idNumber++;
                            }

                            return idNumber;
                        }

                    }
                    Console.ReadKey();
                    return 1;
                    //return goBack;
                    // NEXT - PREVIOUS
                }
                else
                {
                    return 999999;
                }
            }
        }
    }
}

