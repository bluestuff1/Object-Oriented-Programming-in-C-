using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace P3._2
{
    public class Clock
    {
        private Counter _seconds;
        private Counter _minutes;
        private Counter _hours;

        public Clock()
        {
            _seconds = new Counter();
            _minutes = new Counter();
            _hours = new Counter();
        }

        public void Tick()
        {
            _seconds.Next();
            if (_seconds.Count >= 60)
            {
                _seconds.Reset();
                _minutes.Next();
            }

            if (_minutes.Count >= 60)
            {
                _minutes.Reset();
                _hours.Next();
            }

            if (_hours.Count >= 24)
            {
                _hours.Reset();
            }
        }

        public void PrintTime()
        {
            Console.WriteLine(_hours.Count.ToString("00") + ":" + _minutes.Count.ToString("00") + ":" + _seconds.Count.ToString("00"));
        }

        //Made for testing
        public string Time
        {
            get
            {
                return _hours.Count.ToString("00") + ":" + _minutes.Count.ToString("00") + ":" + _seconds.Count.ToString("00");
            }
        }
    }

    [TestFixture]
    public class TestClock
    {
        Clock c;

        [Test]
        public void TestClockCreate()
        {
            c = new Clock();

            Assert.AreEqual("00:00:00", c.Time, "The clock should start as 00:00:00");
        }

        [Test]
        public void TestClockTick()
        {
            c = new Clock();
            c.Tick();

            Assert.AreEqual("00:00:01", c.Time, "The clock should be 00:00:01");
        }

        [Test]
        public void TestClockSecondsReset()
        {
            c = new Clock();
            for (int i = 0; i < 60; i++)
            {
                c.Tick();
            }

            Assert.AreEqual("00:01:00", c.Time, "The seconds reset");
        }

        [Test]
        public void TestClockMintuesReset()
        {
            c = new Clock();
            for (int i = 0; i < (60*60); i++)
            {
                c.Tick();
            }

            Assert.AreEqual("01:00:00", c.Time, "The minutes reset");
        }

        [Test]
        public void TestClockHoursReset()
        {
            c = new Clock();
            for (int i = 0; i < (24*60*60); i++)
            {
                c.Tick();
            }

            Assert.AreEqual("00:00:00", c.Time, "The hours reset");
        }
               
    }

}
