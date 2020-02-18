angular.module("umbraco").controller("Our.Umbraco.HtagEditor.Controller", function ($scope) {

    if(!$scope.control) {
        // property editor usage, spoof grid control
        $scope.control = $scope.model

        if ($scope.model.value === null || $scope.model.value === "") {

            // set initial defaults
            $scope.model.value = {
                textAlign: 'left',
                    hTag: 'h1',
                    text: ''
            }
        }
    }

    if ($scope.control.value !== null) {
        //Handles conversion between editors created in version 1.0.1 to newer
        if (!angular.isObject($scope.control.value)) {
            var oldText = $scope.control.value;
            var oldTag = $scope.control.hTag;
            var oldAlign = $scope.control.textAlign;

            $scope.control.value = {
                "textAlign": oldAlign,
                "hTag": oldTag,
                "text": oldText
            };
        }
    } else {
        $scope.control.value = {
            "textAlign": "left",
            "hTag": "h1"
        };
    }

    $scope.setPosition = function (pos) {
        $scope.control.value.textAlign = pos;
    };

    $scope.setSize = function (hTag) {
        $scope.control.value.hTag = hTag;
    };

});