$(document).ready(function () {
    var customerDDL = '#CustomerType';

    $(customerDDL).on('change', function () {
        var customerType = $("#CustomerType").val();
        if (customerType == "0") {
            console.log("corporate");
            $("#corporateCustomerId").show();
            $("#homeOfficeCustomersId").hide();
        }
        else if (customerType == "1") {
            $("#corporateCustomerId").hide();
            $("#homeOfficeCustomersId").show();
        }
        else {
            $("#corporateCustomerId").hide();
            $("#homeOfficeCustomersId").hide();
        }
    });
});