$(() => {
    init();
});

var ChatConnection;
var ChatId;
var CurrentUserId;

function init() {
    CurrentUserId = window.userId;

    $(".chat_info").on("click", OnChatSelected);
    $("#input_message").keyup(OnPressTextEnter);
    $("#input_btn").on("click", OnChatButtonClick);
}

// --events--

function OnChatSelected(e) {//TODO: clear this shit
    ChatConnection = $.connection.chatHub;
    InitializeChatHandlers(ChatConnection);

    $(".chat_input").css("pointer-events", "all");    

    $(this).addClass("active");
    $(`#chat_${ChatId}`).removeClass("active");

    if (ChatId)
        ChatConnection.server.disconnect(ChatId);

    let chat_id = $(this).attr("id").split("_")[1];
    ChatId = chat_id;

    GetChatContent(chat_id);
}

function OnChatButtonClick(e) {
    let chat_text = $("#input_message").val();
    if (chat_text.search(/.+/) >= 0) {
        ChatConnection.server.send({
            message: chat_text,
            message_type: "Text",
            authorId: CurrentUserId
        }, ChatId);
    }

    $("#input_message").val('');
}

function OnPressTextEnter(event) {
    if (event.keyCode === 13) {
        $("#input_btn").click();
    }
}

function InitializeChatHandlers(chat) {
    chat.client.addChatMessage = function (content) {
        Print(content);
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
        ChatConnection.server.connect(ChatId);
    });
}

function Print(content) {
    if (content.message_type === "Text") {
        PrintText(content.message);
    } else if (content.message_type === "Image") {
        PrintImage(content.message);
    } else if (content.message_type === "Info") {
        PrintInfo(content.message);
    }
}

function PrintText(message) {
    $(".chat_body").append(`
        <div class="chat_message">
            <p>${message}</p>
        </div>
    `);
}

function PrintImage(message) {

}

function PrintInfo(message) {
    $(".chat_body").append(`
        <div class="chat_message">
            <p>${message}</p>
        </div>
    `);
}
