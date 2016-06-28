using System.Collections.Generic;
using InterfaceValidation.Csv.Messages;

namespace InterfaceValidation.Csv.Validators
{
    public class FileChecksumValidator
    {
        public int Checksum { get; private set; }

        public bool Read(IList<ValidationMessage> messages, string filename, string line)
        {
            if (line == null)
            {
                messages.Add(new EmptyFileMessage(filename));
                return false;
            }
            // return invalid checksum line if not found

            Checksum = 100;
            return true;
        }

        public void Validate(IList<ValidationMessage> messages,
                                string filename,
                                int numberOfLines)
        {
            if (numberOfLines != Checksum)
                messages.Add(new ChecksumFailedMessage(filename) { Expected = Checksum, Actual = numberOfLines });

            Checksum = 0;
        }
    }
}