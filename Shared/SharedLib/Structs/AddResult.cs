namespace SharedLib.Structs
{
    public struct AddResult
    {
        public bool IsSuccess;
        public string ErrorMessage;

        public AddResult(string errormessage = null)
        {
            IsSuccess = string.IsNullOrWhiteSpace(errormessage);
            ErrorMessage = errormessage;
        }
    }
}