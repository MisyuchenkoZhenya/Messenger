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
            Content: chat_text,
            Type: "Text",
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
    chat.client.addChatMessage = function (message) {
        Print(message);
    }
}

// --helpers--

function GetChatContent(chat_id) {
    $.post("/Home/GetChatContent", {
        chatId: parseInt(chat_id)
    })
        .done(data => {
        $(".chat_body").empty();
        ConnectWithWebSocket(JSON.parse(data));
    });
}

function ConnectWithWebSocket(data) {
    $.connection.hub.start()
    .done(() => {
        ChatConnection.server.connect(ChatId);
        data.forEach((elem) => {
            Print(elem);
        });
    });
}

function Print(message) {
    if (message.Type === "Text") {
        PrintText(message);
    } else if (message.Type === "Image") {
        PrintImage(message);
    } else if (message.Type === "Info") {
        PrintInfo(message);
    }
}

function PrintText(message) {
    $(".chat_body").append(`
        <div class="chat_message">
            <p>${message.Content}</p>
        </div>
    `);
}

function PrintImage(message) {

}

function PrintInfo(message) {
    $(".chat_body").append(`
        <div class="chat_message">
            <p>${message.Content}</p>
        </div>
    `);
}
