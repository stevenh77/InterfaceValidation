namespace InterfaceValidation.Csv.Messages
{
    public class InfoMessage : ValidationMessage
    {
        public string Message { get; set; }

        public InfoMessage(string fileName) : base(fileName)
        {
        }
    }
}
