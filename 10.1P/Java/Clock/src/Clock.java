
public class Clock {

    private Counter _seconds;
    private Counter _minutes;
    private Counter _hours;

    public Clock() {
        _seconds = new Counter();
        _minutes = new Counter();
        _hours = new Counter();
    }

    public void Tick() {
        _seconds.Next();
        if (_seconds.getCount() > 59) {
            _seconds.Reset();
            _minutes.Next();
        }

        if (_minutes.getCount() > 59) {
            _minutes.Reset();
            _hours.Next();
        }

        if (_hours.getCount() > 23) {
            _hours.Reset();
        }
    }

    public void PrintTime() {
        System.out.println(String.format("%02d:%02d:%02d", _hours.getCount(),_minutes.getCount(), _seconds.getCount()));
    }

}
