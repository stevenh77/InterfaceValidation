using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Abstractions;
using InterfaceValidation.Csv;
using InterfaceValidation.Csv.Messages;
using InterfaceValidation.Csv.Services;
using InterfaceValidation.Csv.Validators;

namespace InterfaceValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileSystem = new FileSystem();
            var metadataService = new MetadataService();
            var metadata = metadataService.Get();
            var delimiterParser = new DelimiterParser(metadata.Delimiter);
            var fileChecksumValidator = new FileChecksumValidator();
            var invalidDataInColumnValidator = new InvalidDataInColumnValidator();
            var requiredColumnValidator = new RequiredColumnValidator();
            var requiredFileValidator = new RequiredFileValidator();
            var unexpectedColumnValidator = new UnexpectedColumnValidator();
            var unexpectedFileValidator = new UnexpectedFileValidator();
            var request = new ProcessorRequest()
            {
                DelimiterParser = delimiterParser,
                FileExtension = metadata.FileExtension,
                Files = metadata.Files,
                FileSystem = fileSystem,
                Path = metadata.Path,
                FileChecksum = fileChecksumValidator,
                InvalidDataInColumn = invalidDataInColumnValidator,
                RequiredColumn = requiredColumnValidator,
                RequiredFile = requiredFileValidator,
                UnexpectedColumn = unexpectedColumnValidator,
                UnexpectedFile = unexpectedFileValidator
            };
            var processor = new Processor();
            var messages = processor.Execute(request);
            OutputMessages(messages);
            Environment.Exit(0);
        }

        private static void OutputMessages(IEnumerable<ValidationMessage> messages)
        {
            foreach (var message in messages)
                Debug.WriteLine(message);
        }
    }
}
