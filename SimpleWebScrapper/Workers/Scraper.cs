using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SimpleWebScrapper.Data;

namespace SimpleWebScrapper.Workers
{
    internal class Scraper
    {
        /// <summary>
        /// Scraps data from a given websites based on the provided ScraperCriteria
        /// </summary>
        /// <param name="scrapeCriteria"> The criteria defining how to scrape the data.</param>
        /// <returns> A List if strings containing the exteracted data elements</returns>
        public List<string> Scrape(ScrapeCriteria scrapeCriteria)
        {
            //List to store the scraped elements
            List<string> scrapedElements = new List<string>();

            //Preform the Scraping Operation
            try
            {
                //Match the data against the provided regular expression
                MatchCollection matches = Regex.Matches(scrapeCriteria.Data, scrapeCriteria.Regex, scrapeCriteria.RegexOption);

                //Iterate through each match
                foreach (Match match in matches)
                {
                    // Check if the scrape criteria specefies parts to be extracted
                    if (!scrapeCriteria.Parts.Any())
                    {
                        //If no parts are specified, extract the entire match
                        scrapedElements.Add(match.Groups[0].Value);
                    }
                    else
                    {
                        //Parts are specified, extract the data within the match
                        foreach (var part in scrapeCriteria.Parts)
                        {
                            //Match the part's regular expression against the current match
                            Match matchedPart = Regex.Match(match.Groups[0].Value, part.Regex, part.RegexOption);

                            //Check if the match was found
                            if (matchedPart.Success)
                            {
                                //Add the matched part to the list of scraped elements
                                scrapedElements.Add(matchedPart.Groups[1].Value);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //Log the Exeption for debugging purposes
                Console.WriteLine($"Error During Scraping: {ex.Message}");
            }
            //Return the scraped elements list
            return scrapedElements;

        }
    }
}
