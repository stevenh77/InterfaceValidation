namespace InterfaceValidation.Csv.Messages
{
    public class EmptyFileMessage : ValidationMessage
    {
        public EmptyFileMessage(string fileName) : base(fileName)
        {
        }
    }
}
