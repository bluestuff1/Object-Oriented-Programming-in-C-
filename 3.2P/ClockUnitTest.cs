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
