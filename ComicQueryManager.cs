﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace Comics_App_For_Jimmy
{
    class ComicQueryManager
    {

        public ObservableCollection<ComicQuery> AvailableQueries { get; private set; }

        public ObservableCollection<object> CurrentQueryResults { get; private set; }

        public string Title { get; set; }

        public ComicQueryManager()
        {
            UpdateAvailableQueries();
            CurrentQueryResults = new ObservableCollection<object>();
        }

        private void UpdateAvailableQueries()
        {
            AvailableQueries = new ObservableCollection<ComicQuery> 
            {
                new ComicQuery("LINQ makes queries easy", "A sample query",
                    "Let's show Jimmy how flexible LINQ is",
                    "Assets/purple_250x250.jpg"),

                new ComicQuery("Expensive comics", "Comics over $500",
                    "Comics whose value is over 500 bucks."
                        + " Jimmy can use this to figure out which comics are most coveted.",
                    "Assets/captain_amazing_250x250.jpg"),

                new ComicQuery("LINQ is versatile 1", "Modify every item returned from the query",
                    "This code will add a string onto the end of each string in an array.",
                    "Assets/bluegray_250x250.jpg"),
                new ComicQuery("LINQ is versatile 2", "Perform calculations on collections",
                    "LINQ provides extension methods for your collections (and anything else"
                      + " that implements IEnumerable<T>).",
                    "Assets/purple_250x250.jpg"),
                new ComicQuery("LINQ is versatile 3",
                    "Store all or part of your results in a new sequence",
                    "Sometimes you'll want to keep your results from a LINQ query around.",
                    "Assets/bluegray_250x250.jpg"),

                new ComicQuery("Group comics by price range",
                    "Combine Jimmy's values into groups",
                    "Jimmy buys a lot of cheap comic books, some midrange comic books, and"
                         + " a few expensive ones, and he wants to know what his options are"
                         + " before he decides what comics to buy.",
                    "Assets/captain_amazing_250x250.jpg"),

                new ComicQuery("Join purchases with prices",
                    "Let's see if Jimmy drives a hard bargain",
                    "This query creates a list of Purchase classes that contain Jimmy's purchases"
                         + " and compares them with the prices he found on Greg's List.",
                    "Assets/captain_amazing_250x250.jpg"),

                new ComicQuery("All comics in the collection",
                   "Get all of the comics in the collection",
                   "This query returns all of the comics",
                   "Assets/captain_amazing_zoom_250x250.jpg"),
            };
        }

        public void UpdateQueryResults(ComicQuery query)
        {
            Title = query.Title;

            switch (query.Title)
            {
                case "LINQ makes queries easy": 
                    LinqMakesQueriesEasy();
                    break;
                case "Expensive comics": 
                    ExpensiveComics(); 
                    break;
                case "LINQ is versatile 1": 
                    LinqIsVersatile1(); 
                    break;
                case "LINQ is versatile 2": 
                    LinqIsVersatile2(); 
                    break;
                case "LINQ is versatile 3": 
                    LinqIsVersatile3(); 
                    break;
                case "Group comics by price range":
                    CombineJimmysValuesIntoGroups();
                    break;
                case "Join purchases with prices":
                    JoinPurchasesWithPrices();
                    break;
                case "All comics in the collection": 
                    AllComics(); 
                    break;
            }
        }

        public static IEnumerable<Comic> BuildCatalog()
        {
            return new List<Comic> {
                 new Comic 
                 { 
                     Name = "Johnny America vs. the Pinko",
                     Issue = 6,
                     Year = 1949,
                     CoverPrice = "10 cents",
                     MainVillain = "The Pinko",
                     Cover = "Assets/Captain Amazing Issue 6 cover.png",
                     Synopsis = "Captain Amazing must save America from Communists as The Pinko and his"
                         + " communist henchmen threaten to take over Fort Knox and steal all of the nation's gold." 
                 },

                 new Comic 
                 { 
                     Name = "Rock and Roll (limited edition)",
                     Issue = 19, Year = 1957,
                     CoverPrice = "10 cents",
                     MainVillain = "Doctor Vortran",
                     Cover = "Assets/Captain Amazing Issue 19 cover.png",
                     Synopsis = "Doctor Vortran wreaks havoc with the nation's youth with his radio wave device that"
                         + " uses the latest dance craze to send rock and roll fans into a mind-control trance." 
                 },

                new Comic 
                { 
                    Name = "Woman's Work",
                    Issue = 36, Year = 1968,
                    CoverPrice = "12 cents",
                    MainVillain = "Hysterianna",
                    Cover = "Assets/Captain Amazing Issue 36 cover.png",
                    Synopsis = "The Captain faces his first female foe, Hysterianna, whose incredible telepathic"
                        + " and telekinetic abilities have allowed her to raise an all-girl army that"
                        + " even the Captain has trouble resisting." 
                },

                new Comic 
                { 
                    Name = "Hippie Madness (misprinted)",
                    Issue = 57,
                    Year = 1973,
                    CoverPrice = "20 cents",
                    MainVillain = "The Mayor",
                    Cover = "Assets/Captain Amazing Issue 57 cover.png",
                    Synopsis = "A zombie apocalypse threatens Objectville when The Mayor rigs the election by"
                        + " introducing his zombification agent into the city's cigarette supply." 
                },

                new Comic 
                { 
                    Name = "Revenge of the New Wave Freak (damaged)",
                    Issue = 68, Year = 1984,
                    CoverPrice = "75 cents",
                    MainVillain = "The Swindler",
                    Cover = "Assets/Captain Amazing Issue 68 cover.png",
                    Synopsis = "A tainted batch of eye makeup turns Dr. Alvin Mudd into the Captain's new nemesis,"
                        + " in The Swindler's first appearance in a Captain Amazing comic." 
                },

                new Comic 
                { 
                    Name = "Black Monday",
                    Issue = 74,
                    Year = 1986,
                    CoverPrice = "75 cents",
                    MainVillain = "The Mayor",
                    Cover = "Assets/Captain Amazing Issue 74 cover.png",
                    Synopsis = "The Mayor returns to throw Objectville into a financial crisis by directing his"
                        + " zombie creation powers to the floor of the Objectville Stock Exchange." 
                },

                new Comic 
                {
                    Name = "Tribal Tattoo Madness",
                    Issue = 83,
                    Year = 1996,
                    CoverPrice = "Two bucks",
                    MainVillain = "Mokey Man",
                    Cover = "Assets/Captain Amazing Issue 83 cover.png",
                    Synopsis = "Monkey Man escapes from his island prison and wreaks havoc with his circus sideshow"
                        + " of tattooed henchmen that and their deadly grunge ray." 
                },

                new Comic 
                { 
                    Name = "The Death of an Object",
                    Issue = 97,
                    Year = 2013,
                    CoverPrice = "Four bucks",
                    MainVillain = "The Swindler",
                    Cover = "Assets/Captain Amazing Issue 97 cover.png",
                    Synopsis = "The Swindler's clone army attacks Objectville in a ruse to trap and kill the "
                        + " Captain. Can the scientists of Objectville find a way to bring him back?" 
                },
            };
        }

        private static Dictionary<int, decimal> GetPrices()
        {
            return new Dictionary<int, decimal> 
            {
                { 6, 3600M },
                { 19, 500M },
                { 36, 650M },
                { 57, 13525M },
                { 68, 250M },
                { 74, 75M },
                { 83, 25.75M },
                { 97, 35.25M },
            };
        }

        private void LinqMakesQueriesEasy()
        {
            int[] values = new int[] { 0, 12, 44, 36, 92, 54, 13, 8 };
            var result = values.Where(v => v < 37)
                               .OrderBy(v => v)
                               .Select(v => new
                               {
                                   Title = v.ToString(),
                                   ImagePath = "Assets/purple_250x250.jpg",
                               });
            foreach (var item in result)
                CurrentQueryResults.Add(item);
        }


        private void ExpensiveComics()
        {
            IEnumerable<Comic> comics = BuildCatalog();
            Dictionary<int, decimal> values = GetPrices();

            var mostExpensive = comics.Where(comic => values[comic.Issue] > 500)
                                      .OrderByDescending(comic => values[comic.Issue])
                                      .Select(comic => new
                                      {
                                          Title = $"{comic.Name} is worth {values[comic.Issue]:c}",
                                          ImagePath = "Assets/captain_amazing_250x250.jpg",
                                      });
            foreach(var item in mostExpensive)
                CurrentQueryResults.Add(item);
        }

        private void LinqIsVersatile1()
        {
            string[] sandwiches = { "ham and cheese", "salami with mayo", "turkey and swiss", "chicken cutlet" };
            var sandwichesOnRye = sandwiches.Select(sandwich => sandwich + " on rye");

            foreach (var sandwich in sandwichesOnRye)
                CurrentQueryResults.Add(CreateAnonymousListViewItem(sandwich, "bluegray_250x250.jpg"));
        }


        private void LinqIsVersatile2()
        {
            Random random = new Random();
            List<int> listOfNumbers = Enumerable.Range(0, random.Next(50, 150))
                                                .Select(_ => random.Next(100))
                                                .ToList();

            CurrentQueryResults.Add(CreateAnonymousListViewItem($"There are {listOfNumbers.Count} numbers"));
            CurrentQueryResults.Add(CreateAnonymousListViewItem($"The smallest is {listOfNumbers.Min()}"));
            CurrentQueryResults.Add(CreateAnonymousListViewItem($"The biggest is {listOfNumbers.Max()}"));
            CurrentQueryResults.Add(CreateAnonymousListViewItem($"The sum is {listOfNumbers.Sum()}"));
            CurrentQueryResults.Add(CreateAnonymousListViewItem($"The average is {listOfNumbers.Average():F2}"));
        }


        private void LinqIsVersatile3()
        {
            List<int> listOfNumbers = Enumerable.Range(1, 10000).ToList();
            var under50sorted = listOfNumbers.Where(number => number < 50)
                                             .OrderByDescending(number => number)
                                             .Take(6);

            foreach (var number in under50sorted)
                CurrentQueryResults.Add(CreateAnonymousListViewItem(number.ToString(), "bluegray_250x250.jpg"));
        }

        private object CreateAnonymousListViewItem(string title, string imageFilename = "purple_250x250.jpg")
        {
            return new
            {
                Title = title,
                ImagePath = "Assets/" + imageFilename,
            };
        }

        private void CombineJimmysValuesIntoGroups()
        {
            Dictionary<int, decimal> values = GetPrices();
            var priceGroups = values.GroupBy(pair => Purchase.EvaluatePrice(pair.Value))
                                    .OrderByDescending(group => group.Key)
                                    .Select(group =>
                                    {
                                        string message = $"I found {group.Count()} {group.Key} comics: issues ";
                                        message += string.Join(" ", group.Select(issue => issue));
                                        return CreateAnonymousListViewItem(message, "captain_amazing_250x250.jpg");
                                    });

            foreach (var item in priceGroups)
                CurrentQueryResults.Add(item);
        }

        private void JoinPurchasesWithPrices()
        {
            IEnumerable<Comic> comics = BuildCatalog();
            Dictionary<int, decimal> values = GetPrices();
            IEnumerable<Purchase> purchases = Purchase.FindPurchases();
            var results = comics.Join(purchases,
                                       comic => comic.Issue,
                                       purchase => purchase.Issue,
                                       (comic, purchase) => new
                                       {
                                           Comic = comic,
                                           purchase.Price,
                                           Title = comic.Name,
                                           Subtitle = $"Issue #{comic.Issue}",
                                           Description = $"Bought for {purchase.Price:c}",
                                           ImagePath = "Assets/captain_amazing_250x250.jpg",
                                       })
                                .OrderBy(result => result.Comic.Issue);

            decimal gregsListValue = 0;
            decimal totalSpent = 0;
            foreach (var result in results)
            {
                gregsListValue += values[result.Comic.Issue];
                totalSpent += result.Price;
                CurrentQueryResults.Add(result);
            }

            Title = $"I spent {totalSpent:c} on comics worth {gregsListValue:c}";
        }

        private void AllComics()
        {
            foreach (Comic comic in BuildCatalog())
            {
                var result = new
                {
                    ImagePath = "Assets/captain_amazing_zoom_250x250.jpg",
                    Title = comic.Name,
                    Subtitle = "Issue #" + comic.Issue,
                    Description = "The Captain versus " + comic.MainVillain,
                    Comic = comic,
                };
                CurrentQueryResults.Add(result);
            }
        }
    }
}