using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using Webshop2_TeamG.Models;
using Microsoft.EntityFrameworkCore;

namespace Webshop2_TeamG.Helpers
{
    internal class BasketView
    {
        public static void BasketViewDefault()
        {
            using (var database = new ShopDbContext())
            {
                if (database.Games.Any() && database.Customers.Any())
                {
                    Customer thisCustomer = database.Customers.Where(x => x.Id == 1).FirstOrDefault();
                    //SysMenu.ClearAllAreas();
                    ItemsInBasket(database, thisCustomer);
                    //Console.ReadKey();
                    //SysMenu.ClearAllAreas();
                }
            }
        }
        public static async Task PurchaseGamesAsync(ShopDbContext database, Customer customer)
        {
            var basket = await database.Baskets
            .Where(b => b.CustomerId == customer.Id)
            .FirstOrDefaultAsync();

            if (basket != null)
            {

                var basketEntries = await database.BasketEntries
                    .Include(entry => entry.Game)
                    .Where(entry => entry.BasketId == basket.Id)
                    .ToListAsync();

                if (basketEntries.Any())
                {
                    Console.WriteLine($"Purchasing games for {customer.Name}...");

                    decimal totalAmount = basket.BasketEntries.Sum(entry => entry.Quantity * entry.Game.Price);

                    Console.WriteLine($"Total amount: ${totalAmount}");


                    PaymentMethod chosenPaymentMethod = ChoosePaymentMethod();


                    await HandlePaymentAsync(chosenPaymentMethod);


                    using (var connection = new SqlConnection(" "))
                    {
                        connection.Open();

                        foreach (var entry in basket.BasketEntries)
                        {
                            if (entry.Game.Stock >= entry.Quantity)
                            {
                                entry.Game.SoldTotal += entry.Quantity;
                                entry.Game.Stock -= entry.Quantity;


                                await connection.ExecuteAsync(
                                    "DELETE FROM BasketEntries WHERE Id = @Id",
                                    new { Id = entry.Id }
                                );
                            }
                            else
                            {
                                Console.WriteLine($"Not enough stock available for {entry.Game.Title}. Skipping purchase.");
                            }
                        }
                        await connection.ExecuteAsync(
                            "UPDATE Games SET SoldTotal = SoldTotal + @Quantity, Stock = Stock - @Quantity WHERE Id = @GameId",
                            basket.BasketEntries.Select(entry => new
                            {
                                Quantity = entry.Quantity,
                                GameId = entry.GameId
                            })
                        );
                    }

                    Console.WriteLine("Purchase completed successfully.");
                }
            }
            else
            {
                Console.WriteLine("Basket is empty. Nothing to purchase.");
            }
        }
        public static PaymentMethod ChoosePaymentMethod()
        {
            Console.WriteLine("Choose a payment method:");
            Console.WriteLine("1. Credit Card");
            Console.WriteLine("2. Klarna");

            while (true)
            {
                ConsoleKeyInfo paymentKey = Console.ReadKey();

                switch (paymentKey.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("\nPayment method: Credit Card");
                        return PaymentMethod.CreditCard;
                    case ConsoleKey.D2:
                        Console.WriteLine("\nPayment method: Klarna");
                        return PaymentMethod.Klarna;
                    default:
                        Console.WriteLine("\nInvalid choice. Please enter 1 for Credit Card or 2 for Klarna.");
                        break;
                }
            }
        }
        public static async Task HandlePaymentAsync(PaymentMethod chosenPaymentMethod)
        {

            Console.WriteLine("Processing payment...");
            await Task.Delay(2000);

            switch (chosenPaymentMethod)
            {
                case PaymentMethod.CreditCard:
                    Console.WriteLine("Credit card payment completed.");
                    break;
                case PaymentMethod.Klarna:
                    Console.WriteLine("Klarna payment completed.");
                    break;
                default:
                    Console.WriteLine("Invalid payment method.");
                    break;
            }
        }
        public static decimal CalculateTotalAmount(ShopDbContext database, Customer customer)  // current
        {
            var basket = database.Baskets
                .Include(e => e.BasketEntries)
                .ThenInclude(entry => entry.Game)
                .OrderBy(b => b.Id)
                .Last(b => b.CustomerId == customer.Id);

            if (basket != null)
            {
                decimal totalAmount = basket.BasketEntries
                    .Sum(entry => entry.Quantity * (entry.Game?.Price ?? 0));

                return totalAmount;
            }
            return 0;
        }
        //public static decimal BasketTotalAmount(ShopDbContext database, Customer customer)
        //{
        //    decimal totalAmount;
        //    var basket = database.Baskets
        //        .Include(e => e.BasketEntries)
        //        .ThenInclude(entry => entry.Game)
        //        .OrderBy(b => b.Id)
        //        .Last(b => b.CustomerId == customer.Id);

