using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SimpleWebScrapper.Data
{
    /// <summary>
    /// Represents criteria for scraping data from a website, including a main regular expression and optional parts.
    /// </summary>
    internal class ScrapeCriteria
    {
        #region Properties

        /// <summary>
        /// Gets or sets the data to be scraped. This could be the entire HTML content or a specific section.
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Gets or sets the main regular expression to be used for scraping.
        /// </summary>
        public string Regex { get; set; }

        /// <summary>
        /// Gets or sets the regular expression options to be used for scraping.
        /// </summary>
        public RegexOptions RegexOption { get; set; }

        /// <summary>
        /// Gets or sets a list of additional scraping criteria parts. Each part can have its own regular expression and options.
        /// </summary>
        public List<ScrapeCriteriaPart> Parts { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the ScrapeCriteria class with an empty list of parts.
        /// </summary>
        public ScrapeCriteria()
        {
            Parts = new List<ScrapeCriteriaPart>();
        }

        #endregion
    }
}