namespace InterfaceValidation.Csv.Errors
{
    public class UnexpectedFileError : ValidationError
    {
        public UnexpectedFileError(string fileName) : base(fileName)
        {
        }

        public override string ToString()
        {
            return base.ToString() + $"  Unexpected file found: {FileName}";
        }
    }
}
