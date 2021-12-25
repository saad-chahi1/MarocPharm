// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$("#submit").click(function () {
		var id = $("#id").val();
		var str = "You Have Entered "
			+ "Id: " + id;
	$("#deleteEmployeeModal").html(str);
});

var ConfirmDelete = function (Id) {

    $("#hiddenCategoryId").val(Id);
    $("#myModal").modal('show');

}

var DeleteCategory = function () {

    var Id = $("#hiddenCategoryId").val();

    $.ajax({

        type: "POST",
        url: "/Category/Delete",
        data: { id: Id },
        success: function (result) {
            $("#myModal").modal("hide");
            $("#row_" + Id).remove();
        }
    });
}

var ConfirmEdit = function (Id, Name) {

    $("#hiddenCategoryId").val(Id);
    $("#editCategoryModal").modal('show');
    $("#categoryName").val(Name);
}

var EditCategory = function () {

    var Id = $("#hiddenCategoryId").val();
    var Name = $("#categoryName").val();
    $.ajax({
        type: "POST",
        url: "/Category/Edit",
        data: { id: Id, name: Name },
        success: function (result) {
            $("#editCategoryModal").modal("hide");
            document.location.reload(true);
        }
    });
}
