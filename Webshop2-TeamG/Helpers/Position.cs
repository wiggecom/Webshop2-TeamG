using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2_TeamG.Helpers
{
    internal class Position
    {
        //public static int menuLevel = 1;
        public static int topX = 85;
        public static int topY = 3;
        public static int sideX = 7;
        public static int sideY = 9;
        public static void MoveCursorMainStart(int nextRow)
        {
            Console.SetCursorPosition(45, 12+nextRow);
        }
        public static void MoveCursorTextAnywhere(int columnStart, int nextRow)
        {
            Console.SetCursorPosition(columnStart, 12 + nextRow);
        }
    }
}
