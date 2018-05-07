$(() => {
    
})

function UsersFromJson(jsonString) {    
    let output = "";
    let input = JSON.parse(jsonString);
    input.forEach(e => {
        output += `
        <div id="${e.Id}" class="foundUsers_info btn">
            <p>${e.FirstName} ${e.LastName}</p>
            <h5>${e.Email}</h5>
        </div>`
    });

    return output;
}
