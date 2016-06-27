using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using InterfaceValidation.Core;
using InterfaceValidation.Csv.Errors;

namespace InterfaceValidation.Csv.Validators
{
    public class UnexpectedColumnValidator : IValidator
    {
        public List<ValidationError> Validate(IFileSystem fileSystem, Metadata metadata)
        {
            var validationErrors = new List<ValidationError>();

            foreach (var file in metadata.Files)
            {
                var filename = fileSystem.Path.Combine(metadata.Path, file.Name + "." + metadata.FileExtension);
                if (!fileSystem.File.Exists(filename)) continue;

                using (var reader = new StreamReader(filename))
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        // this check is performed during RequiredColumnMissingValidator
                        //validationErrors.Add(new EmptyFileError(file.Name));
                        continue;
                    }

                    var columnHeadersInFile = line.Split(new[] { metadata.Delimiter }, StringSplitOptions.None);

                    foreach (var columnHeaderInFile in columnHeadersInFile)
                    {
                        // check to see if the column is in the metadata
                        if (!file.Columns
                                .Select(heading => heading.Name.ToLowerInvariant())
                                .Contains(columnHeaderInFile.ToLowerInvariant()))
                        {
                            validationErrors.Add(new UnexpectedColumnError(file.Name, columnHeaderInFile));
                        }
                    }
                }

            }
            return validationErrors;
        }
    }
}