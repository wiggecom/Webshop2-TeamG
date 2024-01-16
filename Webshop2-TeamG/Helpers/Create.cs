using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Webshop2_TeamG.Models;

namespace Webshop2_TeamG.Helpers
{
    public class Create
    {
        public static void FillDatabase(ShopDbContext database)
        {
            if (database.Games.Any() || database.Genres.Any())
            {
                Position.MoveCursorMainStart();
                Console.Write("                                ");
                Position.MoveCursorMainStart();
                Console.WriteLine("Database already filled.");
                return;
            }


            var genres = new List<Genre>
        {
            new Genre { Name = "Action" },
            new Genre { Name = "Adventure" },
            new Genre { Name = "Strategy" },
            new Genre { Name = "Sport" }
        };

            database.Genres.AddRange(genres);
            database.SaveChanges();

            var actionGames = new List<Game>
        {
            new Game
            {
                Title = "Call of Duty: Modern Warfare",
                Price = 599.99m,
                GenreId = genres[0].Id,
                Stock = 100,
                AgeRating = AgeRating.Mature,
                ShortInfo = "Intense first-person shooter with realistic graphics and thrilling multiplayer.",
                LongInfo = "Call of Duty: Modern Warfare is a first-person shooter game that delivers a gripping and realistic experience. With stunning graphics, a compelling single-player campaign, and intense multiplayer action, it's a must-play for FPS enthusiasts."
            },
            new Game
            {
                Title = "Assassin's Creed Valhalla",
                Price = 499.99m,
                GenreId = genres[0].Id,
                Stock = 80,
                AgeRating = AgeRating.Mature,
                ShortInfo = "Explore the Viking era in this open-world action-adventure game.",
                LongInfo = "Assassin's Creed Valhalla takes you on a journey to the Viking era, where you lead a clan in epic battles and explore a vast open world. With stunning visuals and engaging gameplay, it's a captivating experience for adventure lovers."
            },
            new Game
            {
                Title = "DOOM Eternal",
                Price = 549.99m,
                GenreId = genres[0].Id,
                Stock = 120,
                AgeRating = AgeRating.Mature,
                ShortInfo = "Fast-paced, demon-slaying action with stunning visuals and intense gameplay.",
                LongInfo = "DOOM Eternal continues the legacy of the iconic series with fast-paced, brutal action. Battle hordes of demons across various dimensions, unravel the lore, and experience heart-pounding moments in this adrenaline-fueled first-person shooter."
            }
        };

            var adventureGames = new List<Game>
        {
            new Game
            {
                Title = "The Legend of Zelda: Breath of the Wild",
                Price = 599.99m,
                GenreId = genres[1].Id,
                Stock = 90,
                AgeRating = AgeRating.Everyone,
                ShortInfo = "Epic action-adventure game set in a vast, open world with creative puzzles and exploration.",
                LongInfo = "Embark on a grand adventure in The Legend of Zelda: Breath of the Wild. Explore the vast kingdom of Hyrule, solve intricate puzzles, battle formidable enemies, and uncover the secrets of this beautifully crafted open-world game."
            },
            new Game
            {
                Title = "Uncharted 4: A Thief's End",
                Price = 399.99m,
                GenreId = genres[1].Id,
                Stock = 75,
                AgeRating = AgeRating.Teen,
                ShortInfo = "Action-packed cinematic experience following Nathan Drake's final adventure.",
                LongInfo = "Join Nathan Drake in his final adventure in Uncharted 4: A Thief's End. Experience breathtaking visuals, cinematic storytelling, and thrilling action as Drake embarks on a quest to find a lost pirate treasure."
            },
            new Game
            {
                Title = "Red Dead Redemption 2",
                Price = 499.99m,
                GenreId = genres[1].Id,
                Stock = 110,
                AgeRating = AgeRating.Mature,
                ShortInfo = "Wild West open-world game with an immersive story and realistic details.",
                LongInfo = "Immerse yourself in the vast open world of the Wild West in Red Dead Redemption 2. Ride through stunning landscapes, engage in intense gunfights, and experience a gripping narrative that explores the era of outlaws and lawmen."
            }
        };

            var strategyGames = new List<Game>
        {
            new Game
            {
                Title = "Civilization VI",
                Price = 399.99m,
                GenreId = genres[2].Id,
                Stock = 85,
                AgeRating = AgeRating.Everyone,
                ShortInfo = "Turn-based strategy game where you lead a civilization from ancient times to the modern era.",
                LongInfo = "Lead your civilization to greatness in Civilization VI. From the dawn of civilization to the modern era, engage in diplomacy, build wonders, and wage wars to establish your empire's legacy."
            },
            new Game
            {
                Title = "Stellaris",
                Price = 299.99m,
                GenreId = genres[2].Id,
                Stock = 65,
                AgeRating = AgeRating.Teen,
                ShortInfo = "Grand strategy game set in space with exploration, diplomacy, and epic space battles.",
                LongInfo = "Explore the vastness of space in Stellaris, a grand strategy game that combines exploration, diplomacy, and epic space battles. Customize your species, build your empire, and encounter other civilizations in a procedurally generated universe."
            },
            new Game
            {
                Title = "Total War: Three Kingdoms",
                Price = 499.99m,
                GenreId = genres[2].Id,
                Stock = 95,
                AgeRating = AgeRating.Mature,
                ShortInfo = "Historical strategy game set in ancient China with real-time battles and diplomacy.",
                LongInfo = "Experience the drama of ancient China in Total War: Three Kingdoms. Command armies, engage in real-time battles, and navigate a complex web of diplomacy and intrigue in this historical strategy masterpiece."
            }
        };

            var sportGames = new List<Game>
        {
            new Game
            {
                Title = "FIFA 22",
                Price = 599.99m,
                GenreId = genres[3].Id,
                Stock = 120,
                AgeRating = AgeRating.Everyone,
                ShortInfo = "The latest installment in the popular football simulation series with realistic gameplay and updated teams.",
                LongInfo = "Experience the excitement of football in FIFA 22. With realistic gameplay, updated teams, and stunning visuals, FIFA 22 delivers the most authentic football simulation experience to date."
            },
            new Game
            {
                Title = "NBA 2K22",
                Price = 499.99m,
                GenreId = genres[3].Id,
                Stock = 100,
                AgeRating = AgeRating.Everyone,
                ShortInfo = "Basketball simulation game featuring stunning graphics, immersive career mode, and competitive online play.",
                LongInfo = "Dunk, shoot, and dominate the court in NBA 2K22. With stunning graphics, an immersive career mode, and competitive online play, NBA 2K22 offers the ultimate basketball simulation experience."
            },
            new Game
            {
                Title = "Forza Horizon 3",
                Price = 299.99m,
                GenreId = genres[3].Id,
                Stock = 80,
                AgeRating = AgeRating.Everyone,
                ShortInfo = "Open-world racing game featuring a variety of cars, stunning landscapes, and dynamic weather.",
                LongInfo = "Experience the thrill of open-world racing in Forza Horizon 3. Drive a diverse range of cars, explore stunning landscapes, and participate in dynamic races with changing weather conditions."
            }
        };
            database.Games.AddRange(actionGames);
            database.Games.AddRange(adventureGames);
            database.Games.AddRange(strategyGames);
            database.Games.AddRange(sportGames);

            database.SaveChanges();

            Position.MoveCursorMainStart();
            Console.Write("                                ");
            Position.MoveCursorMainStart();
            Console.WriteLine("Database filled successfully.");

        }
        public static void SampleCustomers(ShopDbContext database)
        {

            if (database.Customers.Any())
            {
                Position.MoveCursorMainStart();
                Console.Write("                                ");
                Position.MoveCursorMainStart();
                Console.WriteLine("Database already filled.");
                return;
            }

            var customer = new List<Customer>
        {
            new Customer
            {
                Name = "Smith",
                Email = "Smith@matrix.neo",
                Password  = "abc123",
                Age =30,
                Phone ="123-456789",
                Street ="Rosvalla 76",
                PostalCode="51130",
                City ="Nykoping",
                Country="Sweden",
                Admin = false,
                Payment= PaymentMethod.CreditCard,
                Baskets = new List<Basket>

                {
                    new Basket
                    {
                        BasketEntries = new List<BasketEntry>
                        {
                            //new BasketEntry { GameId = actionGames.First().Id, Quantity = 2 },
                        }
                    }
                }
            },
            //            new Customer
            //{
            //    Name = "Admin",
            //    Email = "admin@hog.se",
            //    Password  = "admin",
            //    Age =36,
            //    Phone ="555-236865",
            //    Street ="Admingatan 7",
            //    PostalCode="61192",
            //    City ="Nykoping",
            //    Country="Sweden",
            //    Admin = true,
            //    Payment= PaymentMethod.Klarna,
            //    Baskets = new List<Basket>

            //    {
            //        new Basket
            //        {
            //            BasketEntries = new List<BasketEntry>
            //            {
            //                //new BasketEntry { GameId = actionGames.First().Id, Quantity = 1 },
            //            }
            //        }
            //    }
            //}
        };
            database.Customers.AddRange(customer);
            database.SaveChanges();
            Position.MoveCursorMainStart();
            Console.Write("                                ");
            Position.MoveCursorMainStart();
            Console.WriteLine("Database filled successfully.");

        }
        public static void CustomerTools(int menuX, int menuY, int infoX, int infoY)
        {
            //Helpers.Gfx.ClearMenu(menuX, menuY);
            int i = 0;
            Console.BackgroundColor = ConsoleColor.DarkBlue; Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(menuX, menuY + i); i++;
            Console.Write("Do you want to:");
            Console.SetCursorPosition(menuX, menuY + i); i++;
            Console.Write("1. Return");
            Console.SetCursorPosition(menuX, menuY + i); i++;
            Console.Write("2. Create Account");
            Console.SetCursorPosition(menuX, menuY + i); i++;
            Console.Write("3. Go to Account");
            Console.SetCursorPosition(menuX, menuY + i); i++;

            var userInputKey = Console.ReadKey(true);
            if (userInputKey.Key == ConsoleKey.D1)
            {
                return;
            }
            if (userInputKey.Key == ConsoleKey.D2)
            {
                AddPerson(menuX, menuY);
                //Helpers.Persons.ListPersons(infoX, infoY);
            }
            if (userInputKey.Key == ConsoleKey.D3)
            {
                Console.WriteLine("Placeholder: Go to account info");
                //RemovePerson(menuX, menuY);
                //Helpers.Persons.ListPersons(infoX, infoY);
            }

        }

        private static void AddPerson(int menuX, int menuY)
        {
            //    //Helpers.Gfx.ClearMenu(menuX, menuY);
            //    Console.SetCursorPosition(menuX, menuY);
            //    Console.Write("Current Members:");
            //    int i = 1;
            //    Console.BackgroundColor = ConsoleColor.DarkBlue; Console.ForegroundColor = ConsoleColor.Cyan;
            //    using (var database = new ShopDbContext())
            //    {
            //        foreach (var person in database.Persons)
            //        {
            //            Console.SetCursorPosition(menuX, menuY + i);
            //            Console.Write(person.Name);
            //            i++;
            //        }
            //        int afterList = database.Persons.Count();
            //        Console.SetCursorPosition(menuX, menuY + 2 + afterList);
            //        Console.Write("Enter the Name to Add: ");
            //        string newName = Console.ReadLine();
            //        var newPerson = new Person
            //        {
            //            Name = newName,
            //            TotalValue = 0
            //        };
            //        database.Persons.Add(newPerson);
            //        database.SaveChanges();
            //    }

        }
    }
}
