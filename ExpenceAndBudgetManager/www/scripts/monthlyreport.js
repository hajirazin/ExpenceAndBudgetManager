angular.module("MR", ["ngMaterial"]).controller("MRC", function ($scope, $http) {
    $scope.details = [];
    $scope.getData = function () {
        $http({
            method: "GET",
            url: "http://budgetforaksha.azurewebsites.net/api/Expense/Monthly"
        }).success(function (data) {
            if (typeof data == "string")
                alert(data);
            else {
                $scope.details = data;
            }
        }).error(function () {
            alert("Kik error aay, application me");
        });
    };
    $scope.getMonth = function (month) {
        switch (month) {
            case 1:
                return "January";
            case 2:
                return "February";
            case 3:
                return "March";
            case 4:
                return "April";
            case 5:
                return "May";
            case 6:
                return "June";
            case 7:
                return "July";
            case 8:
                return "August";
            case 9:
                return "September";
            case 10:
                return "October";
            case 11:
                return "November";
            case 12:
                return "December";
            default:
                return "Un known";
        }
    };
    $scope.getData();
});