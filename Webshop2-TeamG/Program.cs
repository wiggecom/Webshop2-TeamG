using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using Webshop2_TeamG.Helpers;

namespace Webshop2_TeamG
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int menuLevel = 1;
            Gfx.WinIni();

            Position.MoveCursorMainStart(0);
            Console.WriteLine("Database?");
            Admin.MakeFirstAdmin();

            while (true)
            {
                SysMenu.TopMenu(Position.topX, Position.topY);
                SysMenu.ClearFullSidemenu(Position.sideX, Position.sideY + 4);
                menuLevel = SysMenu.SideMenu(Position.sideX, Position.sideY, menuLevel);
            }
        }
    }
}