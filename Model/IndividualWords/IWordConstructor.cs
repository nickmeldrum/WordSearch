namespace Model.IndividualWords
{
    public interface IWordConstructor {
        int MaxLettersToSearch { get; }
        string Direction { get; }
        int[] CharacterIndexes(int wordLength);
        string StringFromIndexes(int wordLength);
        string StringFromIndexes(int[] characterIndexes);
    }
}