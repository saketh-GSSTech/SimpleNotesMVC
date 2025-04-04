$(document).ready(function () {
    $("#save").click(function () {
        var title = $("#title").val();
        var description = $("#description").val();

        if (title.trim() === "" || description.trim() === "") {
            alert("Title and Description cannot be empty!");
            return;
        }

        $.ajax({
            url: "/Home/SaveNote",
            type: "POST",
            data: { title: title, description: description },
            xhrFields: { withCredentials: true },
            success: function (response) {
                if (response.success) {
                    alert("Note saved successfully!");
                    $("#title").val("");
                    $("#description").val("");
                }
            }
        });
    });

    $("#create").click(function () {
        $("#title").val("");
        $("#description").val("");
    });
});