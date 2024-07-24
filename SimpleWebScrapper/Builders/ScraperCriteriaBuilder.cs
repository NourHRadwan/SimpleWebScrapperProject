using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using SimpleWebScrapper.Data;

namespace SimpleWebScrapper.Builders
{
    internal class ScraperCriteriaBuilder
    {
        #region Properties
        //The data that is required to create a builder is the following
        private string _data;
        private string _regex;
        private RegexOptions _regexOption;
        private List<ScrapeCriteriaPart> _parts;

        #endregion

        #region Constructor
        //
        public ScraperCriteriaBuilder()
        {
            SetDefaults();
        }

        //SetDefaults Methods is going to set the default values for the data
        private void SetDefaults()
        {
            //We are going to set the default value for the data to empty string
            _data = string.Empty;
            
            //We are going to set the default value for the regex to empty string
            _regex = string.Empty;

            //We are going to set the default value for the regexOption to None
            _regexOption = RegexOptions.None;

            //We are going to create a new empty list of ScrapeCriteriaPart
            _parts = new List<ScrapeCriteriaPart>();
        }
        #endregion

        #region Methods
        //We are going to create a method that is going to make it easier to set the object properties
        public ScraperCriteriaBuilder WithData(string data)
        {
            _data = data;
            return this;
        }
       
        public ScraperCriteriaBuilder WithRegex(string regex)
        {
            _regex = regex;
            return this;
        }

        public ScraperCriteriaBuilder WithRegexOption(RegexOptions regexOption)
        {
            _regexOption = regexOption;
            return this;
        }

        public ScrapeCriteria Build()
        {
            ScrapeCriteria scrapeCriteria = new ScrapeCriteria();
            scrapeCriteria.Data = _data;
            scrapeCriteria.Regex = _regex;
            scrapeCriteria.RegexOption = _regexOption;
            scrapeCriteria.Parts = _parts;
            return scrapeCriteria;
        }
        #endregion

    }
}