        //    if (basket != null)
        //    {
        //        totalAmount = basket.BasketEntries
        //            .Sum(entry => entry.Quantity * entry.Game.Price); // Handle null Game.Price
        //        return totalAmount;
        //        //Console.WriteLine($"Basket: ${totalAmount}SEK");
        //    }
        //    else
        //    {
        //        return 0;
        //        //Console.WriteLine("Basket is empty");
        //    }
        //}
        public static void AddGameToBasket(ShopDbContext database, Customer customer, Game game, int quantity)
        {
            var basket = database.Baskets
                .Include(e => e.BasketEntries)
                .ThenInclude(entry => entry.Game)
                .OrderBy(b => b.Id)
                .Last(b => b.CustomerId == customer.Id);

            if (basket == null)
            {
                basket = new Basket
                {
                    CustomerId = customer.Id
                };

                database.Baskets.Add(basket);
            }

            basket.BasketEntries ??= new List<BasketEntry>();

            var existingEntry = basket.BasketEntries.FirstOrDefault(entry => entry.GameId == game.Id);

            if (existingEntry != null)
            {
                existingEntry.Quantity += quantity;
            }
            else
            {
                var newEntry = new BasketEntry
                {
                    GameId = game.Id,
                    Quantity = quantity
                };

                basket.BasketEntries.Add(newEntry);
            }

            database.SaveChanges();
        }
        public static void ItemsInBasket(ShopDbContext database, Customer customer)
        {
            //int currentBasket = database.Baskets.Count();
            var basket = database.Baskets
                .Include(e => e.BasketEntries)
                .ThenInclude(entry => entry.Game)
                .OrderBy(b => b.Id)
                .Last(b => b.CustomerId == customer.Id);


            if (basket != null)
            {
                int rightColumnStart = Position.mainX;
                int currentRow = Position.mainY;
                Console.SetCursorPosition(rightColumnStart, currentRow); currentRow++;
                Console.Write("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                Console.SetCursorPosition(rightColumnStart, currentRow); currentRow++;
                Console.Write("█▀▀▀▀▀█▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█▀▀▀▀▀▀▀█▀▀▀▀▀▀▀▀▀█");
                Console.SetCursorPosition(rightColumnStart, currentRow); currentRow++;
                Console.Write("█  #  █  Title                                                 █  Qty  █  Price  █");
                Console.SetCursorPosition(rightColumnStart, currentRow); currentRow++;
                Console.Write("█▄▄▄▄▄█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█▄▄▄▄▄▄▄█▄▄▄▄▄▄▄▄▄█");
                Console.SetCursorPosition(rightColumnStart, currentRow); currentRow++;
                Console.Write("█▀▀▀▀▀█▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█▀▀▀▀▀▀▀█▀▀▀▀▀▀▀▀▀█");


                //Console.SetCursorPosition(rightColumnStart, currentRow); currentRow++;
                //Console.WriteLine($"Items in the basket for {customer.Name} :");
                int i = 1;
                foreach (var entry in basket.BasketEntries)
                {
                    string strPrice = Math.Round((entry.Game.Price), 2).ToString();
                    //Console.SetCursorPosition(rightColumnStart, currentRow);
                    //Console.WriteLine($"- {entry.Game.Title} (Quantity: {entry.Quantity}, Price: ${entry.Game.Price * entry.Quantity})SEK");
                    Console.SetCursorPosition(rightColumnStart, currentRow);
                    Console.Write("█     █                                                        █       █         █");
                    Console.SetCursorPosition(rightColumnStart + 3, currentRow);
                    Console.Write(i);
                    Console.SetCursorPosition(rightColumnStart + 9, currentRow);
                    Console.Write(entry.Game.Title);
                    Console.SetCursorPosition(rightColumnStart + 66, currentRow);
                    Console.Write(entry.Quantity);
                    Console.SetCursorPosition(rightColumnStart + 74 + (6 - strPrice.Length), currentRow);
                    Console.Write(strPrice);
                    currentRow++; i++;
                }

                decimal shipping = 59.90m;
                decimal totalAmount = basket.BasketEntries.Sum(entry => entry.Quantity * entry.Game.Price);
                decimal vatAmount = totalAmount * 0.2m;
                Console.SetCursorPosition(rightColumnStart, currentRow); currentRow++;
                Console.Write("█▄▄▄▄▄█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█▄▄▄▄▄▄▄█▄▄▄▄▄▄▄▄▄█");
                Console.SetCursorPosition(rightColumnStart, currentRow); currentRow++;
                Console.Write("█▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█▀▀▀▀▀▀▀▀▀█");
                Console.SetCursorPosition(rightColumnStart, currentRow); currentRow++;
                Console.Write("█                                                                 Sum  █         █");
                Console.SetCursorPosition(rightColumnStart, currentRow); currentRow++;
                Console.Write("█                                                          Sum ex.VAT  █         █");
                Console.SetCursorPosition(rightColumnStart, currentRow); currentRow++;
                Console.Write("█                                                                 VAT  █         █");
                Console.SetCursorPosition(rightColumnStart, currentRow); currentRow++;
                Console.Write("█                                                            Shipping  █         █");
                Console.SetCursorPosition(rightColumnStart, currentRow); currentRow++;
                Console.Write("█                                                               Total  █         █");
                Console.SetCursorPosition(rightColumnStart, currentRow); currentRow++;
                Console.Write("█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█▄▄▄▄▄▄▄▄▄█");
                Console.SetCursorPosition(rightColumnStart, currentRow); currentRow++;
                Console.Write("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");

                string strTotal = Math.Round(totalAmount, 2).ToString();
                string strTotalExVat = Math.Round((totalAmount - vatAmount), 2).ToString();
                string strVat = Math.Round(vatAmount, 2).ToString();
                string strShipping = Math.Round(shipping, 2).ToString();
                string strTotalShipping = Math.Round((totalAmount + shipping), 2).ToString();
                currentRow = currentRow - 7;
                Console.SetCursorPosition(rightColumnStart + 3, currentRow);
                Console.Write(customer.Name);
                Console.SetCursorPosition(rightColumnStart + 73 + (7 - strTotal.Length), currentRow);
                Console.Write(strTotal);
                currentRow++;
                Console.SetCursorPosition(rightColumnStart + 3, currentRow);
                Console.Write(customer.Street);
                Console.SetCursorPosition(rightColumnStart + 73 + (7 - strTotalExVat.Length), currentRow);
                Console.Write(strTotalExVat);
                currentRow++;
                Console.SetCursorPosition(rightColumnStart + 3, currentRow);
                Console.Write(customer.PostalCode);
                Console.SetCursorPosition(rightColumnStart + 4 + (customer.PostalCode.Length), currentRow);
                Console.Write(customer.City.ToUpper());
                Console.SetCursorPosition(rightColumnStart + 73 + (7 - strVat.Length), currentRow);
                Console.Write(strVat);
                currentRow++;
                Console.SetCursorPosition(rightColumnStart + 73 + (7 - strShipping.Length), currentRow);
                Console.Write(strShipping);
                currentRow++;
                Console.SetCursorPosition(rightColumnStart + 73 + (7 - strTotalShipping.Length), currentRow);
                Console.Write(strTotalShipping);
                currentRow++;
            }
            else
            {
                Console.WriteLine("Basket is empty.");
                //                Console.Write(" 123456789 123456789 123456789 123456789 123456789 123456789 123456789 123456789 1");
            }
        }
        public static void PurchaseItems(ShopDbContext database, Customer customer)
        {

            var basket = database.Baskets
                .Include(e => e.BasketEntries)
                .ThenInclude(entry => entry.Game)
                .OrderBy(b => b.Id)
                .Last(b => b.CustomerId == customer.Id);

            if (basket != null && basket.BasketEntries.Any())
            {
                //Console.Clear();

                ItemsInBasket(database, customer);


                int posX = Position.mainX;
                int posY = Console.CursorTop + 3;
                Console.SetCursorPosition(posX, posY); posY++;
                Console.WriteLine("Choose a payment method:");
                Console.SetCursorPosition(posX, posY); posY++;
                Console.WriteLine("1. Klarna");
                Console.SetCursorPosition(posX, posY); posY++;
                Console.WriteLine("2. Credit Card");
                Console.SetCursorPosition(posX, posY); posY++;
                ConsoleKeyInfo userInputKey;
                do
                {
                    userInputKey = Console.ReadKey();
                } while (userInputKey.Key != ConsoleKey.D1 && userInputKey.Key != ConsoleKey.D2);

                PaymentMethod selectedPaymentMethod = userInputKey.Key == ConsoleKey.D1 ? PaymentMethod.Klarna : PaymentMethod.CreditCard;

                // copy basket items to history ---------------------------------------------------------------------------------------------------------------

                ClearBasket(database, basket);
                Console.SetCursorPosition(posX, posY); posY++;
                Console.Write("Purchase completed. Thank you!");
                Console.SetCursorPosition(posX, posY); posY++;
                Console.Write("Press [ANY] key to continue");
                Console.ReadKey();
            }
            else
            {
                int posX = Position.mainX;
                int posY = Position.mainY;
                Console.SetCursorPosition(posX, posY); posY++;
                Console.Write("Basket is empty. Nothing to purchase.");
                Console.SetCursorPosition(posX, posY); posY++;
                Console.Write("Press [ANY] key to continue");
                Console.ReadKey();
            }
        }
        public static void PurchaseHistory(ShopDbContext database, Customer customer)
        {
            SysMenu.ClearMainArea();
            int posX = Position.mainX;
            int posY = Position.mainY;

            var allBaskets = database.Baskets
           .Include(b => b.BasketEntries)
           .ThenInclude(entry => entry.Game)
           .Where(b => b.CustomerId == customer.Id)
           .OrderByDescending(b => b.DateOfPurchase)
           .ToList();

            // ------------------------------------------------------------------
            //var allBaskets = database.Baskets.ToList();
            var entries = database.BasketEntries.ToList();
            foreach (var basket in allBaskets)
            {
                if (basket.CustomerId == customer.Id && basket.DateOfPurchase > DateTime.MinValue)
                {
                    Console.SetCursorPosition(posX, posY); posY++;
                    Console.Write("▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀");
                    Console.SetCursorPosition(posX, posY); posY++;
                    Console.Write("Date of Purchase - " + basket.DateOfPurchase);
                    Console.SetCursorPosition(posX, posY); posY++;
                    Console.Write("## -Qty- Title                                         Price"); // 60 (Title 43)
                    Console.SetCursorPosition(posX, posY); posY++;
                    Console.Write("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
                    foreach (var entry in entries)
                    {
                        if (entry.BasketId == basket.Id)
                        {
                            string priceString = (entry.Game.Price * entry.Quantity).ToString();
                            string titleString = entry.Game.Title.ToString();
                            if (titleString.Length > 43)
                            {
                                titleString.Remove(40);
                                titleString += "...";
                            }
                            Console.SetCursorPosition(posX, posY);
                            Console.Write(entry.Id);
                            Console.SetCursorPosition(posX + 3, posY);
                            Console.Write("-");
                            Console.SetCursorPosition(posX + 5, posY);
                            Console.Write(entry.Quantity);
                            Console.SetCursorPosition(posX + 7, posY);
                            Console.Write("-");
                            Console.SetCursorPosition(posX + 9, posY);
                            Console.Write(entry.Game.Title);
                            Console.SetCursorPosition(posX + (60 - priceString.Length), posY);
                            Console.Write(priceString);
                            posY++;

                            if (posY >= 40)
                            {
                                Console.SetCursorPosition(posX, posY);
                                Console.Write("Press [ANY] key to continue");
                                Console.ReadKey();
                                posY = Position.mainY;
                                SysMenu.ClearMainArea();
                            }
                        }
                    }
                    decimal totalAmount = basket.BasketEntries.Sum(entry => entry.Quantity * entry.Game.Price);
                    string stringTotal = totalAmount.ToString();
                    Console.SetCursorPosition(posX, posY);
                    Console.Write("TOTAL");
                    Console.SetCursorPosition(posX + (60 - stringTotal.Length), posY); posY++;
                    Console.Write(stringTotal);
                    Console.SetCursorPosition(posX, posY);
                    Console.Write("▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄");
                    posY++;

                    Console.SetCursorPosition(posX, posY); posY++;
                    if (posY >= 30)
                    {
                        Console.SetCursorPosition(posX, posY);
                        Console.Write("Press [ANY] key to continue");
                        Console.ReadKey();
                        posY = Position.mainY;
                        SysMenu.ClearMainArea();

                    }
                }
            }
            // ------------------------------------------------------------------



            ////var basket = database.Baskets
            ////    .Include(b => b.BasketEntries)
            ////    .ThenInclude(entry => entry.Game)
            ////    .FirstOrDefault(b => b.CustomerId == customer.Id);
            //foreach (var entry in basket.BasketEntries)
            //{
            //}

            ////int currentBasket = database.Baskets.Count();
            //if (basket != null && basket.BasketEntries.Any())
            //{
            //    //Console.Clear();

            //    ItemsInBasket(database, customer);

            //    // copy basket items to history ---------------------------------------------------------------------------------------------------------------

            //    ClearBasket(database, basket);
            //    Console.SetCursorPosition(posX, posY); posY++;
            //    Console.Write("Purchase completed. Thank you!");
            //    Console.SetCursorPosition(posX, posY); posY++;
            Console.SetCursorPosition(posX, posY); posY++;
            Console.Write("Press [ANY] key to continue");
            Console.ReadKey();
            //}
        }
        public static void RemoveItemFromBasket(ShopDbContext database, Customer customer)
        {
            var basket = database.Baskets
            .Include(e => e.BasketEntries)
            .ThenInclude(entry => entry.Game)
            .OrderBy(b => b.Id)
            .Last(b => b.CustomerId == customer.Id);


            if (basket != null && basket.BasketEntries.Any())
            {

            }
        }

        //    if (basket != null && basket.BasketEntries.Any())
        //    {
        //        Console.WriteLine("Items in the basket:");

        //        // unlisted, not enumerable -------------------------------------------------------------------------------------------------------------------
        //        for (int i = 0; i < basket.BasketEntries.Count; i++)
        //        {
        //            Console.WriteLine($"{i + 1}. {basket.BasketEntries[i].Game.Title} - Quantity: {basket.BasketEntries[i].Quantity}");
        //        }

        //        Console.Write("Enter the number of the item to remove: ");
        //        if (int.TryParse(Console.ReadLine(), out int selectedItemIndex) && selectedItemIndex >= 1 && selectedItemIndex <= basket.BasketEntries.Count)
        //        {
        //            var selectedEntry = basket.BasketEntries[selectedItemIndex - 1];
        //            basket.BasketEntries.Remove(selectedEntry);

        //            database.SaveChanges();

        //            Console.WriteLine("Item removed from the basket.");
        //        }
        //        else
        //        {
        //            Console.WriteLine("Invalid selection.");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Basket is empty. ");

        //    }
        //}
        private static void ClearBasket(ShopDbContext database, Basket basket)
        {

            var customer = basket.Customer;
            basket.DateOfPurchase = DateTime.Now;
            foreach (var item in basket.BasketEntries)
            {
                int soldQty = item.Quantity;
                item.Game.Stock -= soldQty;
                item.Game.SoldTotal += soldQty;
            }
            database.SaveChanges();
            Basket newBasket = new Basket
            {
                CustomerId = customer.Id
            };

            database.Baskets.Add(newBasket);
            database.SaveChanges();
        }
    }
}
