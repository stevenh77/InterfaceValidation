namespace InterfaceValidation.Csv.Errors
{
    public class EmptyFileError : ValidationError
    {
        public EmptyFileError(string fileName) : base(fileName)
        {
        }

        public override string ToString()
        {
            return base.ToString() + $"  Empty file: {FileName}";
        }
    }
}
