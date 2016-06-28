function iterate(obj, stack) {
    for (var property in obj) {
        if (obj.hasOwnProperty(property)) {
            if (typeof obj[property] == "object") {
                iterate(obj[property], stack + property + ".");
            } else {
                console.log(stack + property + ":" + obj[property]);
                //$('#output').append($("<div/>").text(stack + '.' + property))
            }
        }
    }
}

var example = {
"prop1": "value1",
"prop2": ["value2_0", "value2_1"],
    "prop3": {
"prop3_1": "value3_1"
}
}

iterate(example, '')