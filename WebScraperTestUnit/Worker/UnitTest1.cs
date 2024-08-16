using NUnit.Framework;
using System.Text.RegularExpressions;
using SimpleWebScrapper.Workers;
using SimpleWebScrapper.Builders;
using SimpleWebScrapper.Data;


namespace WebScraperTestUnit.Worker
{
    /// <summary>
    ///  Sets up the tests for the Scraper class.
    /// </summary>
    public class Tests
    {
     
        /// <summary>
        /// Test that the Scraper can extract a single element with a single part.
        /// </summary>
        [Test]
        public void Test1()
        {
            // Arrange
            var content = "Some fluff data <a href=\"http://domain.com\" data-id=\"someId\" class=\"result-title hdrlnk\">some text</a> more fluff data";

            ScrapeCriteria scrapeCriteria = new ScraperCriteriaBuilder()
                .WithData(content)
                .WithRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"">(.*?)</a>")
                .WithRegexOption(RegexOptions.ExplicitCapture)
                .Build();

            // Act
            var scraper = new Scraper();
            var foundElements = scraper.Scrape(scrapeCriteria);

            // Assert
            Assert.That(foundElements.Count, Is.EqualTo(1));
            Assert.That(foundElements[0], Is.EqualTo("<a href=\"http://domain.com\" data-id=\"someId\" class=\"result-title hdrlnk\">some text</a>"));
        }


        /// <summary>
        /// Test that the Scraper can extract multiple elements with multiple parts.
        /// </summary>

        [Test]
        public void Test2()
        {
            // Arrange
            var content = "Some fluff data <a href=\"http://domain.com\" data-id=\"someId\" class=\"result-title hdrlnk\">some text</a> more fluff data";

            ScrapeCriteria scrapeCriteria = new ScraperCriteriaBuilder()
                  .WithData(content)
                  .WithRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"">(.*?)</a>")
                  .WithRegexOption(RegexOptions.ExplicitCapture)
                  .WithParts(new ScrapeCriteriaPartBuilder()
                      .WithRegex(@">(.*?)</a>")
                      .WithRegexOption(RegexOptions.Singleline)
                      .Build())
                  .WithParts(new ScrapeCriteriaPartBuilder()
                      .WithRegex(@"href=\""(.*?)\""")
                      .WithRegexOption(RegexOptions.Singleline)
                      .Build())
                  .Build();


            // Act
            var scraper = new Scraper();
            var foundElements = scraper.Scrape(scrapeCriteria);

            // Assert
            Assert.That(foundElements.Count, Is.EqualTo(2));
            Assert.That(foundElements[0], Is.EqualTo("some text"));
            Assert.That(foundElements[1], Is.EqualTo("http://domain.com"));
        }
    }
}
