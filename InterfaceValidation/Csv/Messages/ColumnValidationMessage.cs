namespace InterfaceValidation.Csv.Messages
{
    public class ColumnValidationMessage : ValidationMessage
    {
        public string ColumnName { get; set; }

        public ColumnValidationMessage(string fileName, string columnName) 
            : base(fileName)
        {
            ColumnName = columnName;
        }
    }
}
