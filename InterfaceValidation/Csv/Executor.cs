using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using InterfaceValidation.Core;
using InterfaceValidation.Errors;
using InterfaceValidation.Validators;

namespace InterfaceValidation.Csv
{
    public class Executor : IExecutor
    {
        public List<ValidationError> Process(IFileSystem fileSystem, 
                                                Metadata metadata, 
                                                List<IValidator> validators)
        {
            if (fileSystem == null) throw new NullReferenceException("fileSystem");
            if (metadata==null) throw new NullReferenceException("metadata");
            if (validators == null) throw new NullReferenceException("validators");

            var validationErrors = new List<ValidationError>();

            foreach (var validator in validators)
                validationErrors.AddRange(validator.Validate(fileSystem, metadata));
            
            return validationErrors;
        }
    }
}