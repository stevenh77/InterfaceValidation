using System;
using System.Collections.Generic;
using System.Linq;
using InterfaceValidation.Csv.Messages;
using File = InterfaceValidation.Core.File;

namespace InterfaceValidation.Csv.Validators
{
    public class UnexpectedColumnValidator
    {
        public void Validate(IList<ValidationMessage> messages,
                                File file,
                                IEnumerable<string> columnHeaders)
        {
            foreach (var columnHeader in columnHeaders)
            {
                if (!file.Columns
                         .Select(c => c.Name.ToLowerInvariant())
                         .Contains(columnHeader.ToLowerInvariant()))
                {
                    messages.Add(new UnexpectedColumnMessage(file.Name, columnHeader));
                }
            }
        }
    }
}