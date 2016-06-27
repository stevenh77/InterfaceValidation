using System.Collections.Generic;
using System.IO.Abstractions;
using InterfaceValidation.Core;
using InterfaceValidation.Csv.Errors;

namespace InterfaceValidation.Csv.Validators
{
    public class InvalidDataInColumnValidator : IValidator
    {
        public List<ValidationError> Validate(IFileSystem fileSystem, Metadata metadata)
        {
            var validationErrors = new List<ValidationError>();
            return validationErrors;
        }
    }
}
