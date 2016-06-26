namespace InterfaceValidation.Errors
{
    public class InvalidDataInColumnError : ColumnValidationError
    {
        public int LineNumber { get; set; }
        public string Data { get; set; }
        public string ExpectedType { get; set; }

        public InvalidDataInColumnError(string fileName, string columnName, int lineNumber) 
            : base(fileName, columnName)
        {
            LineNumber = lineNumber;
        }

        public override string ToString()
        {
            return base.ToString() + 
                $"  Invalid data in column: {FileName}.{ColumnName}, line {LineNumber}, expected type {ExpectedType}, data {Data}";
        }
    }
}
