function getData($timeout, $q) {
    return function () {
        var defer = $q.defer();

        $timeout(function () {
            if (Math.round(Math.random())) {
                defer.resolve('data received!')
            } else {
                defer.reject('oh no an error! try again')
            }
        }, 2000);

        return defer.promise;
    }
}

angular.module('app', [])
    .factory('getData', getData)
    .run(function (getData) {
        var promise = getData()
            .then(function (str) {
                console.log(str);
            }, function (error) {
                console.error(error)
            }).finally(function () {
                console.log('Finished at:', new Date())
            });
    })