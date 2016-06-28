using System.Collections.Generic;
using System.Linq;
using InterfaceValidation.Csv.Messages;
using File = InterfaceValidation.Core.File;

namespace InterfaceValidation.Csv.Validators
{
    public class RequiredColumnValidator
    {
        public void Validate(IList<ValidationMessage> messages,
                                File file, 
                                IEnumerable<string> columnHeaders)
        {
            foreach (var column in file.Columns)
            {
                if (columnHeaders.Contains(column.Name.ToLowerInvariant()))
                {
                    messages.Add(
                        new InfoMessage(file.Name)
                        {
                            Message = column.IsRequired
                                ? $"Required column found: {file.Name}.{column.Name}"
                                : $"Optional column found: {file.Name}.{column.Name}"
                        });
                }
                else if (column.IsRequired)
                    messages.Add(new RequiredColumnMissingMessage(file.Name, column.Name));
            }
        }
    }
}
