function whileDemo() {
    var i = 1;
    while (i < 5) {
        console.log("Iteration " + i);
        i++;
    }
}

function doWhileDemo() {
    var days = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday"];
    var i = 0;
    do {
        var day = days[i++];
        console.log("It's "+day);
    } while(day!="Wednesday");
}

function forDemo() {
    for (var x = 1; x <= 3; x++) {
        for (var y = 1; y <= 3; y++) {
            console.log(x + " X " + y + " = " + (x * y));
        }
    }
}

function breakDeom() {
    var days = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday"];
    for (var idx in days) {
        if (days[idx] == "Wednesday")
            break;
        console.log("it's "+days[idx]);
    }
}

function continueDemo() {
    var days = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday"];
    for (var idx in days) {
        if (days[idx] == "Wednesday")
            continue;
        console.log("It's " + days[idx]);
    }
}

function formatGreeting(name, city) {
    var retStr = "";
    retStr += "Hello " + name + "\n";
    retStr += "Welcome to " + city + "!";
    return retStr;
}

function doCalc(num1,num2,calcFunction) { 
    return calcFunction(num1, num2);
}

function addFunc(n1, n2) { 
    return n1 + n2;
}

function scopeFuncDemo() {
    var myVar = 1;
    function writeIt() {
        var myVar = 2;
        console.log("Variable = " + myVar);
        writeMore();
    }

    function writeMore() { 
        console.log("Variable = " + myVar);
    }

    writeIt();
}

function objectCreationDemo() {
    var user = new Object();
    user.first = "Brad";
    user.last = "Dayley";
    user.getName = function () { return this.first + " " + this.last; };

    console.log(user.getName());

    var user = {
        first: 'Brad',
        last: 'Dayley',
        getName: function () { return this.first + " " + this.last; }
    }

    console.log(user.getName());

    function User(first, last) {
        this.first = first;
        this.last = last;
        this.getName = function () { return this.first + " " + this.last; };
    }

    var user = new User("Brad", "Dayley");
    console.log(user.getName());
}

function propertyDemo(){
    function UserP(first, last){
        this.first = first;
        this.last = last;
    }

    UserP.prototype = {
        getFullName: function () { 
            return this.first + " " + this.last;
        }
    }

    var user = new UserP("Brad", "Dayley");
    console.log(user.getFullName());
}

function stringDemo() {
    var myStr = "I think, therefor I am.";
    if (myStr.indexOf("think") != -1) {
        console.log(myStr);
    }

    var username = "Brad";
    var output = "<username> please enter your password: ";
    output = output.replace("<username>", username);
    console.log(output);

    var t = "12:10:36";
    var tArr = t.split(":");
    console.log(tArr[0], tArr[1], tArr[2]);
}

function arrayDemo(){
    var arr = ["one", "two", "three"];

    var arr2 = new Array();
    arr2[0] = "one";
    arr2[1] = "two";
    arr2[2] = "three";

    var arr3 = new Array();
    arr3.push("one");
    arr3.push("two");
    arr3.push("three");

    var numOfItems = arr.length;

    var arr4 = arr.concat(arr2);

    console.log(arr4.length);

    var week = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday"];
    for (var i = 0; i < week.length; i++) {
        console.log(week[i]);
    }

    for (dayIndex in week) {
        console.log(week[dayIndex]);
    }

    var timeArr = [12, 10, 36];
    var timeStr = timeArr.join(":");
    console.log(timeStr);
}

function testTryCatch(value){
    try {
        if (value < 0) {
            throw "too small";
        }
        else if (value > 10) {
            throw "too big";
        }

        console.log(value);
    } catch (err) {
        console.log("The number was " + err);
    } finally {
        console.log("This is always written.");
    }
}


function main() {
    //whileDemo();
    //doWhileDemo();
    //forDemo();
    //breakDeom();
    //continueDemo();
    //console.log(formatGreeting("Brad", "Rome"));
    //console.log(doCalc(5, 10, addFunc));
    //console.log(doCalc(5,10, function (n1,n2) { return n1 * n2; }))
    //scopeFuncDemo();
    //objectCreationDemo();
    //propertyDemo();
    //stringDemo();
    //arrayDemo();
    testTryCatch(100);
}


main();