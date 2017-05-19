using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlockSharp.Tests.Mocks;

namespace BlockSharp.Tests
{
    [TestClass]
    public class BlockTests
    {
        [TestMethod]
        public void SettingDataByPropertyComputesHash()
        {
            var blockData = "Hello!";
            var blockDataHash = "19ff7e39d988355c61531c5be566e37f4b6a758d7b3cc96928310d4f950ba634";
            var block = new MockBlock();
            Assert.IsNull(block.Hash);
            block.Data = blockData;
            Assert.AreEqual(blockDataHash, block.Hash);
        }
        
        [TestMethod]
        public void SettingDataThroughConstructorComputesHash()
        {
            var blockData = "Hello!";
            var blockDataHash = "19ff7e39d988355c61531c5be566e37f4b6a758d7b3cc96928310d4f950ba634";
            var block = new MockBlock(blockData);
            Assert.IsNotNull(block.Hash);
            Assert.AreEqual(blockDataHash, block.Hash);
        }
    }
}
