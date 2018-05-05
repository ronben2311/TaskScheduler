(function () {
app.controller("myCtrl", function ($scope, AjaxCallsFact, $location, sharedData) {
    $scope.userLogInInfo = sharedData.get();

    var ApiFailure = function (err) {
        console.log("err : ", err);
    };

    CallGetAllCustomers();
    $scope.customerList = null;
    $scope.projectList = null;
    $scope.projectListAddModal = null;
    $scope.taskList = null;
    $scope.taskListAddModal = null;
    $scope.currentPage = 1;

    $scope.pageNum = 0;
    $scope.taskInput = '';
    $scope.chosenColumn = 'name';
    $scope.orderBy = ' ascending';
    $scope.orderByObj =
    {
        columnName: "taskName",
        orderBy: " ascending",
    };

    $scope.showLoadingData = true;
    $scope.taskSearchObj = {
        projectId: '',
        pageSize: 5,
        pageNumber: $scope.pageNum,
        taskPartialName: $scope.taskInput,
        chosenColumn: $scope.orderByObj.columnName,
        orderBy: " ascending"
    }

    $scope.retWorkSheetList = null;
    
    function CallGetAllCustomers() {
        AjaxCallsFact.GetAllCustomers().then(
               function (res) {
                   if (res.data) {
                       $scope.customerList = res.data;
                   }
                   console.log("CallGetAllCustomers res : ", res.data);
               }, ApiFailure);
    };


    $scope.GetCustomersProjects = function (iCustomer, iSentFromAdd) {

        AjaxCallsFact.GetCustomersProjects(iCustomer.id).then(
            function (res) {
                console.log("GetCustomersProjects res: ", res.data);

                if (iSentFromAdd == true) {
                    $scope.projectListAddModal = res.data;
                    $scope.objToAdd.project = $scope.projectListAddModal[0];
                }
                else {
                    $scope.projectList = res.data;
                }

            }, ApiFailure);
    }

    $scope.GetTasksByProject = function (iProject, iSentFromAdd) {
        AjaxCallsFact.GetTasksByProjectId(iProject.id).then(
            function (res) {

                if (iSentFromAdd == true) {
                    $scope.taskListAddModal = res.data;
                    $scope.objToAdd.task = $scope.taskListAddModal[0];
                }
                else {
                    $scope.taskList = res.data;
                }
            }, ApiFailure);
    }

    $scope.WorkSheetByProjectId = function (iProjectId, iPageNum ,iColumn) {
        console.log("iProjectId: ", iProjectId);
        var taskSearchObj = {
            employeeId: $scope.userLogInInfo.userId,
            projectId: iProjectId,
            pageSize: 5,
            pageNumber: iPageNum,
            taskPartialName: $scope.taskInput,
            chosenColumn: iColumn,
            orderBy: " ascending"
        }

        AjaxCallsFact.WorkSheetByProjectId(taskSearchObj).then(
            function (res) {
                $scope.workSheetList = res.data.retWorkSheetList;
                $scope.totalCount = res.data.totalCount;
            }, ApiFailure);
    };

    $scope.OpenEditModal = function (iWorkSheet) {

        $scope.objToEdit = {
            sheetId: iWorkSheet.id,
            customerName: iWorkSheet.customerName,
            projectName: iWorkSheet.projectName,
            date: null,
            newStartHour: null,
            newEndHour: null,
            newComment: null,
            taskId: iWorkSheet.taskId,
        };

        $scope.objToEdit.date = new Date(iWorkSheet.dateYear, iWorkSheet.dateMonth, iWorkSheet.dateDay);

        var x = iWorkSheet.startHour.substring(0, 2);
        var y = iWorkSheet.startHour.substring(3, 5);
        $scope.objToEdit.newStartHour = new Date(iWorkSheet.dateYear, iWorkSheet.dateMonth, iWorkSheet.dateDay, x, y, 0)

        x = iWorkSheet.endHour.substring(0, 2);
        y = iWorkSheet.endHour.substring(3, 5);
        $scope.objToEdit.newEndHour = new Date(iWorkSheet.dateYear, iWorkSheet.dateMonth, iWorkSheet.dateDay, x, y, 0)

        $scope.objToEdit.newComment = iWorkSheet.comment;

        AjaxCallsFact.GetTasksByProjectId(iWorkSheet.projectId).then(
            function (res) {
                $scope.taskList = res.data;

                $("#myModal").modal();
            }, ApiFailure);
    };

    $scope.OpenNewwSheetModal = function () {
        //setting properties for readability.
        $scope.objToAdd = {
            customer: null,
            project: null,
            task: null,
            date: null,
            startHour: null,
            endHour: null,
            comment: null
        }
        $scope.objToAdd.customer = null;
        $scope.objToAdd.date = new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate());
        $scope.objToAdd.startHour = new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate(), '09', '00', 0);
        $scope.objToAdd.endHour = new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate(), '17', '00', 0);

        $('#newSheetModal').modal();
    }

    $scope.CalcHourDiff = function (iStartHour, iEndHour) {
        if (iStartHour && iEndHour) {
            var d1 = moment(iStartHour, "YYYY-MM-DD HH:mm");
            var d2 = moment(iEndHour, "YYYY-MM-DD HH:mm");
            var hoursStr = parseInt(d2.diff(d1, 'minutes') / 60);
            var minutesStr = d2.diff(d1, 'minutes') % 60;
            hoursStr = Math.abs(hoursStr);
            minutesStr = Math.abs(minutesStr);

            if (hoursStr < 9)
                hoursStr = "0" + hoursStr;
            if (minutesStr < 9)
                minutesStr = "0" + minutesStr;

            return (hoursStr + ":" + minutesStr);

        }
    }

    $scope.SaveSheet = function (iSheet) {
        var sheetToUpdate = _.find($scope.workSheetList, function (obj) { return obj.id == iSheet.sheetId; });
        AjaxCallsFact.SaveSheet(iSheet).then(
           function (res) {
               $scope.WorkSheetByProjectId(sheetToUpdate.projectId, 0, "taskName");

               $("#myModal").modal('hide');
           }, ApiFailure);
    };

    $scope.AddWorkSheet = function (iSheetObj) {
        var onjToSend = {
            employeeId: $scope.userLogInInfo.userId,
            taskId: iSheetObj.task.id,
            date: iSheetObj.date,
            newStartHour: iSheetObj.startHour,
            newEndHour: iSheetObj.endHour,
            newComment: iSheetObj.comment
        }
        AjaxCallsFact.AddWorkSheet(onjToSend).then(
    function (res) {
        $("#newSheetModal").modal('hide');

    }, ApiFailure);
    };

    $scope.DeleteSheet = function (iSheetId) {
        console.log("iSheetId :", iSheetId);
        AjaxCallsFact.DeleteSheet(iSheetId).then(
            function (res) {
                $scope.workSheetList = _.reject($scope.workSheetList, function (obj) { return obj.id == iSheetId });
                $scope.taskList = res.data;
                
                $("#myModal").modal('hide');
            }, ApiFailure);
    };
});
}());
