// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//for Category
var closeEditModal = function () {
    $('#editCategoryModal').modal('hide');
}
var closeDeleteModal = function () {
    $('#deleteCategoryModel').modal('hide');
}
var closeAddModal = function () {
    $('#addCategoryModal').modal('hide');
}

var ConfirmDelete = function (Id) {

    $("#hiddenCategoryId").val(Id);
    $("#deleteCategoryModel").modal('show');

}

var DeleteCategory = function () {

    var Id = $("#hiddenCategoryId").val();

    $.ajax({

        type: "POST",
        url: "/Category/Delete",
        data: { id: Id },
        success: function (result) {
            $("#deleteCategoryModel").modal("hide");
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

//for Product
var closeDeleteProduct = function () {
    $('#deleteCategoryModel').modal('hide');
}

var confirmDeleteProduct = function (Id) {

    $("#hiddenProductId").val(Id);
    $("#deleteProductModel").modal('show');

}

var DeleteProduct = function () {

    var Id = $("#hiddenProductId").val();

    $.ajax({

        type: "POST",
        url: "/Product/Delete",
        data: { id: Id },
        success: function (result) {
            $("#deleteProductModel").modal("hide");
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
