namespace InterfaceValidation.Csv.Errors
{
    public class ColumnValidationError : ValidationError
    {
        public string ColumnName { get; set; }

        public ColumnValidationError(string fileName, string columnName) 
            : base(fileName)
        {
            ColumnName = columnName;
        }
    }
}
