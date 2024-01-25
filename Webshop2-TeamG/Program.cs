using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using Webshop2_TeamG.Helpers;
using Webshop2_TeamG.Models;

namespace Webshop2_TeamG
{
    internal class Program
    {
        public static int menuLevel = 1;
        public static void Main(string[] args)
        {
            //int menuLevel = 1;
            Gfx.WinIni();

            Position.MoveCursorMainStart(0);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("."); // If dot stays database doesn't exist
            Gfx.ColorIni();
            Admin.MakeFirstAdmin();
            while (true)
            {
                SysMenu.TopMenu(Position.topX, Position.topY);
                SysMenu.ClearFullSidemenu(Position.sideX, Position.sideY + 4);
                SysMenu.SideMenu(menuLevel);
                menuLevel = SysMenu.KeyInput(0,0, menuLevel);
            }
        }
    }
}