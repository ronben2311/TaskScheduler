(function () {
    angular.module('AjaxCallsModule', []).factory('AjaxCallsFact', ['$http', function ($http) {

        var AjaxCallsObj = {};

        AjaxCallsObj.ValidateUser = function (iObjToSend) {
            return $http.post('/api/Employee/ValidateUser', iObjToSend);
        };

        AjaxCallsObj.GetAllCustomers = function () {
            return $http.get('/api/Customer/GetAllCustomers');
        };

        AjaxCallsObj.GetCustomersProjects = function (iObjToSend) {
            return $http.get('/api/Project/GetCustomersProjects', { params: { ciCustomerId: iObjToSend } });
        };

        AjaxCallsObj.WorkSheetByProjectId = function (iObjToSend) {
            return $http.post('/api/WorkSheet/WorkSheetByProjectId', iObjToSend);
        };

        AjaxCallsObj.GetTasksByProjectId = function (iObjToSend) {
            return $http.get('/api/Task/GetTasksByProjectId', { params: { ciProjectId: iObjToSend } });
        };

        AjaxCallsObj.SaveSheet = function (iObjToSend) {
            return $http.post('/api/WorkSheet/SaveSheet', iObjToSend );
        };

        AjaxCallsObj.AddWorkSheet = function (iObjToSend) {
            return $http.post('/api/WorkSheet/AddWorkSheet', iObjToSend);
        };
        
        AjaxCallsObj.DeleteSheet = function (iObjToSend) {
            return $http.get('/api/WorkSheet/DeleteSheet', { params: { ciSheetId: iObjToSend } });
        };

        return AjaxCallsObj;
    }]);
})();