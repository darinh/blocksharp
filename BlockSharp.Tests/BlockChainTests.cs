using BlockSharp.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlockSharp.Tests
{
    [TestClass]
    public class BlockChainTests
    {
        private const string NO_PREVIOUS_BLOCK_HASH = "0000000000000000000000000000000000000000000000000000000000000000";
        [TestMethod]
        public void BlockChainHashLinkingTest()
        {
            var blockChain = new MockBlockChain();

            var block1 = new MockBlock("block1");
            var block2 = new MockBlock("block2");
            var block3 = new MockBlock("block3");

            // no blocks
            Assert.AreEqual(NO_PREVIOUS_BLOCK_HASH, blockChain.LastBlockHash);

            Assert.IsNull(block1.PreviousBlockHash);
            blockChain.AddBlock(block1);
            Assert.AreEqual(NO_PREVIOUS_BLOCK_HASH, block1.PreviousBlockHash);
            Assert.AreEqual(block1.Hash, blockChain.LastBlockHash);

            Assert.IsNull(block2.PreviousBlockHash);
            blockChain.AddBlock(block2);
            Assert.AreEqual(block1.Hash, block2.PreviousBlockHash);
            Assert.AreEqual(block2.Hash, blockChain.LastBlockHash);

            Assert.IsNull(block3.PreviousBlockHash);
            blockChain.AddBlock(block3);
            Assert.AreEqual(block2.Hash, block3.PreviousBlockHash);
            Assert.AreEqual(block3.Hash, blockChain.LastBlockHash);
        }

        [TestMethod]
        public void BlockChainLastBlockTest()
        {
            var blockChain = new MockBlockChain();

            var block1 = new MockBlock("block1");
            var block2 = new MockBlock("block2");
            var block3 = new MockBlock("block3");

            // no blocks
            Assert.IsNull(blockChain.GetLastBlock());

            blockChain.AddBlock(block1);
            var lastBlock = blockChain.GetLastBlock();
            Assert.AreEqual(block1, lastBlock);

            blockChain.AddBlock(block2);
            lastBlock = blockChain.GetLastBlock();
            Assert.AreNotEqual(block1, lastBlock);
            Assert.AreEqual(block2, lastBlock);

            blockChain.AddBlock(block3);
            lastBlock = blockChain.GetLastBlock();
            Assert.AreNotEqual(block1, lastBlock);
            Assert.AreNotEqual(block2, lastBlock);
            Assert.AreEqual(block3, lastBlock);
        }
    }
}
