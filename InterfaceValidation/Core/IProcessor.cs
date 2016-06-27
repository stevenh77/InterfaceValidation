using System.Collections.Generic;
using System.IO.Abstractions;
using InterfaceValidation.Csv.Errors;
using InterfaceValidation.Csv.Validators;

namespace InterfaceValidation.Core
{
    public interface IProcessor
    {
        List<ValidationError> Execute(IFileSystem fileSystem, 
                                        Metadata metadata, 
                                        List<IValidator> validators);
    }
}
