namespace L_2_6.Interfaces
{
    public interface IValidator
    {
        void ValidateNotNull(object obj, string name);
        void ValidateNotNullOrEmptyString(string toValidate, string name);
    }
}