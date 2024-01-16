using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop2_TeamG.Models;

namespace Webshop2_TeamG.Helpers
{
    internal class Shop
    {
        public static void AddToBasket(ShopDbContext database, Customer customer, Game game, int quantity)
        {

            if (game.Stock < quantity)
            {
                Console.WriteLine($"Not enough stock available for {game.Title}.");
                return;
            }

            var basketEntry = new BasketEntry
            {
                Game = game,
                Quantity = quantity
            };

            var basket = database.Baskets
                .Include(b => b.BasketEntries)
                .FirstOrDefault(b => b.CustomerId == customer.Id);

            if (basket == null)
            {
                basket = new Basket
                {
                    Customer = customer,
                    BasketEntries = new List<BasketEntry> { basketEntry }
                };
                database.Baskets.Add(basket);
            }
            else
            {
                var existingEntry = basket.BasketEntries.FirstOrDefault(entry => entry.GameId == game.Id);
                if (existingEntry != null)
                {
                    existingEntry.Quantity += quantity;
                }
                else
                {
                    basket.BasketEntries.Add(basketEntry);
                }
            }

            game.Stock -= quantity;
            game.SoldTotal += quantity;

            database.SaveChanges();

            Console.WriteLine($"Successfully added {quantity} x {game.Title} to the basket.");
        }
        public static void DisplayBasket(ShopDbContext database, Customer customer)
        {
            var basket = database.Baskets
                .Include(b => b.BasketEntries)
                .ThenInclude(entry => entry.Game)
                .FirstOrDefault(b => b.CustomerId == customer.Id);

            if (basket != null)
            {
                Console.WriteLine($"Basket for {customer.Name} :");
                foreach (var entry in basket.BasketEntries)
                {
                    Console.WriteLine($"{entry.Quantity} x {entry.Game.Title} - SEK{entry.Game.Price} each");
                }
                Console.WriteLine($"Total: SEK{basket.BasketEntries.Sum(entry => entry.Quantity * entry.Game.Price)}");
            }
            else
            {
                Console.WriteLine("Basket is empty.");
            }
        }
        public static void CheckoutFromBasket(ShopDbContext database, Customer customer, string paymentMethod)
        {
            var basket = database.Baskets
                         .Include(b => b.BasketEntries)
                         .ThenInclude(entry => entry.Game)
                         .FirstOrDefault(b => b.CustomerId == customer.Id);

            if (basket != null && basket.BasketEntries.Any())
            {
                Console.WriteLine($"Items in basket for {customer.Name}");
                var totalAmount = basket.BasketEntries.Sum(entry => entry.Quantity * entry.Game.Price);
                Console.WriteLine($"Total cost: SEK{totalAmount}");
                Console.WriteLine("1.Creditcard");
                Console.WriteLine("2.Klarna");

                ConsoleKeyInfo paymentKey = Console.ReadKey();
                string chosenPayment;
                switch (paymentKey.Key)
                {
                    case ConsoleKey.D1:
                        chosenPayment = "creditcard";

                        break;
                    case ConsoleKey.D2:
                        chosenPayment = "klarna";
                        break;
                    default:
                        Console.WriteLine("Error, exiting");
                        return;
                }
                PurchaseGames(database, customer, chosenPayment);
            }
            else
            { Console.WriteLine("Basket is empty"); }
        }
        public static void PurchaseGames(ShopDbContext database, Customer customer, string paymentMethod)
        {
            var basket = database.Baskets
                .Include(b => b.BasketEntries)
                .ThenInclude(entry => entry.Game)
                .FirstOrDefault(b => b.CustomerId == customer.Id);

            if (basket != null && basket.BasketEntries.Any())
            {

                Console.WriteLine($"Purchasing games for {customer.Name}...");
                var totalAmount = basket.BasketEntries.Sum(entry => entry.Quantity * entry.Game.Price);
                Console.WriteLine($"Total cost: SEK{totalAmount}");
                switch (paymentMethod.ToLower())
                {
                    case "creditcard":
                        Console.WriteLine("Creditcard payment complete");
                        break;
                    case "klarna":
                        Console.WriteLine("Klarna payment complete");
                        break;
                    default:
                        Console.WriteLine("Could not complete payment");
                        break;
                }
                foreach (var entry in basket.BasketEntries)
                {
                    if (entry.Game.Stock >= entry.Quantity)
                    {
                        entry.Game.SoldTotal += entry.Quantity;
                        entry.Game.Stock -= entry.Quantity;


                        database.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine($"Not enough stock available for {entry.Game.Title}. Skipping purchase.");
                    }
                }
                basket.BasketEntries.Clear();
                database.SaveChanges();
                Console.WriteLine("Purchase completed successfully.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Basket is empty. Nothing to purchase.");
            }
        }
    }
}
