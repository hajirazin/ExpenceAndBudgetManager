angular.module("DR", ["ngMaterial"]).controller("DRC", function ($scope, $http) {
    $scope.details = [];
    $scope.getData = function () {
        $http({
            method: "GET",
            url: "http://budgetforaksha.azurewebsites.net/api/Expense/Dailly"
        }).success(function (data) {
            debugger;
            if (typeof data == "string")
                alert(data);
            else {
                $scope.details = data;
            }
        }).error(function () {
            alert("Kik error aay, application me");
        });
    };
    $scope.getData();
});