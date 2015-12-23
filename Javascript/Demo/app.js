console.log("Hello World");
function F() { this.toLocaleString = ""; }
var f = new F();
console.log(f.__proto__ == F.prototype);
console.log(f.prototype);
console.log(F.__proto__);
console.log(f.__proto__);
console.log(F.prototype);
console.log(F.prototype.prototype);
console.log(typeof F.prototype);

console.log("----basic object");
console.log(Object.prototype);
console.log(Object.__proto__);
console.log(typeof Object.prototype);
console.log(Function.prototype);
console.log(Function.__proto__);
console.log(Function.constructor);
console.log(typeof Function.prototype);
console.log(Array.prototype);
console.log(typeof Array.prototype);

console.log("----Demo");

function Bar() {
    return 0;
}

Bar.prototype = {
    foo: function () { }
};

var bar1 = new Bar();
var bar2 = Bar();

console.log(typeof bar1); //object

//返回的是Bar对象，所以其有foo属性，会从Bar.prototype继承属性
console.log(bar1.__proto__); //Object {foo: function}

console.log(typeof bar2); //number
console.log(bar2.__proto__); //Number {}
