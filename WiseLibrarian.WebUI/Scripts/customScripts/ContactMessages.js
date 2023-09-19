
$(document).ready(function () {
    loadMessages();
})

function loadMessages() {
    $.ajax({
        method: 'GET',
        url: '/api/ContactMessages/GetContactMessages',
        dataType: 'json'
    }).done(function (response) {
        if (response == null) return;

    }).fail(function (error) {

    });
}