using System.Collections.Generic;
using InterfaceValidation.Core;
using InterfaceValidation.Csv.Messages;

namespace InterfaceValidation.Csv.Validators
{
    public class InvalidDataInColumnValidator
    {
        public void Validate(IList<ValidationMessage> messages,
                                File file,
                                int lineNumber,
                                IEnumerable<string> columnHeaders,
                                IEnumerable<string> data)
        {
            foreach (var column in file.Columns)
            {
                //messages.Add(new InvalidDataInColumnMessage(file.Name, column.Name));
            }
        }
    }
}
