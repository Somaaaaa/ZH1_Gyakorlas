using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace ZH_Gyakorlas
{
    internal class Program
    {
        class Games
        {
            public string title { get; set; }
            public string genre { get; set; }
            public string publisher { get; set; }
            public DateTime stadiaRelease { get; set; }
            public DateTime originalRelease { get; set; }
            public Games(string allLines, string genre)
            {
                string[] a = allLines.Split(';');
                title = a[0];
                this.genre = genre;
                publisher = a[2];
                stadiaRelease = DateTime.Parse(a[3]);
                originalRelease = DateTime.Parse(a[4]);
            }
        }
        static void Main(string[] args)
        {
            //1 feladat
            string[] genres = File.ReadAllText("genre.txt").Split(',');
            for (int i = 0; i < genres.Length; i++)
            {
                genres[i] = genres[i].Split('=')[0];
            }

            //2 feladat
            List<Games> games = new List<Games>();
            string[] allLines = File.ReadAllLines("stadia_dataset.csv");
            for (int i = 1; i < allLines.Length; i++)
            {
                games.Add(new Games(allLines[i], genres[int.Parse(allLines[i].Split(';')[1]) - 1]));
            }

            //3 feladat
            string answer = "";
            while (answer != "0")
            {
                Console.WriteLine("Adj meg egy számot 1-3 között, 0 ha ki akarsz lépni");
                answer = Console.ReadLine();             
                if (answer == "1")
                {
                    string kiado = Console.ReadLine();
                    int count = 0;
                    for (int i = 0; i < games.Count; i++)
                    {
                        if (games[i].publisher == kiado) count++;
                    }
                    Console.WriteLine(count);
                }
                if (answer == "2")
                {
                    for(int i = 0;i < games.Count; i++)
                    {
                        if (games[i].originalRelease.Year == games[i].stadiaRelease.Year)
                        {
                            Console.WriteLine($"{games[i].title} {games[i].genre} {games[i].originalRelease}");
                        }
                    }
                }
                if (answer == "3")
                {
                    int count = 0;
                    for(int i = 0; i < genres.Length; i++)
                    {
                        Console.Write($"{genres[i]} = ");
                        for(int j = 0; j < games.Count; j++)
                        {
                            if (genres[i] == games[j].genre) count++;
                        }
                        Console.WriteLine(count);
                        count = 0;
                    }
                }            
            }
        }
    }
}
