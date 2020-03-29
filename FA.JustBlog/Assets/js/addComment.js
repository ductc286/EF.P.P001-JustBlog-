$(document).ready(function () {
    // Handler for .ready() called.
    $("form#form").validate({
        rules: {
            Name: {
                required: true,
            },
            Email: {
                required: true,
            },
            CommentHeader: {
                required: true,
            },
            CommentText: {
                required: true,
            }
        },

        submitHandler: function (form) {
            event.preventDefault();
            addComment();
        },
    });
    function addComment() {
        //var CaptchaInputText = $("#CaptchaInputText").val();
        //var comment = {
        var Name = $("#Name").val();
        var Email = $("#Email").val();
        var CommentHeader = $("#CommentHeader").val();
        var CommentText = $("#CommentText").val();
        var PostId = $("#PostId").val();
        var CaptchaDeText = $("CaptchaDeText").val();
        var CaptchaInputText = $("CaptchaInputText").val();
        //};
        var data = $("form").serialize();
        $.ajax({
            url: "/Comment/Create",
            //data: JSON.stringify(comment, { CaptchaInputText }),
            data: JSON.stringify({ Name: Name, Email: Email, CommentHeader: CommentHeader, CommentText: CommentText, PostId: PostId, CaptchaDeText: CaptchaDeText, CaptchaInputText: CaptchaInputText }),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                alert("Add successfuly")
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }

});