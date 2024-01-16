using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2_TeamG.Helpers
{
    internal class MainView
    {
        public static void MoveCursorMainStart()
        {
            Console.SetCursorPosition(45, 12);
        }
        public static void MainArea() 
        { 
            for (int i = 1; i < 4; i++)
            {
                Featured(i);
            }
        }
        public static void Featured(int featuredNumber)
        {
            featuredNumber *= 10;
            featuredNumber += 2;
            int featuredStart = featuredNumber;
            Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
            Console.Write("█▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█");
            Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
            Console.Write("█ Title blah blah                                        █");
            Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
            Console.Write("█ Genre                                                  █");
            Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
            Console.Write("█ Age Rating                                             █");
            Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
            Console.Write("█ Short Info                                             █");
            Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
            Console.Write("█                                                        █");
            Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
            Console.Write("█                                                        █");
            Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
            Console.Write("█                                                        █");
            Console.SetCursorPosition(45, featuredNumber); featuredNumber++;
            Console.Write("█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█"); // ▄ ▀
            featuredNumber = featuredStart + 1;
            Console.SetCursorPosition(77, featuredNumber); featuredNumber++;
            Console.Write("████████████████████████");
            Console.SetCursorPosition(77, featuredNumber); featuredNumber++;
            Console.Write("█        Very          █");
            Console.SetCursorPosition(77, featuredNumber); featuredNumber++;
            Console.Write("█                      █");
            Console.SetCursorPosition(77, featuredNumber); featuredNumber++;
            Console.Write("█        Cool          █");
            Console.SetCursorPosition(77, featuredNumber); featuredNumber++;
            Console.Write("█                      █");
            Console.SetCursorPosition(77, featuredNumber); featuredNumber++;
            Console.Write("█        Image         █");
            Console.SetCursorPosition(77, featuredNumber); featuredNumber++;
            Console.Write("████████████████████████");
        }
    }
}
