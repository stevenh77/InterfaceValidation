using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using InterfaceValidation.Core;
using InterfaceValidation.Csv.Errors;

namespace InterfaceValidation.Csv.Validators
{
    public class RequiredFileValidator : IValidator
    {
        public List<ValidationError> Validate(IFileSystem fileSystem, Metadata metadata)
        {
            var validationErrors = new List<ValidationError>();
            foreach (var file in metadata.Files.Where(f => f.IsRequired))
            {
                if (fileSystem.File.Exists(Path.Combine(metadata.Path, file.Name + "." + metadata.FileExtension)))
                    Debug.WriteLine($"Required file found: {file.Name}");
                else
                    validationErrors.Add(new RequiredFileError(file.Name));
            }
            return validationErrors;
        }
    }
}
