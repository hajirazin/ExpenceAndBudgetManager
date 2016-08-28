angular.module("BudgetManager", []).controller("Reminder", function ($scope) {
    $scope.details = [];
    var desc = [];
    $scope.Save = function () {
        if (desc.indexOf($scope.Description) !== -1)
            return;
        desc.push($scope.Description);
        $scope.details.push({
            Amount: $scope.Amount,
            Description: $scope.Description
        });
        $scope.Amount = "";
        $scope.Description = "";
    };

    $scope.Remove = function(description) {
        var index = desc.indexOf(description);
        if (index !== -1) {
            desc.splice(index, 1);
            $scope.details.splice(index, 1);
        }
    };
});