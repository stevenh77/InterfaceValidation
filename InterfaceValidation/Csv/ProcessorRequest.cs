using System.Collections.Generic;
using System.IO.Abstractions;
using InterfaceValidation.Csv.Services;
using InterfaceValidation.Csv.Validators;

namespace InterfaceValidation.Csv
{
    public class ProcessorRequest
    {
        public IFileSystem FileSystem { get; set; }
        public IEnumerable<Core.File> Files { get; set; }
        public string Path { get; set; }
        public string FileExtension { get; set; }
        public IDelimiterParser DelimiterParser { get; set; }
        public UnexpectedFileValidator UnexpectedFile { get; set; }
        public RequiredFileValidator RequiredFile { get; set; }
        public FileChecksumValidator FileChecksum { get; set; }
        public RequiredColumnValidator RequiredColumn { get; set; }
        public UnexpectedColumnValidator UnexpectedColumn { get; set; }
        public InvalidDataInColumnValidator InvalidDataInColumn { get; set; }
    }
}
