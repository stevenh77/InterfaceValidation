namespace InterfaceValidation.Csv.Messages
{
    public class InvalidDataInColumnMessage : ColumnValidationMessage
    {
        public string Data { get; set; }
        public string ExpectedType { get; set; }
        public string LineData { get; set; }
        public int LineNumber { get; set; }

        public InvalidDataInColumnMessage(string fileName, string columnName, int lineNumber) 
            : base(fileName, columnName)
        {
            LineNumber = lineNumber;
        }
    }
}
