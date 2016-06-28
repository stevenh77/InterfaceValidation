namespace InterfaceValidation.Csv.Messages
{
    public class UnexpectedFileMessage : ValidationMessage
    {
        public UnexpectedFileMessage(string fileName) : base(fileName)
        {
        }
    }
}
