using Microsoft.EntityFrameworkCore;
using System;
using Webshop2_TeamG.Helpers;


namespace Webshop2_TeamG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int menuLevel = 3;
            Gfx.WinIni();
            Gfx.Frontend(0, 0);
            Gfx.ColorIni();
            SysMenu.TopMenu(85, 3);
            while (true)
            {
            menuLevel = SysMenu.SideMenu(7, 9, menuLevel);
            }
            Console.ReadKey();
            //Helpers.Gfx.Frontend();
            //Helpers.Admin.AdminTools(5, 13);
        }
    }
}