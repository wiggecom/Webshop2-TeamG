using Microsoft.EntityFrameworkCore;
using System;
using Webshop2_TeamG.Helpers;


namespace Webshop2_TeamG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int menuLevel = 1;
            int topX = 85;
            int topY = 3;
            int sideX = 7;
            int sideY = 9;
            Gfx.WinIni();

            SysMenu.TopMenu(topX, topY);
            while (true)
            {
                SysMenu.ClearFullSidemenu(sideX, sideY + 4);
                menuLevel = SysMenu.SideMenu(sideX, sideY, menuLevel);
            }
        }
    }
}