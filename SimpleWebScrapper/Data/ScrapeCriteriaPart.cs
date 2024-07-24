using System.Text.RegularExpressions;

namespace SimpleWebScrapper.Data
{
    /// <summary>
    /// Represents a part of a scraping criteria with a regular expression and options.
    /// </summary>
    internal class ScrapeCriteriaPart
    {
        #region Properties

        /// <summary>
        /// Gets or sets the regular expression to be used for scraping this part.
        /// </summary>
        public string Regex { get; set; }

        /// <summary>
        /// Gets or sets the regular expression options to be used for scraping this part.
        /// </summary>
        public RegexOptions RegexOption { get; set; }

        #endregion
    }
}