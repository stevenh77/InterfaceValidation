using System.Collections.Generic;
using System.IO.Abstractions;
using InterfaceValidation.Core;
using InterfaceValidation.Errors;

namespace InterfaceValidation.Validators
{
    public interface IValidator
    {
        List<ValidationError> Validate(IFileSystem fileSystem, Metadata metadata);
    }
}
