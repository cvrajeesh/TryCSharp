using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TryCSharp.Tests
{
    [TestFixture]
    public class BijectiveRandomGeneratorTests
    {

        [TestCase(125, "cb")]
        [TestCase(3216, "Z2")]
        public void EncodeTests(long number, string encodedString)
        {
            // Assert
            Assert.AreEqual(encodedString, BijectiveRandomGenerator.Encode(number));
        }

        [TestCase("cb",125)]
        [TestCase("Z2", 3216)]
        public void DecodeTests(string encoded, long number)
        {
            // Assert
            Assert.AreEqual(number, BijectiveRandomGenerator.Decode(encoded));
        }
    }
}
