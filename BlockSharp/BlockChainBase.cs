using System.Collections.Generic;
using System.Linq;

namespace BlockSharp
{
    public abstract class BlockChainBase<T> : IBlockChain<T>
        where T : IBlock
    {
        private const string NO_PREVIOUS_BLOCK_HASH = "0000000000000000000000000000000000000000000000000000000000000000";
        private readonly IList<T> _blockChain;
        private string _lastBlockHash = NO_PREVIOUS_BLOCK_HASH;

        public string LastBlockHash { get => _lastBlockHash; }

        protected BlockChainBase()
        {
            _blockChain = new List<T>();
        }

        public T GetLastBlock()
        {
            return _blockChain.LastOrDefault();
        }

        public void AddBlock(T block)
        {
            block.PreviousBlockHash = _lastBlockHash;
            _lastBlockHash = block.Hash;
            _blockChain.Add(block);
        }


    }
}
