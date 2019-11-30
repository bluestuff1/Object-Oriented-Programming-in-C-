
public class Counter {

    private int _count;

    public Counter() {
        _count = 0;
    }

    public void Next() {
        _count++;
    }

    public void Reset() {
        _count = 0;
    }

    public int getCount() {
        return _count;
    }
}
