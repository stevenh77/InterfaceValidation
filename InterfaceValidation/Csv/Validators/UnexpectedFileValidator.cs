using System.Collections.Generic;
using System.Linq;
using InterfaceValidation.Core;
using InterfaceValidation.Csv.Messages;

namespace InterfaceValidation.Csv.Validators
{
    public class UnexpectedFileValidator
    {
        public void Validate(
            IList<ValidationMessage> messages,
            IEnumerable<string> filesInDirectory,
            IEnumerable<File> files,
            string fileExtension)
        {
            foreach (var file in filesInDirectory)
            {
                if (!files.Select(f => f.Name.ToLowerInvariant() + "." + fileExtension)
                             .Contains(file.ToLowerInvariant()))
                    messages.Add(new UnexpectedFileMessage(file));
            }
        }
    }
}
