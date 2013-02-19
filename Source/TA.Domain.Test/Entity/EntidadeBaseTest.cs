using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TA.Domain.Test.Entity
{
    [TestClass]
    public class EntidadeBaseTest
    {
        [TestMethod]
        public void CompareTo_IEntidade()
        {
            ulong id = 1;
            EntidadeBaseMock mock = new EntidadeBaseMock() { Id = id };
            EntidadeBaseMock mock2 = new EntidadeBaseMock() { Id = id };

            Assert.AreEqual(id.CompareTo(id), mock.CompareTo(mock2));
        }

        [TestMethod]
        public void Equals_IEntidade()
        {
            ulong id = 1;
            EntidadeBaseMock mock = new EntidadeBaseMock() { Id = id };
            EntidadeBaseMock mock2 = new EntidadeBaseMock() { Id = id };

            Assert.AreEqual(id.Equals(id), mock.Equals(mock2));
        }

        [TestMethod]
        public void Equals_Object()
        {
            ulong id = 1;
            EntidadeBaseMock mock = new EntidadeBaseMock() { Id = id };
            object mock2 = new EntidadeBaseMock() { Id = id };

            Assert.AreEqual(id.Equals(id), mock.Equals(mock2));
        }

        [TestMethod]
        public void EntidadeBase_GetHashCode()
        {
            ulong id = 1;
            EntidadeBaseMock mock = new EntidadeBaseMock() { Id = id };

            Assert.AreEqual(id.GetHashCode(), mock.GetHashCode());
        }
    }
}
