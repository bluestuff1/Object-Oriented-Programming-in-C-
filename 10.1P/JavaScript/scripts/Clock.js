"use strict";

function Counter() {
  this.count = 0;

  this.next = function () {
    this.count++;
  };

  this.reset = function () {
    this.count = 0;
  };

  this.getCount = function () {
    return this.count;
  };
}

function Clock() {
  this.seconds = new Counter();
  this.minutes = new Counter();
  this.hours = new Counter();

  this.tick = function () {
    this.seconds.next();

    if (this.seconds.getCount() > 59) {
      this.seconds.reset();
      this.minutes.next();
    }

    if (this.minutes.getCount() > 59) {
      this.minutes.reset();
      this.hours.next();
    }

    if (this.hours.getCount() > 23) {
      this.hours.reset();
    }
  }

  this.printTime = function () {
    console.log(
      "The time is " +
      this.hours.getCount() +
      ":" +
      this.minutes.getCount() +
      ":" +
      this.seconds.getCount()
    );
  };
}

//This is for unit testing
module.exports = {
  Counter: Counter,
  Clock: Clock
}

var myClock = new Clock();
var i = 0;

while (i < 86400) {
  myClock.tick();
  i++;
  myClock.printTime();
}
