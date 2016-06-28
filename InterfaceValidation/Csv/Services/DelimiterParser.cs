using System;
using System.Collections.Generic;
using System.Linq;

namespace InterfaceValidation.Csv.Services
{
    public class DelimiterParser : IDelimiterParser
    {
        private readonly string _delimiter;

        public DelimiterParser(string delimiter)
        {
            _delimiter = delimiter;
        }

        public IEnumerable<string> Get(string line)
        {
            if (line==null) return new List<string>();
            return line.Split(new[] { _delimiter }, StringSplitOptions.None)
                       .Select(heading => heading.ToLowerInvariant());
        }
    }
}
