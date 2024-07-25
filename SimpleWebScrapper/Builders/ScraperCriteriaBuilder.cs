using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SimpleWebScrapper.Data;

namespace SimpleWebScrapper.Builders
{
    /// <summary>
    /// Builder class for creating ScrapeCriteria objects.
    /// </summary>
    internal class ScraperCriteriaBuilder
    {
        #region Properties

        // Private fields to hold the criteria data
        private string? _data;
        private string? _regex;
        private RegexOptions _regexOption;
        private List<ScrapeCriteriaPart>? _parts;
        private ScrapeCriteria? _scrapeCriteria;


        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the ScraperCriteriaBuilder class with default values.
        /// </summary>
        public ScraperCriteriaBuilder()
        {
           SetDefaults();
        }

        /// <summary>
        /// Sets the default values for the builder properties.
        /// </summary>
        private void SetDefaults()
        {
            _data = string.Empty;
            _regex = string.Empty;
            _regexOption = RegexOptions.None;
            _parts = new List<ScrapeCriteriaPart>();
            _scrapeCriteria = null;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the data to be scraped.
        /// </summary>
        /// <param name="data">The data to be scraped.</param>
        /// <returns>The current instance of the builder.</returns>
        public ScraperCriteriaBuilder WithData(string? data)
        {
            _data = data;
            return this;
        }

        /// <summary>
        /// Sets the regular expression to be used for scraping.
        /// </summary>
        /// <param name="regex">The regular expression string.</param>
        /// <returns>The current instance of the builder.</returns>
        public ScraperCriteriaBuilder WithRegex(string? regex)
        {
            _regex = regex;
            return this;
        }

        /// <summary>
        /// Sets the regular expression options to be used for scraping.
        /// </summary>
        /// <param name="regexOption">The regular expression options.</param>
        /// <returns>The current instance of the builder.</returns>
        public ScraperCriteriaBuilder WithRegexOption(RegexOptions regexOption)
        {
            _regexOption = regexOption;
            return this;
        }

        /// <summary>
        /// Sets the parts of the scrape criteria.
        /// </summary>
        /// <param name="parts"></param>
        /// <returns></returns>

        public ScraperCriteriaBuilder WithParts(ScrapeCriteriaPart scrapeCriteriaPart)
        {
            _parts?.Add(scrapeCriteriaPart); //adding the scrape criteria part to the list of parts.
            return this;
        }

        /// <summary>
        /// Builds and returns a new ScrapeCriteria object using the values set in the builder.
        /// </summary>
        /// <returns>A new ScrapeCriteria object.</returns>
        public ScrapeCriteria Build()
        {
                ScrapeCriteria _scrapeCriteria = new ScrapeCriteria();
           
                _scrapeCriteria.Data = (_data is not null) ? _data : "";
                _scrapeCriteria.Regex =(_regex is not null) ? _regex : "";
                _scrapeCriteria.RegexOption = _regexOption;
                _scrapeCriteria.Parts = (_parts is not null) ? _parts : throw new ArgumentException("Parts cannot be null.");            ;
            return _scrapeCriteria;
        }

        #endregion
    }
}