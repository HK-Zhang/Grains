function getData($timeout, $q) {
    return function () {
        // 模拟异步函数
        return $q(function (resolve, reject) {
            $timeout(function () {
                resolve(Math.floor(Math.random() * 10))
            }, 2000)
        })
    }
}

angular.module('app', [])
    .factory('getData', getData)
    .run(function (getData) {
        var promise = getData()
            .then(function (num) {
                console.log(num)
                return num * 2
            })
            .then(function (num) {
                console.log(num) // = random number * 2
            });
    })