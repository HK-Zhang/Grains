require.config({
    paths:{
        jquery:'jquery-3.0.0.min'
    }
});

require(['jquery'], function ($) {
    li = [11, 22, 33];
    $.each(li, function (k, v) {
        console.log(this);
        console.log(k, v);
        if (k == 1) {
            return false;
        }
    })

    function myEach(obj, func) {
        for (var i = 0; i < obj.length; i++) {
            var current = obj[i];
            var ret = func(i, current);
            if (ret == false) {
                break;
            }
        }
    }

    var li = [10, 20, 30];
    myEach(li, function (k, v) {
        console.log(k, v);
        return false;
    })
})