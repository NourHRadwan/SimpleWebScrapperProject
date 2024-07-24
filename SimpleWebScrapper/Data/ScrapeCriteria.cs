using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SimpleWebScrapper.Data
{
    internal class ScrapeCriteria
    {
        #region Constructor

        public ScrapeCriteria()
        {
            Parts = new List<ScrapeCriteriaPart>();
        }

        #endregion
        #region Properties
        public string Data { get; set; }
        public string Regex { get; set; }
        public RegexOptions RegexOption { get; set; }

        public List<ScrapeCriteriaPart> Parts { get; set; }

        #endregion
    }
}
