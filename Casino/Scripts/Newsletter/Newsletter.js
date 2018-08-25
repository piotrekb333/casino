$(document).ready(function () {
    $("#btnNewsletter").click(function () {
        $("#newsletterModal").modal('show');
    })
    $("#saveToEmailBtn").click(function () {
        SaveToNewsletter();
    })
});

function SaveToNewsletter() {
    $.ajax({
        type: 'POST',
        url: '/Umbraco/Api/Newsletter/SaveToNewsletter',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({
            Email: $("#Email").val()
        }),
    }).done(function (result) {
        if (result.Success) {
            $("#Email").val('');
            $("#newsletterModal").modal('hide');
            swal("Good job!", "You have been saved correctly ", "success");
        } else {
            swal("Error!", "Error occurred", "error");
        }
    }).fail(function () {
        swal("Error!", "Error occurred", "error");
    });
}