using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using SimpleWebScrapper.Data;

namespace SimpleWebScrapper.Builders
{
    class ScrapeCritieriaPartBuilder
    {
        #region Attributes
            private string _regex;
            private RegexOptions _regexOption;
        #endregion

        #region Constructor
        //The constructor is going to set the default values for the attributes
        public ScrapeCritieriaPartBuilder()
        {
            SetDefaults();
        }       

        private void SetDefaults()
        {
            _regex = string.Empty;
            _regexOption = RegexOptions.None;
        }
        #endregion

        #region Methods

        public ScrapeCritieriaPartBuilder WithRegex(string regex)
        {
            _regex = regex;
            return this;
        }

        public ScrapeCritieriaPartBuilder WithRegexOption(RegexOptions regexOption)
        {
            _regexOption = regexOption;
            return this;
        }

        public ScrapeCriteriaPart Build()
        {
            ScrapeCriteriaPart scrapeCriteriaPart = new ScrapeCriteriaPart();
            scrapeCriteriaPart.Regex = _regex;
            scrapeCriteriaPart.RegexOption = _regexOption;
            return scrapeCriteriaPart;
        }

        #endregion


    }
}
