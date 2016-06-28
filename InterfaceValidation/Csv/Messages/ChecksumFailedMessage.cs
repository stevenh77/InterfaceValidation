namespace InterfaceValidation.Csv.Messages
{
    public class ChecksumFailedMessage : ValidationMessage
    {
        public int Actual { get; set; }
        public int Expected { get; set; }

        public ChecksumFailedMessage(string fileName) : base(fileName)
        {
        }
    }
}
