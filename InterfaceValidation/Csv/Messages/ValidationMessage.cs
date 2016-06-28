namespace InterfaceValidation.Csv.Messages
{
    public class ValidationMessage
    {
        public string FileName { get; set; }

        public ValidationMessage(string fileName)
        {
            FileName = fileName;
        }
    }
}