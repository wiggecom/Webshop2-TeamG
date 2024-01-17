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
        }
        public static void Featured(int featuredNumber)
        {
            string titleString = "";
            string genreString = "Tmp Genre";
            string ratingString = "Tmp Rating";
            string infoString = "";
            using (var database = new ShopDbContext())
            {
                var games = database.Games.Where(g => g.OnDisplay == featuredNumber).ToList();
                // if game.ondisplay

                titleString = games[0].Title;
                // genreString = games[featuredNumber].Genre.ToString();
                // ratingString = games[featuredNumber].Genre.ToString();
                infoString = games[0].ShortInfo;
                //for (int i = 0; i < games.Count; i++)
                //{
                //    Console.WriteLine($"{i + 1}. {games[i].Title}");
                //}
                // sök efter data i databasen, lägg i variabler som ska visas eg. titleString, genreString etc.
                featuredNumber *= 10;
                featuredNumber += 2; // raderna ska börja på 12, 22 och 32
                int featuredStart = featuredNumber;
                Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
                Console.Write("█▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█");
                //Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
                //Console.Write("█ Title blah blah                                        █");

                Console.SetCursorPosition(45, featuredNumber);
                Console.Write("█ " + titleString);
                Console.SetCursorPosition(45 + 57, featuredNumber); featuredNumber++;
                Console.Write("█");
                Console.SetCursorPosition(45, featuredNumber);
                Console.Write("█ " + genreString);
                Console.SetCursorPosition(45 + 57, featuredNumber); featuredNumber++;
                Console.Write("█");
                Console.SetCursorPosition(45, featuredNumber);
                Console.Write("█ " + ratingString);
                Console.SetCursorPosition(45 + 57, featuredNumber); featuredNumber++;
                Console.Write("█");
                Console.SetCursorPosition(45, featuredNumber);
                Console.Write("█ " + infoString);
                Console.SetCursorPosition(45 + 57, featuredNumber); featuredNumber++;
                Console.Write("█");

                // Alternativ: lägg in databasens objekt.info direkt

                //Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
                //Console.Write("█ Genre                                                  █");
                //Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
                //Console.Write("█ Age Rating                                             █");
                //Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
                //Console.Write("█ Short Info                                             █");
                Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
                Console.Write("█                                                        █");
                Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
                Console.Write("█                                                        █");
                Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
                Console.Write("█                                                        █");
                Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
                Console.Write("█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█");
                // ▄ ▀
                //featuredNumber = featuredStart + 1;
                //Console.SetCursorPosition(77, featuredNumber); featuredNumber++;
                //Console.Write("████████████████████████");
                //Console.SetCursorPosition(77, featuredNumber); featuredNumber++;
                //Console.Write("█        Very          █");
                //Console.SetCursorPosition(77, featuredNumber); featuredNumber++;
                //Console.Write("█                      █");
                //Console.SetCursorPosition(77, featuredNumber); featuredNumber++;
                //Console.Write("█        Cool          █");
                //Console.SetCursorPosition(77, featuredNumber); featuredNumber++;
                //Console.Write("█                      █");
                //Console.SetCursorPosition(77, featuredNumber); featuredNumber++;
                //Console.Write("█        Image         █");
                //Console.SetCursorPosition(77, featuredNumber); featuredNumber++;
                //Console.Write("████████████████████████");
            }
        }
    }
}

