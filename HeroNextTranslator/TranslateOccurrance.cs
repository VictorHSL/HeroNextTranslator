using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroNextTranslator
{
    public class TranslateOccurrance
    {
        public FileInfo File { get; set; }
        public string Term { get; set; }

        public string DisplayName { get => $"{Term} in {File.Name}"; }
    }
}
