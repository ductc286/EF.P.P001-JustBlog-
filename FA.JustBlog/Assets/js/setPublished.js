function setPublished(target) {
    event.preventDefault();
    var published = $(target).prop("checked");
    var id = $(target).attr("id").replace("Published", "");
    $.ajax({
        url: "/Admin/Posts/SetPublished",
        data: JSON.stringify({
            id: id,
            published: published
        }),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function () {
            $(target).prop("checked", published);
            alert('Update Published field Successful');
        },
        error: function (errormessage) {
            alert("error!\nTry checking the permissions!");
        }
    });
}