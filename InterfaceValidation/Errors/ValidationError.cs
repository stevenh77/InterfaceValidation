namespace InterfaceValidation.Errors
{
    public class ValidationError
    {
        public string FileName { get; set; }

        public ValidationError(string fileName)
        {
            FileName = fileName;
        }

        public override string ToString()
        {
            return "Validation error.";
        }
    }
}
