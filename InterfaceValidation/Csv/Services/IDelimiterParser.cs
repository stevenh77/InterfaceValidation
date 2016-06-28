using System.Collections.Generic;

namespace InterfaceValidation.Csv.Services
{
    public interface IDelimiterParser
    {
        IEnumerable<string> Get(string line);
    }
}
