using System.Collections.Generic;
using System.IO.Abstractions;
using InterfaceValidation.Core;
using InterfaceValidation.Csv.Errors;
using InterfaceValidation.Csv.Validators;

namespace InterfaceValidation.Csv
{
    public class Processor : IProcessor
    {
        public List<ValidationError> Execute(IFileSystem fileSystem, 
                                                Metadata metadata, 
                                                List<IValidator> validators)
        {
            var validationErrors = new List<ValidationError>();

            foreach (var validator in validators)
                validationErrors.AddRange(validator.Validate(fileSystem, metadata));
            
            return validationErrors;
        }
    }
}