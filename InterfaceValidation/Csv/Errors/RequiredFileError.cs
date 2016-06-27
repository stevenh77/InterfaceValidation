namespace InterfaceValidation.Csv.Errors
{
    public class RequiredFileError : ValidationError
    {
        public RequiredFileError(string fileName) : base(fileName)
        {
        }

        public override string ToString()
        {
            return base.ToString() + $"  Required file missing: {FileName}";
        }
    }
}
