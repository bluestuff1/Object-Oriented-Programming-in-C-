using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace P3._2
{
    public class Counter
    {
        private int _count;

        public Counter()
        {
            _count = 0;
        }

        public void Next()
        {
            _count++;
        }

        public void Reset()
        {
            _count = 0;
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }
    }

    [TestFixture]
    public class TestCounter
    {
        Counter c;
        [Test]
        public void TestCounterCreate()
        {
            c = new Counter();

            Assert.AreEqual(0, c.Count, "Counter should start at 0");
        }

        [Test]
        public void TestCounterNext()
        {
            c = new Counter();
            c.Next();

            Assert.AreEqual(1, c.Count, "Counter should be 1 after incremented");
        }

        [Test]
        public void TestCounterReset()
        {
            c = new Counter();
            c.Next();
            c.Reset();

            Assert.AreEqual(0, c.Count, "Counter should be 0 after resetted");
        }
          
    }

}
