using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using InterfaceValidation.Core;
using InterfaceValidation.Errors;

namespace InterfaceValidation.Validators
{
    public class UnexpectedFileValidator : IValidator
    {
        public List<ValidationError> Validate(IFileSystem fileSystem, Metadata metadata)
        {
            var validationErrors = new List<ValidationError>();
            foreach (var file in fileSystem.Directory
                                           .GetFiles(metadata.Path)
                                           .Select(fileSystem.Path.GetFileName))
            {
                if (!metadata.Files
                            .Select(f => f.Name.ToLowerInvariant() + ".txt")
                            .Contains(file.ToLowerInvariant()))
                validationErrors.Add(new UnexpectedFileError(file));
            }
            return validationErrors;
        }
    }
}
