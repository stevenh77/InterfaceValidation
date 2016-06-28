namespace InterfaceValidation.Csv.Messages
{
    public class RequiredFileMissingMessage : ValidationMessage
    {
        public RequiredFileMissingMessage(string fileName) : base(fileName)
        {
        }
    }
}
