angular.module("umbraco").controller("Our.Umbraco.HtagEditor.Controller", function ($scope) {

    var config = {};

    if(!$scope.control) {
        // property editor usage
        $scope.control = $scope.model
        config = $scope.model.config;
    }
    else {
        // grid usage
        config = $scope.control.editor.config;
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
        var defaultAlign = config.options.align.default;
        var defaultSize = config.options.size.default;

        $scope.control.value = {
            textAlign: defaultAlign ? defaultAlign : "left",
            hTag: defaultSize ? defaultSize : "h1",
            text: ''
        }
    }

    $scope.sizeOptions = config.options && config.options.size && config.options.size.options ? config.options.size.options : "h1,h2,h3,h4,h5,h6".split(",");
    $scope.alignOptions = config.options && config.options.align && config.options.align.options ? config.options.align.options : "left,center,right".split(",");

    $scope.setPosition = function (pos) {
        $scope.control.value.textAlign = pos;
    };

    $scope.setSize = function (hTag) {
        $scope.control.value.hTag = hTag;
    };

});