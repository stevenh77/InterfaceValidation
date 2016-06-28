namespace InterfaceValidation.Csv.Messages
{
    public class UnexpectedColumnMessage : ColumnValidationMessage
    {
        public UnexpectedColumnMessage(string fileName, string columnName) 
            : base(fileName, columnName)
        {
        }
    }
}
