"use strict";

var Character = function (name, health, weapon) {
    this.name = name;
    this.health = health;
    this.weapon = weapon;


}

Character.prototype.status = function () {
    return 'name:' + this.name + ', health: ' + this.health + ',  weapon: ' + this.weapon;
}

var char1 = new Character('Igris', '500', 'Black Sword');
var char2 = new Character('Iron', '1000', 'B.F Shield');
console.log(char1.status());
console.log(char2.status());






// var char2 = new Character('Iron', '1000', 'B.F Shield');


// this.status = function () {
//     return 'name:' + this.name + ', health: ' + this.health + ', weapon: ' + this.weapon;
// }