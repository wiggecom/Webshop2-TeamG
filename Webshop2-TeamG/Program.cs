using Microsoft.EntityFrameworkCore;
using System;

namespace Webshop2_TeamG
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Customer!");
            Helpers.Gfx.Frontend();
            Helpers.Admin.AdminTools(5, 13);
        }
    }
}