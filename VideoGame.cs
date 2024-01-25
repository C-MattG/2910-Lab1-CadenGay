using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
*--------------------------------------------------------------------
* File name:                VideoGame.cs
* Project name:             2910-201-GayCaden-Lab1
*--------------------------------------------------------------------
* Author’s name and email:  Caden Gay, gaycm1@etsu.edu
* Course-Section:           2910-201
* Creation Date:            January 24, 2024
* -------------------------------------------------------------------
*/

namespace _2910_Lab1_CadenGay
{
    /// <summary>
    /// VideoGame is a class that is made to intake values from videogames.csv
    /// </summary>
    public class VideoGame : IComparable<VideoGame>
    {
        //Attributes of a video game
        public string Name { get; set; }
        public string Platform { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public double NA_Sales { get; set; }
        public double EU_Sales { get; set; }
        public double JP_Sales { get; set; }
        public double Other_Sales { get; set; }
        public double Global_Sales { get; set; }

        //Default constructor
        public VideoGame()
        {
            Name = string.Empty;
            Platform = string.Empty;
            Year = 0;
            Genre = string.Empty;
            Publisher = string.Empty;
            NA_Sales = 0;
            EU_Sales = 0;
            JP_Sales = 0;
            Other_Sales = 0;
        }

        //Parameterized constructor
        public VideoGame(string name, string platform, int year, string genre, string publisher, double na_Sales, double eu_Sales, double jp_Sales, double other_Sales, double global_Sales)
        {
            Name = name;
            Platform = platform;
            Year = year;
            Genre = genre;
            Publisher = publisher;
            NA_Sales = na_Sales;
            EU_Sales = eu_Sales;
            JP_Sales = jp_Sales;
            Other_Sales = other_Sales;
            Global_Sales = global_Sales;
        }

        //CompareTo implementation
        public int CompareTo(VideoGame other)
        {
            return this.Name.CompareTo(other.Name);
        }

        //ToString override
        public override string ToString()
        {
            string output = "";
            output += $"Name:         {Name}\n";
            output += $"Platform:     {Platform}\n";
            output += $"Year:         {Year}\n";
            output += $"Genre:        {Genre}\n";
            output += $"Publisher:    {Publisher}\n";
            output += $"NA Sales:     {NA_Sales}\n";
            output += $"EU Sales:     {EU_Sales}\n";
            output += $"JP Sales:     {JP_Sales}\n";
            output += $"Other Sales:  {Other_Sales}\n";
            output += $"Global Sales: {Global_Sales}\n";

            return output;
        }
    }
}
