using System.Linq;
using System.ComponentModel;

/**
*--------------------------------------------------------------------
* File name:                Program.cs
* Project name:             2910-201-GayCaden-Lab1
*--------------------------------------------------------------------
* Author’s name and email:  Caden Gay, gaycm1@etsu.edu
* Course-Section:           2910-201
* Creation Date:            January 24, 2024
* -------------------------------------------------------------------
*/

namespace _2910_Lab1_CadenGay
{
    public class Program
    {
        public static void Main()
        {
            //Setting relative file path (.csv is in Lab1 project folder)
            string filePath = "../../../videogames.csv";

            //Creating a master list for all the games to be read into
            List<VideoGame> MasterVideoGameList = new List<VideoGame>();

            //Reading in .csv to MasterVideoGameList
            using (var reader = new StreamReader(filePath))
            {
                reader.ReadLine();
                while (reader.EndOfStream == false)
                {
                    string line = reader.ReadLine();
                    //Split by commas for a csv (duh)
                    var tuples = line.Split(',');

                    //Parameterized constructor used to create new VideoGame objects 
                    VideoGame videoGame = new VideoGame(tuples[0], tuples[1], int.Parse(tuples[2]), tuples[3], tuples[4], double.Parse(tuples[5]), double.Parse(tuples[6]), double.Parse(tuples[7]), double.Parse(tuples[8]), double.Parse(tuples[9]));

                    //Adding newly created VideoGame to a list
                    MasterVideoGameList.Add(videoGame);
                }
            }

            MasterVideoGameList.Sort();

            int totalGamesCount = MasterVideoGameList.Count(); //Getting the count of master list for math later

            //Buffer -- letting user know they're about to see Nintendo games
            Console.WriteLine("Press any key to show all games from the publisher Nintendo.");
            Console.ReadKey();

            //Creating a new list of games only from Nintendo and displaying to console
            var nintendoGames = MasterVideoGameList.Where(vg => vg.Publisher == "Nintendo").OrderBy(vg => vg.Name).ToList();
            foreach (var showGame in nintendoGames) 
            {
                Console.WriteLine(showGame);
            }

            //Calculating and displaying percentage of Nintendo games vs Total game count
            int nintendoGamesCount = nintendoGames.Count();
            double percentOfTotalGames = ((double)nintendoGamesCount / (double)totalGamesCount) * 100;
            Console.WriteLine($"Out of {totalGamesCount} games, {nintendoGamesCount} are Nintendo games, which is {Math.Round(percentOfTotalGames, 2)}%.");

            //Buffer -- letting user know they're about to see Shooter games
            Console.WriteLine("Press any key to show all games in the Shooter genre.");
            Console.ReadKey();

            //Creating a new list of games only from the Shooter genre
            var shooterGames = MasterVideoGameList.Where(vg => vg.Genre == "Shooter").OrderBy(vg => vg.Name).ToList();
            foreach (var showGame in shooterGames) 
            {
                Console.WriteLine(showGame);
            }

            //Calculating and displaying percentage of Shooter games vs Total game count
            int shooterGamesCount = shooterGames.Count();
            percentOfTotalGames = ((double)shooterGamesCount / (double)totalGamesCount) * 100;
            Console.WriteLine($"Out of {totalGamesCount} games, {shooterGamesCount} are shooter games, which is {Math.Round(percentOfTotalGames, 2)}%.");

            //Calling PublisherData method
            PublisherData();

            //Calling GenreData method
            GenreData();

            Console.WriteLine("Bye bye!");
        }

