using NUnit.Framework;
using System.Text.RegularExpressions;
using SimpleWebScrapper.Workers;
using SimpleWebScrapper.Builders;
using SimpleWebScrapper.Data;


namespace WebScraperTestUnit.Worker
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var content = "Some fluff data <a href=\"http://domain.com\" data-id=\"someId\" class=\"result-title hdrlnk\">some text</a> more fluff data";

            ScrapeCriteria scrapeCriteria = new ScraperCriteriaBuilder()
                .WithData(content)
                .WithRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"">(.*?)</a>")
                .WithRegexOption(RegexOptions.ExplicitCapture)
                .Build();
            var scraper = new Scraper();
            var foundElements = scraper.Scrape(scrapeCriteria);

            Assert.That(foundElements.Count, Is.EqualTo(1));
            Assert.That(foundElements[0], Is.EqualTo("<a href=\"http://domain.com\" data-id=\"someId\" class=\"result-title hdrlnk\">some text</a>"));
        }


        [Test]
        public void Test2()
        {
            var content = "Some fluff data <a href=\"http://domain.com\" data-id=\"someId\" class=\"result-title hdrlnk\">some text</a> more fluff data";

            ScrapeCriteria scrapeCriteria = new ScraperCriteriaBuilder()
                .WithData(content)
                .WithRegex(@"<a href=\""(.*?)\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"">(.*?)</a>")
                .WithRegexOption(RegexOptions.ExplicitCapture)
                .WithPart(new ScrapeCriteriaPartBuilder()
                    .WithRegex(@">(.*?)</a>")
                    .WithRegexOption(RegexOptions.Singleline)
                    .Build())
                .WithPart(new ScrapeCriteriaPartBuilder()
                    .WithRegex(@"href=\""(.*?)\""")
                    .WithRegexOption(RegexOptions.Singleline)
                    .Build())
                .Build();


            var scraper = new Scraper();
            var foundElements = scraper.Scrape(scrapeCriteria);
            Assert.That(foundElements.Count, Is.EqualTo(2));
            Assert.That(foundElements[0], Is.EqualTo("some text"));
            Assert.That(foundElements[1], Is.EqualTo("http://domain.com"));
        }
    }
}
