using System.Text.RegularExpressions;
using SimpleWebScrapper.Data;

namespace SimpleWebScrapper.Builders
{
    /// <summary>
    /// Builder class for creating ScrapeCriteriaPart objects.
    /// </summary>
    internal class ScrapeCriteriaPartBuilder
    {
        #region Properties

        // Private fields to hold the criteria part data
        private string _regex;
        private RegexOptions _regexOption;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the ScrapeCriteriaPartBuilder class with default values.
        /// </summary>
        public ScrapeCriteriaPartBuilder()
        {
            SetDefaults();
        }

        /// <summary>
        /// Sets the default values for the builder properties.
        /// </summary>
        private void SetDefaults()
        {
            _regex = string.Empty;
            _regexOption = RegexOptions.None;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets the regular expression to be used for scraping this part.
        /// </summary>
        /// <param name="regex">The regular expression string.</param>
        /// <returns>The current instance of the builder.</returns>
        public ScrapeCriteriaPartBuilder WithRegex(string regex)
        {
            _regex = regex;
            return this;
        }

        /// <summary>
        /// Sets the regular expression options to be used for scraping this part.
        /// </summary>
        /// <param name="regexOption">The regular expression options.</param>
        /// <returns>The current instance of the builder.</returns>
        public ScrapeCriteriaPartBuilder WithRegexOption(RegexOptions regexOption)
        {
            _regexOption = regexOption;
            return this;
        }

        /// <summary>
        /// Builds and returns a new ScrapeCriteriaPart object using the values set in the builder.
        /// </summary>
        /// <returns>A new ScrapeCriteriaPart object.</returns>
        public ScrapeCriteriaPart Build()
        {
            // Create a new ScrapeCriteriaPart object and populate its properties
            ScrapeCriteriaPart scrapeCriteriaPart = new ScrapeCriteriaPart
            {
                Regex = _regex,
                RegexOption = _regexOption
            };

            return scrapeCriteriaPart;
        }

        #endregion
    }
}