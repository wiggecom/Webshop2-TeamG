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
            int tick = 1;
            Gfx.WinIni();


            Admin.MakeFirstAdmin();
            
            while (true)
            {
                SysMenu.TopMenu(topX, topY);
                SysMenu.ClearFullSidemenu(sideX, sideY + 4);
                menuLevel = SysMenu.SideMenu(sideX, sideY, menuLevel);
            }
        }

    }
}