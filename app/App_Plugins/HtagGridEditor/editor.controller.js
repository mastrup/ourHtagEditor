angular.module("umbraco").controller("htag.grideditorcontroller", function ($scope) {
    

    if (!$scope.control.textAlign)
    {
        $scope.control.textAlign = "left";
    }
    if (!$scope.control.hTag) {
        $scope.control.hTag = "h1";
    }

    $scope.setPosition = function (pos) {
        $scope.control.textAlign = pos;
    }

    $scope.setSize = function (hTag) {
        $scope.control.hTag = hTag;
    }

    
});