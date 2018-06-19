namespace SharedLib.Structs
{
    public struct ChoiceResult
    {
        public int ChoisedIndex;
        public string ChoisedString;
        public bool IsRejected;

        public ChoiceResult(int choisedIndex, string choisedString, bool isRejected = false)
        {
            ChoisedIndex = choisedIndex;
            ChoisedString = choisedString;
            IsRejected = isRejected;
        }
    }
}