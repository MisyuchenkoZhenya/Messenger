$(() => {
    init();
});

var commonChatConnection;
var specificChatConnection;

function init() {
    //commonChatConnection = $.connection("/chat");

    $(".chat_info").on("click", OnChatSelected);
    $("#input_message").keyup(PressTextEnter);
    $("#input_btn").on("click", OnChatButtonClick);  

    //ConnectWithWebSocket();
}

// --events--

function OnChatSelected(e) {
    $("#input_btn").css("pointer-events", "all");
    let chat_id = $(this).attr("id").split("_")[1];

    $.post("/Home/GetChatContent", {
        chatId: parseInt(chat_id)
    })
    .done(data => {
        specificChatConnection = $.connection("/chat"); // ???
        ConnectWithWebSocket();

        $(".chat_body").empty();
        data = JSON.parse(data);

    });
}

function OnChatButtonClick(e) {
    let chat_text = $("#input_message").val();
    if (chat_text.search(/.+/) >= 0) {

    }

    $("#input_message").val('');
}

// --helpers--

function ConnectWithWebSocket() {
    specificChatConnection.start()
        .done((data) => {
            alert(data);
        });
}

function AppendMessage(message) {

}

function FillChat(content) {

}

function PressTextEnter(event) {
    if (event.keyCode === 13) {
        $("#input_btn").click();
    }
}




//$(function () {

//    $('#chatBody').hide();

//    var myConnection = $.connection("/chat");

//    myConnection.received((data) => {
//        $("#chatroom ul").append("<li><strong>" + htmlEncode(data.Name) +
//            '</strong>: ' + htmlEncode(data.Message) + "</li>");
//    });

//    // обработка логина
//    $("#btnLogin").click(function () {

//        var userName = $("#txtUserName").val().replace(/\s/g, '');
//        if (userName.length > 0) {
//            $('#username').val(userName);
            
//            $('#btnLogin').attr('disabled', 'disabled');
//            $('#txtUserName').attr('disabled', 'disabled');

//            $('#chatBody').show();

//            myConnection.start().done(function () {

//                $('#sendmessage').click(function () {

//                    myConnection.send(JSON.stringify({ name: $('#username').val(), message: $('#message').val() }));
//                    $('#message').val('');
//                });
//            });
//        }
//        else {
//            alert("Введите имя");
//        }
//    });
//});
//// Кодирование тегов
//function htmlEncode(value) {
//    var encodedValue = $('<div />').text(value).html();
//    return encodedValue;
//}
