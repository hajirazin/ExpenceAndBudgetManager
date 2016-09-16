angular.module("DW", ["ngMaterial"]).controller("DWC", function ($scope, $http) {
    $scope.details = [];
    $scope.TodayTotal = 0;
    $scope.ThisMonthTotal = 0;
    $scope.getData = function () {
        $http({
            method: "GET",
            url: "http://budgetforaksha.azurewebsites.net/api/Expense/" + $scope.SelectedDate
        }).success(function (data) {
            if (typeof data == "string")
                alert(data);
            else {
                $scope.details = data.Data;
                $scope.TodayTotal = data.TodayTotal;
                $scope.ThisMonthTotal = data.ThisMonthTotal;
            }
        }).error(function () {
            alert("Kik error aay, application me");
        });
    };
    $scope.getData();
});