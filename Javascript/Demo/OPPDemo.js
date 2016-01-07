console.log("Hello World");

function Bird() {
    var bird = (arguments.length == 1?arguments[0]:this);
    bird.wing = 2;
    bird.tweet = function () { };
    bird.fly = function () { 
        console.log('I can fly.');
    }
    return bird;
}

var obj = new Object();
var bird = Bird(obj);
bird.fly();
obj.fly();

function doFly(bird) {
    if (bird instanceof Bird) {
        bird.fly();
    }
    else { 
        throw new Error('Not a bird ');
    }
}

doFly(new Bird());
//doFly(bird);

function Ostrich() { 
this.fly = function () { console.log('I can not fly.');}
}

Ostrich.prototype = new Bird();
Ostrich.prototype.constructor = Ostrich;

var ostrich = new Ostrich();
doFly(ostrich);
