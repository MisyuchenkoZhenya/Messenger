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
    $("#input_btn_send").on("click", OnChatButtonClick);
    $("#input_btn_img").on("click", OnImageButtonClick);
    $("#upload_file").on("change", OnFileUpload);
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

function OnImageButtonClick(e) {
    $("#upload_file").click();
}

function OnFileUpload(e) {
    var file = e.target.files[0];
    var data = new FormData();
    data.append("file", file);

    $.ajax({
        type: "POST",
        url: '/Home/UploadFile',
        contentType: false,
        processData: false,
        data: data,
        success: (result) => {
            ChatConnection.server.send({
                Content: result,
                Type: "Image",
                authorId: CurrentUserId
            }, ChatId);
        }
    });
}

function OnPressTextEnter(event) {
    if (event.keyCode === 13) {
        $("#input_btn_send").click();
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
    $(".chat_body").scrollTop($(".chat_body").get(0).scrollHeight);
}

function PrintText(message) {
    $(".chat_body").append(`
        <div class="speech-bubble${message.AuthorId === CurrentUserId ? "-my" : ""}">
            <div class="message_sender">
                ${message.Author}
            </div>
            <div class="message_content">
                ${message.Content}
            </div>
            <div class="message_date">
                ${message.CreatedAt}
            </div>
        </div>
    `);
}

function PrintImage(message) {
    $(".chat_body").append(`
        <div class="speech-bubble${message.AuthorId === CurrentUserId ? "-my" : ""}">
            <div class="message_sender">
                ${message.Author}
            </div>
            <div class="message_content">
                <a href="/data/images/${message.Content}" target="_blank">
                    <img class="message_img" src="/data/images/${message.Content}">
                </a>
            </div>
            <div class="message_date">
                ${message.CreatedAt}
            </div>
        </div>
    `);
}

function PrintInfo(message) {
    $(".chat_body").append(`
        <div class="chat_message">
            <p>${message.Content}</p>
        </div>
    `);
}
