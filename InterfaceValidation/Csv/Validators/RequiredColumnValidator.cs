using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using InterfaceValidation.Core;
using InterfaceValidation.Csv.Errors;

namespace InterfaceValidation.Csv.Validators
{
    public class RequiredColumnValidator : IValidator
    {
        public List<ValidationError> Validate(IFileSystem fileSystem, Metadata metadata)
        {
            var validationErrors = new List<ValidationError>();

            foreach (var file in metadata.Files)
            {
                var filename = fileSystem.Path.Combine(metadata.Path, file.Name + "." + metadata.FileExtension);
                if (!System.IO.File.Exists(filename)) continue;

                using (var reader = new StreamReader(filename))
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        validationErrors.Add(new EmptyFileError(file.Name));
                        continue;
                    }

                    var columnHeadersInFile = line.Split(new[] { metadata.Delimiter }, StringSplitOptions.None)
                                                  .Select(heading => heading.ToLowerInvariant());

                    foreach (var column in file.Columns)
                    {
                        if (columnHeadersInFile.Contains(column.Name.ToLowerInvariant()))
                        {
                            Debug.WriteLine(column.IsRequired
                                ? $"Required column found: {file.Name}.{column.Name}"
                                : $"Optional column found: {file.Name}.{column.Name}");
                        }
                        else if (column.IsRequired)
                            validationErrors.Add(new RequiredColumnError(file.Name, column.Name));
                    }
                }
            }
            return validationErrors;
        }
    }
}
