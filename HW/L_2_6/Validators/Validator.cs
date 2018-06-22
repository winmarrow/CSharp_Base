using L_2_6.Exceptions;
using L_2_6.Interfaces;

namespace L_2_6.Validators
{
    public class Validator : IValidator
    {
        public void ValidateNotNull(object toValidateObj, string name)
        {
            if (toValidateObj == null)
                throw new InitializationIssue($"The object was not initialized - {name}");
        }

        public void ValidateNotNullOrEmptyString(string toValidateString, string name)
        {
            if (string.IsNullOrEmpty(toValidateString))
                throw new InitializationIssue($"The string is Null Or Empty - {name}");
        }
    }
}