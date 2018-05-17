$(() => {
    init();
});


function init() {
    $(".chat_info").on("click", OnChatSelected);
    $("#input_message").keyup(PressTextEnter);
    $("#input_btn").on("click", OnChatButtonClick);
}

// --events--

function OnChatSelected(e) {
    $("#input_btn").css("pointer-events", "all");
    let chat_id = $(this).attr("id").split("_")[1];

    $.post("/Home/GetChatContent", {
        chatId: parseInt(chat_id)
    })
    .done(data => {
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

function AppendMessage(message) {

}

function FillChat(content) {

}

function PressTextEnter(event) {
    if (event.keyCode === 13) {
        $("#input_btn").click();
    }
}

