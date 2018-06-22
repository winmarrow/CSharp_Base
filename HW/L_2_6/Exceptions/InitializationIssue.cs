using System;

namespace L_2_6.Exceptions
{
    [Serializable]
    public class InitializationIssue : Exception
    {
        public InitializationIssue()
        {
        }

        public InitializationIssue(string message) : base(message)
        {
        }

        public InitializationIssue(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}