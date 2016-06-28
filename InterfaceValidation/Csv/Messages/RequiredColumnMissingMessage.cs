namespace InterfaceValidation.Csv.Messages
{
    public class RequiredColumnMissingMessage : ColumnValidationMessage
    {
        public RequiredColumnMissingMessage(string fileName, string columnName) 
            : base(fileName, columnName)
        {
        }
    }
}
