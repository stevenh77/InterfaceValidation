using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using InterfaceValidation.Csv.Messages;
using System.Linq;
using File = InterfaceValidation.Core.File;

namespace InterfaceValidation.Csv
{
    public class Processor
    {
        public IEnumerable<ValidationMessage> Execute(ProcessorRequest request)
        {
            var messages = new List<ValidationMessage>();
            var filesInDirectory = ReadFilesInDirectory(request.FileSystem, request.Path);

            request.UnexpectedFile.Validate(messages, filesInDirectory, request.Files, request.FileExtension);

            foreach (var file in request.Files)
            {
                request.RequiredFile.Validate(messages, filesInDirectory, file);
                ProcessFile(messages, filesInDirectory, request, file);
            }
            return messages;
        }

        private void ProcessFile(List<ValidationMessage> messages, IEnumerable<string> filesInDirectory, ProcessorRequest request, File file)
        {
            if (!filesInDirectory.Contains(file.Name)) return;

            using (var reader = new StreamReader(file.Name))
            {
                var line = reader.ReadLine();
                if (!request.FileChecksum.Read(messages, file.Name, line)) return;

                var columnHeaders = request.DelimiterParser.Get(line);
                ProcessColumnHeaderRow(request, file, messages, reader, columnHeaders);

                var i = ProcessBody(request, file, messages, reader, columnHeaders);

                request.FileChecksum.Validate(messages, file.Name, i);
            }
        }

        private void ProcessColumnHeaderRow(ProcessorRequest request, File file, List<ValidationMessage> messages, StreamReader reader, IEnumerable<string> columnHeaders)
        {
            reader.ReadLine();
            request.RequiredColumn.Validate(messages, file, columnHeaders);
            request.UnexpectedColumn.Validate(messages, file, columnHeaders);
        }

        private int ProcessBody(ProcessorRequest request, File file, List<ValidationMessage> messages, StreamReader reader, IEnumerable<string> columnHeaders)
        {
            string line;
            int i = 0;
            while ((line = reader.ReadLine()) != null)
            {
                i++;
                var data = request.DelimiterParser.Get(line);
                request.InvalidDataInColumn.Validate(messages, file, i, columnHeaders, data);
            }
            return i;
        }

        private IEnumerable<string> ReadFilesInDirectory(IFileSystem fileSystem, string path)
        {
            return fileSystem.Directory
                             .GetFiles(path)
                             .Select(fileSystem.Path.GetFileName);
        }
    }
}