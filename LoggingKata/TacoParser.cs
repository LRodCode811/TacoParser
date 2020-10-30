using System;
using System.Linq;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            string[] cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log that and return null
                TacoLogger tacologger = new TacoLogger();
                logger.LogInfo(line);
                // Do not fail if one record parsing fails, return null
                return null; // TODO Implement
            }
            // Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`
            // grab the latitude from your array at index 0
            double latitude = 0;
            var lat = double.TryParse(cells[0], out latitude);

            // grab the longitude from your array at index 1
            double longitude = 0;
            var lon = double.TryParse(cells[1], out longitude); 

            // grab the name from your array at index 2
            string name = cells[2];

            // You'll need to create a TacoBell class
            // that conforms to ITrackable

            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly
            TacoBell tacoBell = new TacoBell
            {
                Name = name
            };

            Point pt = new Point
            {
                Longitude = longitude,
                Latitude = latitude
            };
            tacoBell.Location = pt;   
           
            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable
            if ((lat == false) || (lon == false))
                {
                logger.LogError("Could Not Parse.", null);
                }

            return tacoBell;
        }
    }
}