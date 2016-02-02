myApp.controller("personController", function ($scope) {
    $scope.person = [];
    $scope.person.name = 'Kavlez'
    $scope.person.job = 'brogrammer'
    $scope.person.sayHi = function () {
        return "Hi! I'm " + $scope.person.name + ", I'm a(an) " + $scope.person.job;
    }
});

myApp.controller("fighterController", function ($scope) {
    $scope.fighters = [
         { name: 'Ryu', country: 'Japan' },
         { name: 'Ken', country: 'USA' },
         { name: 'Chun Li', country: 'China' },
         { name: 'GuiLe', country: 'USA' },
         { name: 'Zangief', country: 'Russia' }
    ];
});
