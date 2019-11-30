
public class Main {

    public static void main(String[] args) throws InterruptedException {
        Clock myClock = new Clock();

        while (true) {
            myClock.PrintTime();
           
            myClock.Tick();
        }

    }
}
