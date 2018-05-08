$(() => {
    init();
});


function init() {
    $.ajaxSetup({ cache: false });
    $(".modalItem").click(OnModalItemCalled);
}


function OnModalItemCalled(e) {
    e.preventDefault();
    $.get("/Manage/Details", function (data) {
        $('#dialogContent').html(data);
        $('#modDialog').modal('show');

        $(".findContact").click(function (e) {
            $.get("/Manage/GetUsersByEmail", { email: $("#email_input").val() })
                .done((data) => {
                    $(".modal-body").html(UsersFromJson(data));

                    $(".possibleContact").click(AddNewContact);
                });
        });

        $(".findContact").click();
        $("#email_input").keyup(OnPressInputEnter);
    });
}

function AddNewContact(e) {
    if (confirm('Are you sure?')) {
        $.post("/Manage/AddContact", { contactId: $(this).attr("id") })
            .done((data) => {
                if (data === "true")
                    window.location.reload();
                else
                    alert("Something wrong");
            });
    }
}

//TODO: delete later
function LoadUserContacts() {
    $.get("/Manage/GetUserContacts", function (data) {
        let output = "";
        let input = JSON.parse(data);
        input.forEach(e => {
            output += `
            <div id="${e.Id}">
                <p>${e.FirstName} ${e.LastName}</p>
                <h5>${e.Email}</h5>
            </div>`;
        });
        $("#userContacts").html(output);
    });
}

function UsersFromJson(jsonString) {    
    let output = "";
    let input = JSON.parse(jsonString);
    input.forEach(e => {
        output += `
        <div id="${e.Id}" class="possibleContact btn">
            <p>${e.FirstName} ${e.LastName}</p>
            <h5>${e.Email}</h5>
        </div>`;
    });

    return output.length !== 0 ? output : "<p>User is no found</p>";
}

function OnPressInputEnter(event) {
    if (event.keyCode === 13) {
        $(".findContact").click();
    }
}


