using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SimpleWebScrapper.Data
{
    internal class ScrapeCriteriaPart
    {
        #region Properties
        public string Regex { get; set; }
        public RegexOptions RegexOption { get; set; }
        #endregion
    }
}