        public static void PublisherData()
        {
            //Setting relative file path (.csv is in Lab1 project folder)
            string filePath = "../../../videogames.csv";

            //Creating a master list for all the games to be read into
            List<VideoGame> MasterVideoGameList = new List<VideoGame>();

            //Reading in .csv to MasterVideoGameList
            using (var reader = new StreamReader(filePath))
            {
                reader.ReadLine();
                while (reader.EndOfStream == false)
                {
                    string line = reader.ReadLine();
                    //Split by commas for a csv (duh)
                    var tuples = line.Split(',');

                    //Parameterized constructor used to create new VideoGame objects 
                    VideoGame videoGame = new VideoGame(tuples[0], tuples[1], int.Parse(tuples[2]), tuples[3], tuples[4], double.Parse(tuples[5]), double.Parse(tuples[6]), double.Parse(tuples[7]), double.Parse(tuples[8]), double.Parse(tuples[9]));

                    //Adding newly created VideoGame to a list
                    MasterVideoGameList.Add(videoGame);
                }
            }

            MasterVideoGameList.Sort();

            int totalGamesCount = MasterVideoGameList.Count(); //Getting the count of master list for math later

            Console.Write("Please enter which game publisher you would like to see a list of games from: ");

            bool exitLoop = false; //Controls exiting the While loop

            //This while loop will try to capture user input for Publisher until it gets a successful input
            //When it gets a successful input it displays all games by the Publisher and a statistic
            while (exitLoop == false)
            {
                try
                {
                    //Capturing user input
                    string publisherName = Console.ReadLine();
                    var userSelectPublisherGames = MasterVideoGameList.Where(vg => vg.Publisher == publisherName).OrderBy(vg => vg.Name).ToList();

                    //If there are no games by a publisher, user retries
                    if(userSelectPublisherGames.Count() == 0)
                    {
                        Console.WriteLine("There were no games found under this Publisher.");
                        Console.WriteLine("Please note that your entry is case-sensitive, and try again.");
                        exitLoop = false;
                    }
                    //If there are entries in the csv under a publisher name, it shows them all and shows the userInput / totalGames percentage
                    else if(userSelectPublisherGames.Count() > 0) 
                    {
                        foreach (var showGame in userSelectPublisherGames)
                        {
                            Console.WriteLine(showGame);
                        }

                        int userSelectPublisherGamesCount = userSelectPublisherGames.Count();
                        double percentOfTotalGames = ((double)userSelectPublisherGamesCount / (double)totalGamesCount) * 100;
                        //Fulfilling the percent calculation requirement
                        Console.WriteLine($"Out of {totalGamesCount} games, {userSelectPublisherGamesCount} are games published by {publisherName}, which is {Math.Round(percentOfTotalGames, 2)}%.");

                        //Sets the bool to true and exits loop
                        exitLoop = true;
                    }
                }
                //If user input was simply invalid, try again to capture input
                catch (Exception) 
                { 
                    Console.WriteLine("Something went wrong, please try again.");
                    exitLoop = false;
                }
            }
        }

        public static void GenreData()
        {
            //Setting relative file path (.csv is in Lab1 project folder)
            string filePath = "../../../videogames.csv";

            //Creating a master list for all the games to be read into
            List<VideoGame> MasterVideoGameList = new List<VideoGame>();

            //Reading in .csv to MasterVideoGameList
            using (var reader = new StreamReader(filePath))
            {
                reader.ReadLine();
                while (reader.EndOfStream == false)
                {
                    string line = reader.ReadLine();
                    //Split by commas for a csv (duh)
                    var tuples = line.Split(',');

                    //Parameterized constructor used to create new VideoGame objects 
                    VideoGame videoGame = new VideoGame(tuples[0], tuples[1], int.Parse(tuples[2]), tuples[3], tuples[4], double.Parse(tuples[5]), double.Parse(tuples[6]), double.Parse(tuples[7]), double.Parse(tuples[8]), double.Parse(tuples[9]));

                    //Adding newly created VideoGame to a list
                    MasterVideoGameList.Add(videoGame);
                }
            }

            MasterVideoGameList.Sort();

            int totalGamesCount = MasterVideoGameList.Count(); //Getting the count of master list for math later

            //Going to capture user input for a video game Genre
            Console.Write("Please enter which game genre you would like to see a list of games from: ");

            bool exitLoop = false; //Controls exiting the while loop

            //This while loop will try to capture user input for Genre until it gets a successful input
            //When it gets a successful input it displays all games by the Genre and a statistic
            while (exitLoop == false)
            {
                try
                {
                    //Capturing user input
                    string genreName = Console.ReadLine();
                    //Putting all the games that match this Genre into their own list
                    var userSelectGenreGames = MasterVideoGameList.Where(vg => vg.Genre == genreName).OrderBy(vg => vg.Name).ToList();

                    //If there are no games listed under the user input Genre, retries to capture input
                    if (userSelectGenreGames.Count() == 0)
                    {
                        Console.WriteLine("There were no games found under this Genre.");
                        Console.WriteLine("Please note that your entry is case-sensitive, and try again.");
                        exitLoop = false;
                    }
                    //If the list does contain games, print to user and show percentage of selected Genre vs total amt of games
                    else if (userSelectGenreGames.Count() > 0)
                    {
                        //Iterating through and printing the games of a genre the user selected
                        foreach (var showGame in userSelectGenreGames)
                        {
                            Console.WriteLine(showGame);
                        }

                        //Calculating the percentage of games in user's selected genre vs total amount of games
                        int userSelectGenreGamesCount = userSelectGenreGames.Count();
                        double percentOfTotalGames = ((double)userSelectGenreGamesCount / (double)totalGamesCount) * 100;
                        //Fulfilling the percentage requirement
                        Console.WriteLine($"Out of {totalGamesCount} games, {userSelectGenreGamesCount} are games in the {genreName} genre, which is {Math.Round(percentOfTotalGames, 2)}%.");

                        //Exiting the loop
                        exitLoop = true;
                    }
                }
                //If something goes wrong, try to capture user input again
                catch (Exception)
                {
                    Console.WriteLine("Something went wrong, please try again.");
                    exitLoop = false;
                }
            }
        }
    }
}