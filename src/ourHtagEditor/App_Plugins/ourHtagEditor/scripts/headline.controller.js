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

    function setValue(align, size, text) {
        $scope.control.value = {
            "textAlign": align ? align : config.options.align.default,
            "hTag": size ? size : config.options.size.default,
            "text": text
        };
    }

    if ($scope.control.value !== null) {
        //Handles conversion between editors created in version 1.0.1 to newer
        if (!angular.isObject($scope.control.value)) {
            var oldText = $scope.control.value;
            var oldTag = $scope.control.hTag;
            var oldAlign = $scope.control.textAlign;

            setValue(oldAlign, oldTag, oldText);
        }
    } else {
        setValue();
    }

    $scope.sizeOptions = config.options && config.options.size && config.options.size.options ? config.options.size.options : "h1,h2,h3,h4,h5,h6".split(",");
    $scope.alignOptions = config.options && config.options.align && config.options.align.options ? config.options.align.options : "left,center,right".split(",");

    //If only one alignment is allowed, set the current alignemt to match the default if they don't already match.
    if ($scope.alignOptions.length === 1 && $scope.control.value.textAlign !== config.options.align.default) {
        $scope.control.value.textAlign = config.options.align.default;
    }

    $scope.setPosition = function (pos) {
        $scope.control.value.textAlign = pos;
    };

    $scope.setSize = function (hTag) {
        $scope.control.value.hTag = hTag;
    };

});