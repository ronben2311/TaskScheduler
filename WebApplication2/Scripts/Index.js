var app = {};

(function () {
    app = angular.module('myApp', ['AjaxCallsModule', 'ngRoute']);

    app.factory('sharedData', function () {
        var userLogInInfo = {
            userName: null,
            userId: null
        };

        function set(data) {
            userLogInInfo = data;
        }
        function get() {
            return userLogInInfo;
        }
        return {
            set: set,
            get: get
        }
    });

    app.config(function ($routeProvider) {
        $routeProvider.when('/', {
            templateUrl: 'userValidation.html',
            controller: 'userValidCtrl'
        })
        .when('/resultSection.html', {
            templateUrl: 'resultSection.html',
            controller: 'myCtrl'
        })
    });

}());