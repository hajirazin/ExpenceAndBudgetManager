angular.module("BudgetManager", ["ngMaterial"]).controller("Reminder", function ($scope, $http) {
    $scope.details = [];
    $scope.desc = [];
    $scope.TodayTotal = 0;
    $scope.ThisMonthTotal = 0;
    $scope.Save = function () {
        if (!$scope.Amount || !$scope.Description) {
            alert("Amount ane description boy wij.");
            return;
        }
        if ($scope.desc.indexOf($scope.Description) !== -1) {
            alert($scope.Description + " Ghadi ghadi add naa thiye. Pehle thiwiyo aay.");
            return;
        }

        $http({
            method: "POST",
            url: "http://budgetforaksha.azurewebsites.net/api/Expense/Add?amount=" + $scope.Amount + "&description=" + $scope.Description
        }).success(function (data) {
            if (typeof data == "string")
                alert(data);
            else {
                $scope.details.push(data);
                $scope.desc.push(data.Description);
                $scope.TodayTotal += data.Amount;
                $scope.ThisMonthTotal += data.Amount;
                $scope.Amount = "";
                $scope.Description = "";
                $("#Description").focus();
            }
        }).error(function () {
            alert("Kik error aay, application me");
        });
    };

    $scope.Remove = function (obj) {
        var r = confirm("Sure to delete ?");
        if (r === true) {
            var index = $scope.desc.indexOf(obj.Description);
            if (index === -1) {
                return;
            }

            var amount = obj.Amount;
            $http({
                method: "DELETE",
                url: "http://budgetforaksha.azurewebsites.net/api/Expense/Delete?expenceId=" + obj.Id
            }).success(function (data) {
                if (typeof data == "string" && data)
                    alert(data);
                else {
                    $scope.desc.splice(index, 1);
                    $scope.details.splice(index, 1);
                    $scope.TodayTotal -= amount;
                    $scope.ThisMonthTotal -= amount;
                }
            }).error(function () {
                alert("Kik error aay, application me");
            });
        }
    };
    $scope.getData = function () {
        $http({
            method: "GET",
            url: "http://budgetforaksha.azurewebsites.net/api/Expense/"
        }).success(function (data) {
            if (typeof data == "string")
                alert(data);
            else {
                $scope.details = data.Data;
                $scope.TodayTotal = data.TodayTotal;
                $scope.ThisMonthTotal = data.ThisMonthTotal;
                $scope.desc = data.Data.map(function (v) {
                    return v.Description;
                });
            }
        }).error(function () {
            alert("Kik error aay, application me");
        });
    };

    $("body").on("keydown", "#Description", function (e) {
        if (e.keyCode === 13) {
            $("#Amount").focus();
            return false;
        }

        return true;
    });

    $("body").on("keydown", "#Amount", function (e) {
        if (e.keyCode === 13 || e.keyCode === 9) {
            e.preventDefault();
            $("#Save").click();
            return false;
        }

        return true;
    });
    $scope.getData();
});