namespace BlockSharp.Tests.Mocks
{
    public class MockBlock : BlockBase<string>
    {
        public MockBlock() { }

        public MockBlock(string data)
        {
            Data = data;
            ComputeHash();
        }
    }
}
