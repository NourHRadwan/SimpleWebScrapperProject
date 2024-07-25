using System;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using SimpleWebScrapper.Data;
using SimpleWebScrapper.Workers;
using System.Runtime.CompilerServices;
using SimpleWebScrapper.Builders;

namespace SimpleWebScrapper
{
    internal class Program
    {
        #region Ask the user for input
        // <summary>
        // Gets user input for the city to scrape data from.
        // </summary>
        // <returns>The city name entered by the user.</returns>

        static string GetCityInput()
        {
            Console.WriteLine("Enter the city you want to scrape data from: ");
            return Console.ReadLine() ?? "";
        }

        // <summary>
        // Gets user input for the category to scrape data from.
        // </summary>
        // <returns>The category name entered by the user.</returns>
        static string GetCategoryInput()
        {
            Console.WriteLine("Enter the category you want to scrape data from: ");
            return Console.ReadLine() ?? "";
        }
        #endregion

        #region Content Download
        // <summary>
        // Downloads the HTML content of the specified URL Page.
        // </summary>
        // <param name="city"> The city to scrape data from.</param>
        // <param name="category"> The category to scrape data from.</param>
        // <returns>The downloaded HTML content of the specified URL Page.</returns>

        static string DownloadContent(string city, string category)
        {   
            using (WebClient client = new WebClient())
            {
                try {
                    return client.DownloadString($"https://{city.Replace(" ", string.Empty)}.craigslist.org/search/{category}");
                    // string.Empty to handle the case where the city name has a space in it Like New York.
                }
                catch (WebException ex)
                {
                    Console.WriteLine($"Error Downloading Content: {ex.Message}");
                    return "";
                }
                
             }
        }
        #endregion

        #region ScrapeCrieteria Creation
        // <summary>
        // Creates a scrape criteria object based on the provided content and regex pattern.
        // </summary>
        // <param name="content"> The HTML content to scrape data from.</param>
        // <param name="regexpattern"> The regualr expression pattern to use for scraping data.</param>
        // <returns>The scrape criteria object created based on the provided content and regex pattern.</returns>
        static ScrapeCriteria CreateScrapeCriteria(string content, string regexpattern)
        {
            ScrapeCriteria scrapeCriteria = new ScraperCriteriaBuilder()
                .WithData(content)
                .WithRegex(regexpattern)
                .WithRegexOption(RegexOptions.ExplicitCapture) // ExplicitCapture to ignore the unnamed groups in the regex pattern.
                
                //creating object of scrapping criteria part builder inside the scraper criteria builder.
                .WithParts(new ScrapeCriteriaPartBuilder()
                    .WithRegex(@">(.*?)</a>")
                    .WithRegexOption(RegexOptions.Singleline)
                    .Build())
                .WithParts(new ScrapeCriteriaPartBuilder()
                    .WithRegex(@"href=\""(.*?\""")
                    .WithRegexOption(RegexOptions.Singleline)
                    .Build())
                .Build();
            return scrapeCriteria;
        }
        #endregion
        static void Main(string[] args)
        {
        }
    }
}