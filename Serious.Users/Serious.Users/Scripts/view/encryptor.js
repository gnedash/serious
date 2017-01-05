$(document).ready(function () {

    $("#btnSend").click(function () {
        $("#tbEncrypt").val("");
        $("#tbDecrypt").val("");
        var val = $("#tbInput").val();
        if (val == "") {
            alert("Input string can not be empty.");
            return;
        }
        encrypt(val);
    });

    function encrypt(text) {
        var url = $("#encryptUrl").val();
        send(url, text, function (encryptedText) {
            $("#tbEncrypt").val(encryptedText);
            //decrypt result
            decrypt(encryptedText);
        });
    }

    function decrypt(text) {
        var url = $("#decryptUrl").val();
        send(url, text, function (encryptedText) {
            $("#tbDecrypt").val(encryptedText);
        });
    }

    function send(url, text, callback)
    {
        var data = new FormData();
        data.append("text", text);
        $.ajax({
            type: "POST",
            url: url,
            contentType: false,
            processData: false,
            data: data,
            success: function (result) {
                callback(result.cryptedText)                
            }
        });     
    }
});