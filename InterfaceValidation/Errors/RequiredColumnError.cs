namespace InterfaceValidation.Errors
{
    public class RequiredColumnError : ColumnValidationError
    {
        public RequiredColumnError(string fileName, string columnName) 
            : base(fileName, columnName)
        {
        }

        public override string ToString()
        {
            return base.ToString() + $"  Required column missing: {FileName}.{ColumnName}";
        }
    }
}
