namespace BlockSharp
{
    public interface IBlockChain<T>
    {
        string LastBlockHash { get; }
        T GetLastBlock();
        void AddBlock(T block);
    }
}
