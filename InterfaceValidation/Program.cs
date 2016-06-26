using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Abstractions;
using InterfaceValidation.Core;
using InterfaceValidation.Validators;

namespace InterfaceValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            var validationErrors = new Csv.Executor().Process(
                new FileSystem(), 
                new MetadataService().Get(),
                new List<IValidator>()
                {
                    new RequiredFileValidator(),
                    new RequiredColumnValidator(),
                    new UnexpectedFileValidator(),
                    new UnexpectedColumnValidator(),
                    new InvalidDataInColumnValidator()
                });

            foreach (var validationError in validationErrors)
                Debug.WriteLine(validationError);

            Environment.Exit(validationErrors.Count);
        }
    }
}
