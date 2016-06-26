using System.Collections.Generic;
using System.IO.Abstractions;
using InterfaceValidation.Errors;
using InterfaceValidation.Validators;

namespace InterfaceValidation.Core
{
    public interface IExecutor
    {
        List<ValidationError> Process(IFileSystem fileSystem, 
                                        Metadata metadata, 
                                        List<IValidator> validators);
    }
}
