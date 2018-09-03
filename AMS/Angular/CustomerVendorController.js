App.controller("CustomerCtrl", function ($scope, $http) {

    $scope.list = [];
    $scope.CustomerData = [];

    $scope.AllowSubmit = false;
    $scope.CustomerObj = { Customer_Id: 0, Customer_Name: "", Customer_MobileNo: "", Customer_Address: "", Customer_NTN: "", Customer_Company: "" };

    function JsonCall(Controller, Action) {
        $.ajax({
            type: "POST",
            traditional: true,
            async: false,
            cache: false,
            url: '/' + Controller + '/' + Action,
            context: document.body,
            success: function (json) {
                list = null; list = json;
            },
            error: function (xhr) {
                list = null;
                //debugger;
            }
        });
    }
    function JsonCallParam(Controller, Action, Parameters) {
        $.ajax({
            type: "POST",
            traditional: true,
            async: false,
            cache: false,
            url: '/' + Controller + '/' + Action,
            context: document.body,
            data: Parameters,
            success: function (json) {
                list = null; list = json;
            }
       ,
            error: function (xhr) {
                //debugger;
                list = null;
            }
        });
    }
    function WebApiCall(Type, Action, Parameters) {

        $.ajax({
            type: Type,
            traditional: true,
            async: false,
            cache: false,
            url: '/api/' + Action,
            context: document.body,
            data: Parameters,
            ContentType: 'application/json;utf-8',
            success: function (json) {
                list = json;
            }
       ,
            error: function (xhr) {
                //debugger;
            }
        });
    }

    $scope.SaveCustomer = function () {
        var pram = { "CustomerObj": JSON.stringify($scope.CustomerObj) };

        if ($scope.CustomerObj.Customer_Id == 0) {
            JsonCallParam("Account", "Register2", { "UserRole": JSON.stringify("Customer"), "CustomerObj": JSON.stringify($scope.CustomerObj) })
            if (list != null)
                JsonCallParam("Customers", "CreateCustomer", pram)
        }
        else {
            JsonCallParam("Customers", "UpdateCustomer", pram)
        }

        $scope.GetCustomer();
        $scope.Clear();
    };

    $scope.GetCustomer = function () {
        JsonCall("Customers", "GetCustomer");
        $scope.CustomerData = list;
    }
    $scope.GetCustomer();

    $scope.Clear = function () {
        $scope.CustomerObj = { Customer_Id: 0, Customer_Name: "", Customer_MobileNo: "", Customer_Address: "", Customer_NTN: "", Customer_Company: "" };
    }

    $scope.ValidateCustomer = function () {
        if ($scope.CustomerObj.Customer_Name == ""
            || $scope.CustomerObj.Customer_MobileNo == ""
            || $scope.CustomerObj.Customer_Address == ""
            || $scope.CustomerObj.Customer_NTN == ""
            || $scope.CustomerObj.Customer_Company == "") {
            $scope.AllowSubmit = false;
        }
        else {
            $scope.AllowSubmit = true;
        }
    }

    $scope.LoadCustomer = function (obj) {
        $scope.CustomerObj = obj;
        $scope.ValidateCustomer();
    }

    $scope.DeleteCustomer = function (obj) {
        if (confirm('Are you sure you want to delete customer?')) {
            JsonCallParam("Customers", "DeleteCustomer", { "id": obj.Customer_Id })
            $scope.GetCustomer();
        } else {
            // Do nothing!
        }
    }
});