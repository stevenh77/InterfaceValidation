using System.Collections.Generic;
using System.IO.Abstractions;
using InterfaceValidation.Core;
using InterfaceValidation.Csv.Errors;

namespace InterfaceValidation.Csv.Validators
{
    public interface IValidator
    {
        List<ValidationError> Validate(IFileSystem fileSystem, Metadata metadata);
    }
}
