namespace InterfaceValidation.Csv.Errors
{
    public class UnexpectedColumnError : ColumnValidationError
    {
        public UnexpectedColumnError(string fileName, string columnName) 
            : base(fileName, columnName)
        {
        }

        public override string ToString()
        {
            return base.ToString() + $"  Unexpected column found: {FileName}.{ColumnName}";
        }
    }
}
