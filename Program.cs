using System;
using System.IO;
using System.Collections;
using NLog.Web;

namespace Movie_Library_2
{
    class Program
    {
          
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory() + "\\nlog.config";
            var logger = NLog.Web.NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();
            
            int option = 0;
            do
            {
                Console.WriteLine("1. View movies" + 
                "\n" + "2. Add movies" + 
                "\n" + "3. Exit");
                option = Convert.ToInt32(Console.ReadLine());
                string file = "movies.csv";



           if (option == 1)
                {
                    StreamReader sr = new StreamReader(file);

                    while (!sr.EndOfStream)
                    {
                        string movieDetails = sr.ReadLine();
                        string[] movieDetailsSplit = movieDetails.Split(',');
                        string movieID = movieDetailsSplit[0];
                        string movieTitle = movieDetailsSplit[1];
                        string[] genres = movieDetailsSplit[2].Split("|");

                        Console.Write($"ID: {movieID}, Title: '{movieTitle}', Genres: ");
                        for (int i = 0; i < genres.Length; i++)
                        {
                            if (i < genres.Length - 1)
                            {
                                Console.Write(genres[i] + ",");

                            }
                            else
                            {
                                Console.Write(genres[i]);
                            }
                        }
                        Console.WriteLine("");
                    }
                    sr.Close();
                }
                else if (option == 2)
                {
                    if (System.IO.File.Exists(file))
                    {
                        StreamWriter sw = new StreamWriter(@"movies.csv", true);

                        Console.WriteLine("Enter the id:");
                        string id = Console.ReadLine();

                        Console.WriteLine("What is the title of the movie?");
                        string movieTitle = Console.ReadLine();

                        var movieGenres = new ArrayList();
                        Console.WriteLine("How many genres are there?");
                        int numOfGenres = Convert.ToInt32(Console.ReadLine());

                        for (int i = 0; i < numOfGenres; i++)
                        {
                            Console.WriteLine("Please enter the name of the genre:");
                            string addToGenres = Console.ReadLine();
                            movieGenres.Add(addToGenres);
                        }
                        sw.WriteLine("");
                        sw.Write($"{id},{movieTitle},");

                        for (int i = 0; i < movieGenres.Count; i++)
                        {
                            if (i < movieGenres.Count - 1)
                            {
                                sw.Write(movieGenres[i] + "|");
                            }
                            else
                            {
                                sw.Write(movieGenres[i]);
                            }
                        }
                        Console.WriteLine("");
                        sw.Close();
                    }
                }
            }while (option != 3);
            if (option == 3){
                Console.WriteLine("Goodbye");
                System.Environment.Exit(0);
            }

        }



    }
}
