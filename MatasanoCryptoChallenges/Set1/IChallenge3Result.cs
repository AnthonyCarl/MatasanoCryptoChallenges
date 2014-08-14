namespace MatasanoCryptoChallenges.Set1
{
    public interface IChallenge3Result
    {
        decimal WeightedValue { get; }
        byte Key { get; }
        string DecryptedMessage { get; }
    }
}