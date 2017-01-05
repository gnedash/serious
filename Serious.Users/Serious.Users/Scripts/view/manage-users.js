$(document).ready(function () {
    
        var userHub = $.connection.userHub;

        userHub.client.onLoggOutUser = function (email) {
            var logoutUrl = $("#LogOutUrl").val();
            $.ajax({
                type: "POST",
                url: logoutUrl,
                contentType: false,
                processData: false,
                data: null,
                success: function (result) {
                    window.location.reload();
                }
            });
            
        }

        $.connection.hub.start().done(function () {
            $('.email').click(function () {
                var username = $(this).attr("email");
                userHub.server.logOff(username);
            });
    });
});