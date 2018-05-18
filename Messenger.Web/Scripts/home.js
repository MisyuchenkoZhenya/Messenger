$(() => {
    init();
});

var ChatConnection;

function init() {
    $(".chat_info").on("click", OnChatSelected);
    $("#input_message").keyup(OnPressTextEnter);
    $("#input_btn").on("click", OnChatButtonClick);  
}

// --events--

function OnChatSelected(e) {
    ChatConnection = $.connection.chatHub;
    InitializeChatHandlers(ChatConnection);

    $("#input_btn").css("pointer-events", "all");
    let chat_id = $(this).attr("id").split("_")[1];

    GetChatContent(chat_id);
}

function OnChatButtonClick(e) {
    let chat_text = $("#input_message").val();
    if (chat_text.search(/.+/) >= 0) {
        ChatConnection.server.Send(chat_text);
    }

    $("#input_message").val('');
}

function OnPressTextEnter(event) {
    if (event.keyCode === 13) {
        $("#input_btn").click();
    }
}

function InitializeChatHandlers(chat) {
    chat.client.AppendMessage = (message) => {
        alert(message);
    }
}

// --helpers--

function GetChatContent(chat_id) {
    $.post("/Home/GetChatContent", {
        chatId: parseInt(chat_id)
    })
    .done(data => {
        ConnectWithWebSocket();

        $(".chat_body").empty();
        data = JSON.parse(data);
    });
}

function ConnectWithWebSocket() {
    $.connection.hub.start()
        .done(() => {
            ChatConnection.server.send("Hi");
            alert("Connected");
    });
}

function FillChat(content) {

}
