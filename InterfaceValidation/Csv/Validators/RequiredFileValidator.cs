using System.Collections.Generic;
using System.Linq;
using InterfaceValidation.Csv.Messages;
using File = InterfaceValidation.Core.File;

namespace InterfaceValidation.Csv.Validators
{
    public class RequiredFileValidator
    {
        public void Validate(IList<ValidationMessage> messages,
                                IEnumerable<string> filesInDirectory, 
                                File file)
        {
            if (file.IsRequired && filesInDirectory.Contains(file.FullFilename))
                messages.Add(new InfoMessage(file.Name) { Message = "Required file found" });
            else if (file.IsRequired)
                messages.Add(new RequiredFileMissingMessage(file.Name));
        }
    }
}