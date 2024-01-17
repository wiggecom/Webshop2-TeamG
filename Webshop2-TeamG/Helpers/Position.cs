using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop2_TeamG.Helpers
{
    internal class Position
    {
        public static void MoveCursorMainStart(int nextRow)
        {
            Console.SetCursorPosition(45, 12+nextRow);
        }
    }
}
