using System;
using System.Collections;
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
            Random rnd = new Random();

            if (database.Games.Any() || database.Genres.Any())
            {
                Position.MoveCursorMainStart(0);
                Console.Write("                                ");
                Position.MoveCursorMainStart(0);
                Console.WriteLine("Database already filled.");
                return;
            }


            var genres = new List<Genre>
        {
            new Genre { Name = "Action" },
            new Genre { Name = "Adventure" },
            new Genre { Name = "Strategy" },
            new Genre { Name = "Racing" },
            new Genre { Name = "Sports" },
            new Genre { Name = "Puzzle" },
            new Genre { Name = "Fight" },
            new Genre { Name = "RPG" }
        };

            database.Genres.AddRange(genres);
            database.SaveChanges();

            // -----------------------------------  Game Blueprint -----------------------------------------

            //new Game
            //{
            //    Title = "",
            //    Price = m,
            //    GenreId = genres[0].Id, // Action
            //    GenreId = genres[1].Id, // Adventure
            //    GenreId = genres[2].Id, // Strategy
            //    GenreId = genres[3].Id, // Racing
            //    GenreId = genres[4].Id, // Sports
            //    GenreId = genres[5].Id, // Puzzle
            //    GenreId = genres[6].Id, // Fight
            //    GenreId = genres[7].Id, // RPG
            //    Stock = ,
            //    AgeRating = AgeRating.Everyone,
            //    AgeRating = AgeRating.Teen,
            //    AgeRating = AgeRating.Mature,

            // NOTE that you have to remove leading spaces on row 2 and onward from descriptions

            //                  123456789 123456789 123456789 123456789 123456 - 46
            //    ShortInfo = @"Classic Fighting with Heihachi, Nina, Paul, 
            //                  King and a whole army of playable characters.
            //                  Now go punch your friends like enemies",
            //                 123456789 123456789 123456789 123456789 123456789 123456789 123456789 123456789 - 79
            //    LongInfo = @"TEKKEN 8 continues the tragic saga of the Mishima bloodline and its world-
            //                 shaking father-and-son grudge matches. After defeating his father, Heihachi, 
            //                 Kazuya continues his conquest for global domination, using the forces of 
            //                 G Corporation to wage war on the world. Jin is forced to face his fate head-on
            //                 as he is reunited with his long-lost mother and seeks to stop his father 
            //                 Kazuya's reign of terror."
            //},

            // -----------------------------------  Game Blueprint End -------------------------------------

            var allGames = new List<Game>
        {
            new Game
            {
                Title = "Call of Duty: Modern Warfare",
                Price = 599.90m,
                GenreId = genres[0].Id,     // Action
                Stock = rnd.Next(10, 100),
                SoldTotal = rnd.Next(10, 100),
                AgeRating = AgeRating.Mature,
                ShortInfo = @"Intense first-person shooter with realistic
graphics and thrilling multiplayer.",
                LongInfo = @"Call of Duty: Modern Warfare is a first-person shooter game that delivers a 
player campaign, and intense multiplayer action, it's a must-play for FPS 
enthusiasts."
            },
                        new Game
            {
                Title = "The Legend of Zelda: Breath of the Wild",
                Price = 599.90m,
                GenreId = genres[1].Id,     // Adventure
                Stock = rnd.Next(10, 100),
                SoldTotal = rnd.Next(10, 100),
                AgeRating = AgeRating.Everyone,
                OnDisplay = 0,
                ShortInfo = @"Epic action-adventure game set in a vast,
open world with creative puzzles and
exploration.",
                LongInfo = "Embark on a grand adventure in The Legend of Zelda: Breath of the Wild. Explore \nthe vast kingdom of Hyrule, solve intricate puzzles, battle formidable enemies, \nand uncover the secrets of this beautifully crafted open-world game."
            },

            new Game
            {
                Title = "DOOM Eternal",
                Price = 549.90m,
                GenreId = genres[0].Id,     // Action
                Stock = rnd.Next(10, 100),
                SoldTotal = rnd.Next(10, 100),
                OnDisplay= 0,
                AgeRating = AgeRating.Mature,
                ShortInfo = @"Fast-paced, demon-slaying action with stunning
visuals and intense gameplay.",
                LongInfo = @"DOOM Eternal continues the legacy of the iconic series with fast-paced, brutal 
action. Battle hordes of demons across various dimensions, unravel the lore, 
and experience heart-pounding moments in this adrenaline-fueled first-person 
shooter."
            },
            new Game
            {
                Title = "Tekken 8",
                Price = 799.90m,
                GenreId = genres[6].Id, // Fight
                Stock = rnd.Next(10, 100),
                SoldTotal = rnd.Next(10, 100),
                AgeRating = AgeRating.Mature,
                ShortInfo = @"Classic Fighting with Heihachi, Nina, Paul, 
King and a whole army of playable characters.
Now go punch your friends like enemies",
                LongInfo = @"TEKKEN 8 continues the tragic saga of the Mishima bloodline and its world-
shaking father-and-son grudge matches. After defeating his father, Heihachi, 
Kazuya continues his conquest for global domination, using the forces of 
G Corporation to wage war on the world. Jin is forced to face his fate head-on
as he is reunited with his long-lost mother and seeks to stop his father 
Kazuya's reign of terror."
            },
            new Game
            {
                Title = "Puzzle Bobble World Tour",
                Price = 399.90m,
                GenreId = genres[5].Id, // Puzzle
                Stock = rnd.Next(10, 100),
                SoldTotal = rnd.Next(10, 100),
                AgeRating = AgeRating.Everyone,

                ShortInfo = @"Bub, Bob and friends are back on a tour around
the World in a bubble-blasting tournament.
Classic puzzle-action for the whole family",
                LongInfo = @"Puzzle Bobble is a long running series of games featurng the stars Bub and Bob
from the classic arcade game Bubble-Bobble. This adventure will take the hectic
puzzles to landmarks around the world. Collect stamps, souvernirs and coins
to unlock even more locations, skins and characters. 
This game is completely free from micro transactions."
            },
            new Game
            {
                Title = "Final Fantasy VII - Remake",
                Price = 499.90m,
                GenreId = genres[7].Id, // RPG
                Stock = rnd.Next(10, 100),
                SoldTotal = rnd.Next(10, 100),
                AgeRating = AgeRating.Teen,
                ShortInfo = @"The long awaited Remake of Final Fantasy VII
in powerful HD-glory. Bring back memories of
Cloud, Tifa and others in thie classic J-RPG",
                LongInfo = @"One of the most anticipated Final Fantasy remakes ever. Carefully recreated in
modern graphics to tell the story once again to a new generation and old fans 
of the series alike. Spectacular scenery and orchestrated music will make this
journey one that you will remember for a very long time"
            },
            new Game
            {
                Title = "Uncharted 4: A Thief's End",
                Price = 399.90m,
                GenreId = genres[1].Id, // Adventure
                Stock = rnd.Next(10, 100),
                SoldTotal = rnd.Next(10, 100),
                AgeRating = AgeRating.Teen,
                ShortInfo = @"Action-packed cinematic experience following
Nathan Drake's final adventure.",
                LongInfo = @"Join Nathan Drake in his final adventure in Uncharted 4: A Thief's End. 
Experience breathtaking visuals, cinematic storytelling, and thrilling action 
as Drake embarks on a quest to find a lost pirate treasure."
            },
                        new Game
            {
                Title = "Stellaris",
                Price = 299.90m,
                GenreId = genres[2].Id, // Strategy
                Stock = rnd.Next(10, 100),
                SoldTotal = rnd.Next(10, 100),
                AgeRating = AgeRating.Teen,
                ShortInfo = @"Grand strategy game set inspace with 
exploration, diplomacy, and epic space
battles.",
                LongInfo = @"Explore the vastness of space in Stellaris, a grand strategy game that combines 
exploration, diplomacy, and epic space battles. Customize your species, build 
your empire, and encounter other civilizations in a procedurally generated 
universe."
            },
            new Game
            {
                Title = "Red Dead Redemption 2",
                Price = 499.90m,
                GenreId = genres[1].Id, // Adventure
                Stock = rnd.Next(10, 100),
                SoldTotal = rnd.Next(10, 100),
                OnDisplay= 0,
                AgeRating = AgeRating.Mature,
                ShortInfo = @"Wild West open-world game with an immersive
story and realistic details.",
                LongInfo = @"Immerse yourself in the open world of the Wild West in Red Dead Redemption 2. 
Ride through stunning landscapes, engage in intense gunfights, and experience a
gripping narrative that explores the era of outlaws and lawmen."
            },

            new Game
            {
                Title = "Civilization VI",
                Price = 399.90m,
                GenreId = genres[2].Id, // Strategy
                Stock = rnd.Next(10, 100),
                SoldTotal = rnd.Next(10, 100),
                AgeRating = AgeRating.Everyone,
                ShortInfo = @"Turn-based strategy game where you lead a 
civilization from ancient times to the
modern era.",
                LongInfo = @"Lead your civilization to greatness in Civilization VI. From the dawn of 
civilization to the modern era, engage in diplomacy, build wonders, and wage 
wars to establish your empire's legacy."
            },
                new Game
            {
                Title = "NBA 2K22",
                Price = 499.90m,
                GenreId = genres[4].Id, // Sports
                Stock = rnd.Next(10, 100),
                SoldTotal = rnd.Next(10, 100),
                AgeRating = AgeRating.Everyone,
                ShortInfo = @"Basketball simulation game featuring
stunning graphics, immersive career
mode, and competitive online play.",
                LongInfo = @"Dunk, shoot, and dominate the court in NBA 2K22. With stunning graphics, an 
immersive career mode, and competitive online play, NBA 2K22 offers the 
ultimate basketball simulation experience."
            },

            new Game
            {
                Title = "Total War: Three Kingdoms",
                Price = 499.90m,
                GenreId = genres[2].Id, // Strategy
                Stock = rnd.Next(10, 100),
                SoldTotal = rnd.Next(10, 100),
                AgeRating = AgeRating.Mature,
                ShortInfo = @"Historical strategy game set in ancient
China with real-time battles and
diplomacy.",
                LongInfo = @"Experience the drama of ancient China in Total War: Three Kingdoms. Command 
armies, engage in real-time battles, and navigate a complex web of diplomacy 
and intrigue in this historical strategy masterpiece."
            },
        //};

        //    var sportGames = new List<Game>
        //{
            new Game
            {
                Title = "FIFA 22",
                Price = 599.90m,
                GenreId = genres[4].Id, // Sports
                Stock = rnd.Next(10, 100),
                SoldTotal = rnd.Next(10, 100),
                AgeRating = AgeRating.Everyone,
                ShortInfo = @"The latest installment in the popular
football simulation series with 
realistic gameplay and updated teams.",
                LongInfo = @"Experience the excitement of football in FIFA 22. With realistic gameplay, 
updated teams, and stunning visuals, FIFA 22 delivers the most authentic 
football simulation experience to date."
            },
            new Game
            {
                Title = "Assassin's Creed Valhalla",
                Price = 499.90m,
                GenreId = genres[0].Id, // Action
                Stock = rnd.Next(10, 100),
                SoldTotal = rnd.Next(10, 100),
                AgeRating = AgeRating.Mature,
                ShortInfo = @"Explore the Viking era in this open-world 
action-adventure game.",
                LongInfo = @"Assassin's Creed Valhalla takes you on a journey to the Viking era, where you 
lead a clan in epic battles and explore a vast open world. With stunning 
visuals and engaging gameplay, it's a captivating experience for adventure 
lovers."
            },
            new Game
            {
                Title = "Forza Horizon 3",
                Price = 999.90m,
                GenreId = genres[3].Id, // Racing
                Stock = rnd.Next(10, 100),
                SoldTotal = rnd.Next(10, 100),
                OnDisplay = 0,
                AgeRating = AgeRating.Everyone,
                ShortInfo = @"Open-world racing game featuring a variety
of cars, stunning landscapes, and dynamic
weather.",
                LongInfo = @"Experience the thrill of open-world racing in Forza Horizon 3. Drive a diverse 
range of cars, explore stunning landscapes, and participate in dynamic races 
with changing weather conditions."
            },
                        new Game
            {
                Title = "Laban on the Run",
                Price = 599.90m,
                GenreId = genres[0].Id,  // Action
                Stock = rnd.Next(10, 100),
                SoldTotal = rnd.Next(10, 100),
                AgeRating = AgeRating.Mature,
                ShortInfo = @"Laban is on the run again, trying to avoid
everything",
                LongInfo = @"The bandit Laban is on the run from the long arm of the law once again. In
his adventures he will need to find clever ways to use the environment and
items he can find in it to finally leave the country for a life in retirement
on Bahamas."
            },
            new Game
            {
                Title = "Greger in LaLa-Land",
                Price = 499.90m,
                GenreId = genres[3].Id, // Racing
                Stock = rnd.Next(10, 100),
                SoldTotal = rnd.Next(10, 100),
                AgeRating = AgeRating.Everyone,
                ShortInfo = @"Greger is racing in LaLa-Land, It's a
Rough Day at Work!",
                LongInfo = @"Greger, the well known racing maniac, is racing against various inhabitants
in LaLa-Land. The little bastards are using all kinds of weapons, traps and unjust
methods to win this race, but Greger is tougher than a nut."
            },

            new Game
            {
                Title = "Ninja Commando XIV",
                Price = 599.90m,
                GenreId = genres[0].Id, // Action
                Stock = rnd.Next(10, 100),
                SoldTotal = rnd.Next(10, 100),
                AgeRating = AgeRating.Mature,
                ShortInfo = @"The fourteenth installment of this 
popular action game series",
                LongInfo = @"Here we go again in this Epic franchise of Ninja games. The fourteenth 
installment of the series involves extra many ninjas, more weapons than ever and we 
guarantee the bloodiest mess ever witnessed on screen! Hii-yaaaah!"
            },

            new Game
            {
                Title = "The Thinker",
                Price = 199.90m,
                GenreId = genres[2].Id, // Strategy
                Stock = rnd.Next(10, 100),
                SoldTotal = rnd.Next(10, 100),
                AgeRating = AgeRating.Teen,
                OnDisplay = 0,
                ShortInfo = @"In this game you have to think,
like really really hard. For real.",
                LongInfo = @"Here is the perfect game for deep thinking. You can think in english,
german and even swahili! You just can't answer in any other language than english,
unfortunately. This game is much harder than you think!"
            },

            new Game
            {
                Title = "Adventures in the house",
                Price = 12.90m,
                GenreId = genres[1].Id, // Adventure
                Stock = rnd.Next(10, 100),
                SoldTotal = rnd.Next(10, 100),
                AgeRating = AgeRating.Everyone,
                ShortInfo = @"Your house could be an adventure, sort of,
we guess >:(",
                LongInfo = @"In this, more or less exciting, adventure you get to move between rooms.
You can go to exotic places like the kitchen, bathroom, livingroom, bedroom and even the
rickety shed that is about to collapse. Head out on the least extensive adventure ever
written NOW!"
            },

            new Game
            {
                Title = "Rally-Åke",
                Price = 79.90m,
                GenreId = genres[3].Id, // Racing
                Stock = rnd.Next(10, 100),
                SoldTotal = rnd.Next(10, 100),
                OnDisplay = 3,
                AgeRating = AgeRating.Everyone,
                ShortInfo = @"Rally-Åke rullar buss",
                LongInfo = @"Rally-Åke på tävling med sin gula buss, vi hoppas bromsarna håller hela
vägen och inte trillar av i Halmstads Kummun."
            },
                        new Game
            {
                Title = "Laban in the Jungle",
                Price = 12.90m,
                GenreId = genres[0].Id, // Action
                Stock = rnd.Next(10, 100),
                SoldTotal = rnd.Next(10, 100),
                OnDisplay = 2,
                AgeRating = AgeRating.Teen,
                ShortInfo = @"Laban is on the warpath in the jungle 
against a vicious tribe of cannibals",
                LongInfo = @"Pick up your rifle and enter a vast labyrinth in the jungle where every 
corner can hide things like dangerous cannibals, predators, quicksand, 
mosquitoes and/or traps! Shoot your way trough everything that moves (or 
doesn't move, we don't really care)."
            },
            new Game
            {
                Title = "Check Mate or Checkmate",
                Price = 799.90m,
                GenreId = genres[2].Id, // Strategy
                Stock = rnd.Next(10, 100),
                SoldTotal = rnd.Next(10, 100),
                OnDisplay = 1,
                AgeRating = AgeRating.Mature,
                ShortInfo = @"The world's first chess/dating
simulator, guaranteed!",
                LongInfo = @"In this unusual strategy title you are testing your competibility with
potential mates by playing games of chess... Beware the extra naughty
scene, kings and queens, we dare not say anything else. NSFW!!!"
            }
        };

            database.Games.AddRange(allGames);

            database.SaveChanges();

            Position.MoveCursorMainStart(0);
            Console.Write("                                ");
            Position.MoveCursorMainStart(0);
            Console.WriteLine("Database filled successfully.");

        }
        public static void SampleCustomers(ShopDbContext database)
        {

            if (database.Customers.Any())
            {
                Position.MoveCursorMainStart(0);
                Console.Write("                                ");
                Position.MoveCursorMainStart(0);
                Console.WriteLine("Database already filled.");
                return;
            }

            var customer = new List<Customer>
        {
            new Customer
            {
                Name = "Jack Daniels",
                Email = "jd@matrix.neo",
                Password  = "abc123",
                Age =30,
                Phone ="123-456789",
                Street ="Rusvalla 76",
                PostalCode="51130",
                City ="Nykoping",
                Country="Sweden",
                Payment= PaymentMethod.CreditCard,
                Baskets = new List<Basket>
                {
                    new Basket
                    {
                        BasketEntries = new List<BasketEntry>
                        {

                        }
                    }
                }
            },
        };
            database.Customers.AddRange(customer);
            database.SaveChanges();
            Position.MoveCursorMainStart(0);
            Console.Write("                                ");
            Position.MoveCursorMainStart(0);
            Console.WriteLine("Database filled successfully.");

        }
        public static void FirstAdmin(ShopDbContext database)
        {

            if (database.Administrators.Any())
            {
                return;
            }

            var administrator = new List<Administrator>
            {
                        new Administrator
            {
                Name = "Admin",
                Age =36,
                Email = "admin@hog.se",
                Password  = "admin",
                Phone ="555-236865",
                Street ="Admingatan 7",
                PostalCode="61192",
                City ="Nykoping",
                Country="Sweden",
            }
        };
            database.Administrators.AddRange(administrator);
            database.SaveChanges();
            Position.MoveCursorMainStart(0);
            Console.Write("                                ");
            Position.MoveCursorMainStart(0);
            Console.WriteLine("Welcome to your new shop Admin, press any key to continue");
            Console.ReadKey();

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
        public static string StringBreak(string stringBreak, int rowLength)
        {
            string reworkedString = "";
            string[] stringArray = stringBreak.Split(' ');
            string stringWip = "";
            int wordNumber = 0;
            int wordCount = 0;
            int placedWord = 0;
            int allWords = stringArray.Length;
            while (placedWord < allWords)
            {
                int wordCountMarker = wordNumber;
                while (stringWip.Length < rowLength)
                {
                    stringWip = stringWip + stringArray[wordNumber] + " ";
                    wordCount++;
                    if (wordNumber < allWords - 1) { wordNumber++; }
                    else { }
                }
                wordCount--;
                stringWip = "";
                wordNumber = wordCountMarker;
                for (int i = 0; i < wordCount; i++)
                {
                    if (placedWord < allWords)
                    {
                        stringWip = stringWip + stringArray[wordNumber] + " ";
                        if (wordNumber < allWords - 1) { wordNumber++; }
                        placedWord++;
                    }
                }
                reworkedString = reworkedString + stringWip.TrimEnd() + "\n";
                stringWip = "";
                wordCount = 0;
            }
            return reworkedString;
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
