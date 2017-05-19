using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

namespace BlockSharp
{
    public abstract class BlockBase<T> : IBlock<T>
    {
        #region Fields
        private T _data;
        #endregion

        #region Public Properties
        public T Data
        {
            get => _data;
            set
            {
                _data = value;
                ComputeHash();
            }
        }
        public string Hash { get; set; }
        public string PreviousBlockHash { get; set; }
        #endregion

        #region Protected Methods
        protected virtual void ComputeHash()
        {
            var bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, Data);
                var blockData = ms.ToArray();

                using (var provider = new SHA256CryptoServiceProvider())
                {
                    var hash = provider.ComputeHash(blockData);
                    Hash = BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
                }
            }
        }
        #endregion
    }
}
