namespace BlockSharp
{
    public interface IBlock
    {
        string Hash { get; set; }
        string PreviousBlockHash { get; set; }
    }

    public interface IBlock<T> : IBlock
    {
        T Data { get; set; }        
    }
}
