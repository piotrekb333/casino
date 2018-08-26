$(document).ready(function () {
    $("#btnNewsletter").click(function () {
        $("#newsletterModal").modal('show');
    })
    $("#saveToEmailBtn").click(function () {
        SaveToNewsletter();
    })
});

function SaveToNewsletter() {
    $("#newsletter-form").validate({
        ignore: [],
        rules: {
            Email: {
                required: true,
                email:true
            },
        },
        messages: {
        },
        highlight: function (element) {
            $(element).closest('.form-group').addClass('has-error');
        },
        unhighlight: function (element) {
            $(element).closest('.form-group').removeClass('has-error');
        },
        errorElement: 'span',
        errorClass: 'help-block'
    });
    if (!$("#newsletter-form").valid())
        return;
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
            swal("Good job!", "Done", "success");
        } else {
            swal("Error!", result.Message, "error");
        }
    }).fail(function () {
        swal("Error!", "Error occurred", "error");
    });
}