function personController($scope) {
    $scope.person = [];
    $scope.person.name = 'Kavlez'
    $scope.person.job = 'brogrammer'
    $scope.person.sayHi = function () {
        return "Hi! I'm " + $scope.person.name + ", I'm a(an) " + $scope.person.job;
    }
}
