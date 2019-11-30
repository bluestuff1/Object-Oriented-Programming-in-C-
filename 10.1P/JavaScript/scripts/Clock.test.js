const { Counter, Clock } = require('./Clock');

var counterOne;
var myClock;

test('Counter is constructed', () => {
    counterOne = new Counter();
    expect(counterOne.getCount()).toBe(0);
});

test('Counter is incremented', () => {
    counterOne = new Counter();
    counterOne.next();
    expect(counterOne.getCount()).toBe(1);
});

test('Counter is resetted', () => {
    counterOne = new Counter();
    counterOne.next();
    counterOne.reset();
    expect(counterOne.getCount()).toBe(0);
});

test('Clock is constructed', () => {
    myClock = new Clock();
    expect(myClock.seconds.getCount()).toBe(0);
    expect(myClock.minutes.getCount()).toBe(0);
    expect(myClock.hours.getCount()).toBe(0);
});

test('Clock ticks', () => {
    myClock = new Clock();
    myClock.tick();
    expect(myClock.seconds.getCount()).toBe(1);
    expect(myClock.minutes.getCount()).toBe(0);
    expect(myClock.hours.getCount()).toBe(0);
});

test('Clock seconds reset', () => {
    myClock = new Clock;
    for (i = 0; i < 60; i++) {
        myClock.tick()
    }
    expect(myClock.seconds.getCount()).toBe(0);
    expect(myClock.minutes.getCount()).toBe(1);
    expect(myClock.hours.getCount()).toBe(0);
});

test('Clock minutes reset', () => {
    myClock = new Clock;
    for (i = 0; i < 60; i++) {
        for (j = 0; j < 60; j++) {
            myClock.tick()
        }
    }
    expect(myClock.seconds.getCount()).toBe(0);
    expect(myClock.minutes.getCount()).toBe(0);
    expect(myClock.hours.getCount()).toBe(1);
});

test('Clock hours reset', () => {
    myClock = new Clock;
    for (i = 0; i < 24; i++) {
        for (j = 0; j < 60; j++) {
            for (k = 0; k < 60; k++) {
                myClock.tick()
            }
        }
    }
    expect(myClock.seconds.getCount()).toBe(0);
    expect(myClock.minutes.getCount()).toBe(0);
    expect(myClock.hours.getCount()).toBe(0);
});

