using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
System.Text.RegularExpressions;
using WebScraper.Workers;
using WebScraper.Data;
using NUnit.Framework;

    public class ScraperTest
    {
        private readonly Scraper _scraper = new Scraper();
        [TestMethod]
        public void FindCollectionWithNoSegments()
        {
            /// <summary>
            /// Test the 'Scrape' method of the 'Scraper' class using HTML content and regular expression pattern.
            /// </summary>


            //Arrange
            var content = "content data <a href=\"http://domain.com\" data-id=\"IdNumber\" class=\"result-title hdrlnk\">Title</a> content data";
            ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder()
                .WithData(content)
                .WithRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"">(.*?)</a>")
                .WithRegexOption(RegexOptions.ExplicitCapture)
                .Build();


            //Act
            var scrapedElements = _scraper.Scrape(scrapeCriteria);

            //Assert  --> used to verfiy the expected behavior of the Scrape method.
            Assert.IsTrue(scrapedElements.Count == 1);
            Assert.IsTrue(scrapedElements[0] == " <a href=\\\"http://domain.com\\\" data-id=\\\"IdNumber\\\" class=\\\"result-title hdrlnk\\\">Title</a> content data");


        }
    }
}
