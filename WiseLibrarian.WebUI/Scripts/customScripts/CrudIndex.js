

$(document).ready(function () {
    $("#tabs").tabs();
    loadMembers();
    loadAdmins();
    loadBooks();
})

$(".selector").tabs({
    heightStyle: "content"
});

var gender = {
    1: "Bay",
    2: "Bayan"
}

var genderToApi = {
    "Bay": "1",
    "Bayan": "2"
}

var material = {
    1: "Kitap",
    4: "E-Kitap"
}

var materialToApi = {
    "Kitap": "1",
    "E-Kitap": "4"
}

// member functions


function editModalLoader(btn) {
    var memberId = $(btn).attr("data-id");
    var editModalLoaderUrl = "/api/member/GetMember/" + memberId;


    $.ajax({
        method: 'GET',
        url: editModalLoaderUrl,
        dataType: 'json',
    }).done(function (response) {

        if (response == null)
            return;
        var member = response;
        $('#hiddenInputMemberId').val(member.MemberId);
        $('#memberFirstNameEdit').val(member.MemberFirstName);
        $('#memberLastNameEdit').val(member.MemberLastName);
        $('#memberUserNameEdit').val(member.MemberUserName);
        $('#memberEmailEdit').val(member.MemberEmail);
        $('#memberPasswordEdit').val(member.MemberPassword);
        $('#memberPhoneNumberEdit').val(member.MemberPhoneNumber);
        $('#genderEdit').val(gender[member.GenderId]);

    }).fail(function () {

        toastr["error"]("DÜZENLEME PENCERESİ AÇILAMADI.", "HATA !")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-bottom-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }


    });
}

function saveEditModal() {
    var modal = $("#editMemberModal");
    var editedData = {
        MemberId: $('#hiddenInputMemberId').val(),
        MemberFirstName: $('#memberFirstNameEdit').val(),
        MemberLastName: $('#memberLastNameEdit').val(),
        MemberUserName: $('#memberUserNameEdit').val(),
        MemberEmail: $('#memberEmailEdit').val(),
        MemberPassword: $('#memberPasswordEdit').val(),
        MemberPhoneNumber: $('#memberPhoneNumberEdit').val(),
        GenderId: genderToApi[$('#genderEdit').val()],
        MemberBirthDate: $('#memberBirthDateEdit').val()
    }
    console.log(editedData);
    $.ajax({
        method: 'POST',
        url: "/api/member/UpdateMember",
        data: editedData,
        dataType: 'json',

    }).done(function (response) {
        toastr["success"]("DEĞİŞİKLİKLER BAŞARIYLA KAYDEDİLDİ.", "KAYDEDİLDİ")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-bottom-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
        loadMembers();
    }).fail(function () {
        toastr["error"]("DEĞİŞİKLİKLER KAYDEDİLİRKEN HATA OLUŞTU.", "HATA !!")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-bottom-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }

    });

    modal.modal("hide");
}

function editModalStarter(btn) {

    editModalLoader(btn);
    $("#editMemberModal").modal('show');
    toastr["success"]("DÜZENLEME PENCERESİ BAŞARIYLA YÜKLENDİ.", "BAŞARILI")
    toastr.options = {
        "closeButton": true,
        "debug": true,
        "newestOnTop": true,
        "progressBar": true,
        "positionClass": "toast-bottom-center",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
} 

function loadMembers() {  
    var memberTableBody = $("#membersTable tbody")
    memberTableBody.empty();

    $.ajax({
        method: 'GET',
        url: "/api/member/GetMembers",
        dataType: 'json',
    }).done(function (response) {
        if (response == null)
            return;
        for (var i = 0; i < response.length; i++) {
            var member = response[i]
            $("#membersTable tbody").append(
                "<tr>" +
                "<td>" + member.MemberId + "</td>" +
                "<td>" + member.MemberFirstName + "</td>" +
                "<td>" + member.MemberLastName + "</td>" +
                "<td>" + member.MemberUserName + "</td>" +
                "<td>" + member.MemberEmail + "</td>" +
                "<td>" + member.MemberPassword + "</td>" +
                "<td>" + member.MemberPhoneNumber + "</td>" +
                "<td>" + gender[member.GenderId] + "</td>" +
                "<td>" + member.MemberBirthDate + "</td>" +
                "<td>" + "<button type='button' id='editMemberButton' data-id='"+member.MemberId+"' onclick='editModalStarter(this)' class='btn btn-info rounded btn-sm'>" +
                "<svg xmlns='http://www.w3.org/2000/svg' width='20' height='20' fill='currentColor' class='bi bi-pencil-square' viewBox='0 0 16 16'>" +
                "<path d='M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z' />" +
                "<path fill-rule='evenodd' d='M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z' />" +
                "</svg>" +
                "</button>" + "</td>" +
                "<td>" + "<button type='button'  id='deleteMemberButton' data-id='"+member.MemberId+"' onclick='deleteMember(this)' class='btn btn-danger'>" +
                "<svg xmlns='http://www.w3.org/2000/svg' width='20' height='20' fill='currentColor' class='bi bi-trash' viewBox='0 0 16 16'>" +
                "<path d='M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5Zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5Zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6Z'/>" +
                "<path d='M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1ZM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118ZM2.5 3h11V2h-11v1Z' />" +
                "</svg>" +
                "</button>" + "</td>" +
                "</tr>");
        }

        toastr["success"]("ÜYELER TABLOYA BAŞARIYLA YÜKLENDİ.", "BAŞARILI")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }  

    }).fail(function () {

        toastr["error"]("ÜYELER TABLOYA YÜKLENİRKEN HATA OLUŞTU.", "HATA !")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }

    });

}

function addMember() {
    var modal = $("#addMemberModal");
    var form = $("#formMember");
    var memberData = {
        MemberFirstName: $('#memberFirstName').val(),
        MemberLastName: $('#memberLastName').val(),
        MemberUserName: $('#memberUserName').val(),
        MemberEmail: $('#memberEmail').val(),
        MemberBirthDate: $('#memberBirthDate').val(),
        MemberPhoneNumber: $('#memberPhoneNumber').val(),
        MemberPassword: $('#memberPassword').val(),
        GenderId: genderToApi[$('#gender').val()]
    }
    if ($("#membersTable tbody").length == 0) {
        $("#membersTable").append("<tbody></tbody>")
    }
    form.validate({
        rules: {
            memberFirstName: {
                required: true,
                minlength: 3,
                maxlength: 20,
            },
            memberLastName: {
                required: true,
                minlength: 3,
                maxlength: 20,
            },
            memberUserName: {
                required: true,
                minlength: 3,
                maxlength: 20,
            },
            memberEmail: {
                required: true,
                email: true
            },
            memberPassword: {
                required: true,
                minlength: 8,
                maxlength: 16,
            },
            memberPasswordConfirm: {
                equalTo: "#memberPassword"
            },
            memberPhoneNumber: {
                required: true,
                number: true,
                minlength: 10,
                maxlength: 10,
            },
            gender: {
                required: true,
            },
            memberBirthDate: {
                required: true,
                date: true,
            },
        },
        messages: {
            memberFirstName: {
                required: "Lütfen İsminizi Giriniz.",
                minlength: "En az 3 karakter giriniz.",
                maxlength: "En fazla 20 karakter giriniz"
            },
            memberLastName: {
                required: "Lütfen Soyisminizi Giriniz.",
                minlength: "En az 3 karakter giriniz.",
                maxlength: "En fazla 20 karakter giriniz"
            },
            memberUserName: {
                required: "Lütfen Kullanıcı Adınızı Giriniz.",
                minlength: "En az 3 karakter giriniz.",
                maxlength: "En fazla 20 karakter giriniz"
            },
            memberEmail: {
                required: "Lütfen Emailinizi Giriniz.",
                email: "Lütfen Geçerli Bir Mail Adresi Giriniz."
            },
            memberPassword: {
                required: "Lütfen Şifre Belirleyiniz.",
                minlength: "En az 8 karakter giriniz.",
                maxlength: "En fazla 16 karakter giriniz"
            },
            memberPasswordConfirm: {
                equalTo: "Lütfen Aynı Şifreyi Giriniz !"
            },
            memberPhoneNumber: {
                required: "Lütfen Telefon Numaranızı Giriniz.",
                minlength: "Lütfen Numaranızı Başında 0 olmadan 10 haneli giriniz.",
                maxlength: "Lütfen Numaranızı Başında 0 olmadan 10 haneli giriniz."
            },
            gender: "Lütfen Cinsiyetinizi Seçiniz.",
            memberBirthDate: "Lütfen Doğum Tarihinizi Giriniz."
        },
    });
    var valid = form.valid();
    if (!valid) return;

    $.ajax({
        method: 'POST',
        url: '/api/Member/InsertMember',
        data: memberData,
        dataType: 'json'
    }).done(function (response) {
        loadMembers();
        toastr["success"]("ÜYE EKLEME İŞLEMİ BAŞARILI.", "EKLENDİ")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
    }).fail(function () {
        toastr["error"]("ÜYE EKLEME İŞLEMİNDE HATA OLUŞTU.", "HATA !")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
    });

    modal.modal("hide");
    form.trigger("reset");
}

function deleteMember(btn) {
    var memberDelId = $(btn).attr("data-id");
    
    console.log(memberDelId);
    $.ajax({
        method: 'POST',
        url: '/api/Member/DeleteMember',
        data: {MemberId:memberDelId},
        dataType: 'json'
    }).done(function (response) {

        loadMembers();

        toastr["succes"]("ÜYE BAŞARIYLA SİLİNDİ.", "HATA !")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-bottom-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }

    }).fail(function () {

        toastr["error"]("ÜYE SİLİNEMEDİ.", "HATA !")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-bottom-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
    });
    loadMembers();
}

function deleteAllMembers() {
    $.ajax({
        method: 'POST',
        url: '/api/Member/DeleteAllMembers',
        dataType: 'json'
    }).done(function (response) {
        toastr["success"]("BÜTÜN ÜYELER SİLİNDİ.", "BAŞARILI")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-bottom-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }

    }).fail(function () {
        toastr["error"]("ÜYELER SİLİNEMEDİ.", "HATA !")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-bottom-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }

    });
    loadMembers();
}


// member functions





// admin functions


function editAdminModalLoader(btn) {
    var adminId = $(btn).attr("data-id");
    var editAdminModalLoaderUrl = "/api/Admin/GetAdmin/" + adminId;


    $.ajax({
        method: 'GET',
        url: editAdminModalLoaderUrl,
        dataType: 'json',
    }).done(function (response) {

        if (response == null)
            return;
        var admin = response;
        $('#hiddenInputAdminId').val(admin.AdminId);
        $('#adminFirstNameEdit').val(admin.AdminFirstName);
        $('#adminLastNameEdit').val(admin.AdminLastName);
        $('#adminEmailEdit').val(admin.AdminMail);
        $('#adminPasswordEdit').val(admin.AdminPassword);
        $('#adminPhoneNumberEdit').val(admin.AdminPhoneNumber);
        $('#genderAdminEdit').val(gender[admin.GenderId]);
        $('#adminBirthDateEdit').val(admin.AdminBirthDate);

    }).fail(function () {

        toastr["error"]("DÜZENLEME PENCERESİ AÇILAMADI.", "HATA !")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-bottom-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }


    });
}

function saveEditAdminModal() {
    var modal = $("#editAdminModal");
    var editedData = {
        AdminId: $('#hiddenInputAdminId').val(),
        AdminFirstName: $('#adminFirstNameEdit').val(),
        AdminLastName: $('#adminLastNameEdit').val(),
        AdminMail: $('#adminEmailEdit').val(),
        AdminPassword: $('#adminPasswordEdit').val(),
        AdminPhoneNumber: $('#adminPhoneNumberEdit').val(),
        GenderId: genderToApi[$('#genderAdminEdit').val()],
        AdminBirthDate: $('#adminBirthDateEdit').val()
    }
    console.log(editedData);
    $.ajax({
        method: 'POST',
        url: "/api/Admin/UpdateAdmin",
        data: editedData,
        dataType: 'json',

    }).done(function (response) {
        toastr["success"]("DEĞİŞİKLİKLER BAŞARIYLA KAYDEDİLDİ.", "KAYDEDİLDİ")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-bottom-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
        loadAdmins();
    }).fail(function () {
        toastr["error"]("DEĞİŞİKLİKLER KAYDEDİLİRKEN HATA OLUŞTU.", "HATA !!")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-bottom-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }

    });

    modal.modal("hide");
}

function editAdminModalStarter(btn) {

    editAdminModalLoader(btn);
    $("#editAdminModal").modal('show');
    toastr["success"]("DÜZENLEME PENCERESİ BAŞARIYLA YÜKLENDİ.", "BAŞARILI")
    toastr.options = {
        "closeButton": true,
        "debug": true,
        "newestOnTop": true,
        "progressBar": true,
        "positionClass": "toast-bottom-center",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
}

function loadAdmins() {
    var adminTableBody = $("#adminsTable tbody")
    adminTableBody.empty();

    $.ajax({
        method: 'GET',
        url: "/api/Admin/GetAdmins",
        dataType: 'json',
    }).done(function (response) {
        if (response == null)
            return;
        for (var i = 0; i < response.length; i++) {
            var admin = response[i]
            $("#adminsTable tbody").append(
                "<tr>" +
                "<td>" + admin.AdminId + "</td>" +
                "<td>" + admin.AdminServiceNumber + "</td>" +
                "<td>" + admin.AdminFirstName + "</td>" +
                "<td>" + admin.AdminLastName + "</td>" +
                "<td>" + admin.AdminMail + "</td>" +
                "<td>" + admin.AdminPassword + "</td>" +
                "<td>" + admin.AdminPhoneNumber + "</td>" +
                "<td>" + gender[admin.GenderId] + "</td>" +
                "<td>" + admin.AdminBirthDate + "</td>" +
                "<td>" + "<button type='button' id='editAdminButton' data-id='" + admin.AdminId + "' onclick='editAdminModalStarter(this)' class='btn btn-info rounded btn-sm'>" +
                "<svg xmlns='http://www.w3.org/2000/svg' width='20' height='20' fill='currentColor' class='bi bi-pencil-square' viewBox='0 0 16 16'>" +
                "<path d='M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z' />" +
                "<path fill-rule='evenodd' d='M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z' />" +
                "</svg>" +
                "</button>" + "</td>" +
                "<td>" + "<button type='button'  id='deleteAdminButton' data-id='" + admin.AdminId + "' onclick='deleteAdmin(this)' class='btn btn-danger'>" +
                "<svg xmlns='http://www.w3.org/2000/svg' width='20' height='20' fill='currentColor' class='bi bi-trash' viewBox='0 0 16 16'>" +
                "<path d='M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5Zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5Zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6Z'/>" +
                "<path d='M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1ZM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118ZM2.5 3h11V2h-11v1Z' />" +
                "</svg>" +
                "</button>" + "</td>" +
                "</tr>");
        }

        toastr["success"]("ADMİNLER TABLOYA BAŞARIYLA YÜKLENDİ.", "BAŞARILI")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }

    }).fail(function () {

        toastr["error"]("ADMİNLER TABLOYA YÜKLENİRKEN HATA OLUŞTU.", "HATA !")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }

    });

}

function addAdmin() {
    var modal = $("#addAdminModal");
    var form = $("#formAdmin");
    var adminData = {
        AdminFirstName: $('#adminFirstName').val(),
        AdminLastName: $('#adminLastName').val(),
        AdminMail: $('#adminEmail').val(),
        AdminBirthDate: $('#adminBirthDate').val(),
        AdminPhoneNumber: $('#adminPhoneNumber').val(),
        AdminPassword: $('#adminPassword').val(),
        GenderId: genderToApi[$('#genderAdmin').val()]
    }
    if ($("#adminsTable tbody").length == 0) {
        $("#adminsTable").append("<tbody></tbody>")
    }
    form.validate({
        rules: {
            adminFirstName: {
                required: true,
                minlength: 3,
                maxlength: 20,
            },
            adminLastName: {
                required: true,
                minlength: 3,
                maxlength: 20,
            },
            adminEmail: {
                required: true,
                email: true
            },
            adminPassword: {
                required: true,
                minlength: 8,
                maxlength: 16,
            },
            adminPasswordConfirm: {
                equalTo: "#adminPassword"
            },
            adminPhoneNumber: {
                required: true,
                number: true,
                minlength: 10,
                maxlength: 10,
            },
            genderAdmin: {
                required: true,
            },
            adminBirthDate: {
                required: true,
                date: true,
            },
        },
        messages: {
            adminFirstName: {
                required: "Lütfen İsminizi Giriniz.",
                minlength: "En az 3 karakter giriniz.",
                maxlength: "En fazla 20 karakter giriniz"
            },
            adminLastName: {
                required: "Lütfen Soyisminizi Giriniz.",
                minlength: "En az 3 karakter giriniz.",
                maxlength: "En fazla 20 karakter giriniz"
            },
            adminEmail: {
                required: "Lütfen Emailinizi Giriniz.",
                email: "Lütfen Geçerli Bir Mail Adresi Giriniz."
            },
            adminPassword: {
                required: "Lütfen Şifre Belirleyiniz.",
                minlength: "En az 8 karakter giriniz.",
                maxlength: "En fazla 16 karakter giriniz"
            },
            adminPasswordConfirm: {
                equalTo: "Lütfen Aynı Şifreyi Giriniz !"
            },
            adminPhoneNumber: {
                required: "Lütfen Telefon Numaranızı Giriniz.",
                minlength: "Lütfen Numaranızı Başında 0 olmadan 10 haneli giriniz.",
                maxlength: "Lütfen Numaranızı Başında 0 olmadan 10 haneli giriniz."
            },
            genderAdmin: "Lütfen Cinsiyetinizi Seçiniz.",
            adminBirthDate: "Lütfen Doğum Tarihinizi Giriniz."
        },
    });
    var valid = form.valid();
    if (!valid) return;

    $.ajax({
        method: 'POST',
        url: '/api/Admin/InsertAdmin',
        data: adminData,
        dataType: 'json'
    }).done(function (response) {
        loadAdmins();
        toastr["success"]("ADMIN EKLEME İŞLEMİ BAŞARILI.", "EKLENDİ")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
    }).fail(function () {
        toastr["error"]("ADMIN EKLEME İŞLEMİNDE HATA OLUŞTU.", "HATA !")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
    });

    modal.modal("hide");
    form.trigger("reset");
}

function deleteAdmin(btn) {
    var adminDelId = $(btn).attr("data-id");

    $.ajax({
        method: 'POST',
        url: '/api/Admin/DeleteAdmin',
        data: { AdminId: adminDelId },
        dataType: 'json'
    }).done(function (response) {

        loadAdmins();

        toastr["succes"]("ADMIN BAŞARIYLA SİLİNDİ.", "HATA !")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-bottom-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }

    }).fail(function () {

        toastr["error"]("ADMIN SİLİNEMEDİ.", "HATA !")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-bottom-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
    });
    loadAdmins();
}

function deleteAllAdmins() {
    $.ajax({
        method: 'POST',
        url: '/api/Admin/DeleteAllAdmin',
        dataType: 'json'
    }).done(function (response) {
        toastr["success"]("BÜTÜN ADMINLER SİLİNDİ.", "BAŞARILI")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-bottom-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }

    }).fail(function () {
        toastr["error"]("ADMINLER SİLİNEMEDİ.", "HATA !")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-bottom-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }

    });
    loadAdmins();
}


// admin functions



// book functions


function editBookModalLoader(btn) {
    var bookId = $(btn).attr("data-id");
    var editBookModalLoaderUrl = "/api/Book/GetBook/" + bookId;


    $.ajax({
        method: 'GET',
        url: editBookModalLoaderUrl,
        dataType: 'json',
    }).done(function (response) {

        if (response == null)
            return;
        var book = response;
        $('#hiddenInputBookId').val(book.BookId);
        $('#bookNameEdit').val(book.BookName);
        $('#bookIsbnEdit').val(book.BookIsbn);
        $('#bookPageCountEdit').val(book.BookPageCount);
        $('#bookThumbnailUrlEdit').val(book.BookThumbnailUrl);
        $('bookMaterialEdit').val(material[book.MaterialTypeId]);
        $('#bookStatusEdit').val(book.BookStatus);
        $('#bookCategoryEdit').val(book.CategoryId);

    }).fail(function () {

        toastr["error"]("DÜZENLEME PENCERESİ AÇILAMADI.", "HATA !")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-bottom-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }


    });
}

function saveBookEditModal() {
    var modal = $("#editBookModal");
    var editedData = {
        BookId: $('#hiddenInputBookId').val(),
        BookName: $('#bookNameEdit').val(),
        BookIsbn: $('#bookIsbnEdit').val(),
        BookPageCount: $('#bookPageCountEdit').val(),
        MaterialTypeId: materialToApi[$('#bookMaterialEdit').val()],
        BookThumbnailUrl: $('#bookThumbnailUrlEdit').val(),
        BookStatus: $('#bookStatusEdit').val(),
        CategoryId: $('#bookCategoryEdit').val(),
    }
    $.ajax({
        method: 'POST',
        url: "/api/Book/UpdateBook",
        data: editedData,
        dataType: 'json',

    }).done(function (response) {
        toastr["success"]("DEĞİŞİKLİKLER BAŞARIYLA KAYDEDİLDİ.", "KAYDEDİLDİ")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-bottom-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
        loadBooks();
    }).fail(function () {
        toastr["error"]("DEĞİŞİKLİKLER KAYDEDİLİRKEN HATA OLUŞTU.", "HATA !!")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-bottom-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }

    });

    modal.modal("hide");
}

function editBookModalStarter(btn) {

    editBookModalLoader(btn);
    $("#editBookModal").modal('show');
    toastr["success"]("DÜZENLEME PENCERESİ BAŞARIYLA YÜKLENDİ.", "BAŞARILI")
    toastr.options = {
        "closeButton": true,
        "debug": true,
        "newestOnTop": true,
        "progressBar": true,
        "positionClass": "toast-bottom-center",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
}

function loadBooks() {
    var bookTableBody = $("#booksTable tbody")
    bookTableBody.empty();

    $.ajax({
        method: 'GET',
        url: "/api/Book/GetBooks",
        dataType: 'json',
    }).done(function (response) {
        if (response == null)
            return;
        for (var i = 0; i < response.length; i++) {
            var book = response[i]
            $("#booksTable tbody").append(
                "<tr>" +
                "<td>" + book.BookId + "</td>" +
                "<td>" + book.BookNumber + "</td>" +
                "<td>" + book.BookIsbn + "</td>" +
                "<td>" + book.BookName + "</td>" +
                "<td>" + book.BookPageCount + "</td>" +
                "<td>" + book.BookThumbnailUrl + "</td>" +
                "<td>" + book.BookStatus + "</td>" +
                "<td>" + material[book.MaterialTypeId] + "</td>" +
                "<td>" + book.CategoryId + "</td>" +
                "<td>" + "<button type='button' id='editBookButton' data-id='" + book.BookId + "' onclick='editBookModalStarter(this)' class='btn btn-info rounded btn-sm'>" +
                "<svg xmlns='http://www.w3.org/2000/svg' width='20' height='20' fill='currentColor' class='bi bi-pencil-square' viewBox='0 0 16 16'>" +
                "<path d='M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z' />" +
                "<path fill-rule='evenodd' d='M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z' />" +
                "</svg>" +
                "</button>" + "</td>" +
                "<td>" + "<button type='button'  id='deleteBookButton' data-id='" + book.BookId + "' onclick='deleteBook(this)' class='btn btn-danger'>" +
                "<svg xmlns='http://www.w3.org/2000/svg' width='20' height='20' fill='currentColor' class='bi bi-trash' viewBox='0 0 16 16'>" +
                "<path d='M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5Zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5Zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6Z'/>" +
                "<path d='M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1ZM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118ZM2.5 3h11V2h-11v1Z' />" +
                "</svg>" +
                "</button>" + "</td>" +
                "</tr>");
        }

        toastr["success"]("KİTAPLAR TABLOYA BAŞARIYLA YÜKLENDİ.", "BAŞARILI")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }

    }).fail(function () {

        toastr["error"]("KİTAPLAR TABLOYA YÜKLENİRKEN HATA OLUŞTU.", "HATA !")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }

    });

}

function addBook() {
    var modal = $("#addBookModal");
    var form = $("#formBook");
    var bookData = {
        BookNumber: $('#bookNumber').val(),
        BookName: $('#bookName').val(),
        BookIsbn: $('#bookIsbn').val(),
        BookPageCount: $('#bookPageCount').val(),
        BookThumbnailUrl: $('#bookThumbnailUrl').val(),
        BookStatus: $('#bookStatus').val(),
        MaterialTypeId: materialToApi[$('#bookMaterial').val()],
        CategoryId: $('#bookCategory').val(),
    }
    if ($("#booksTable tbody").length == 0) {
        $("#booksTable").append("<tbody></tbody>")
    }
    form.validate({
        rules: {
            bookName: {
                required: true,
            },
            bookStatus: {
                required: true,
            },
            bookThumbnailUrl: {
                required: true,
                url: true
            },
            bookPageCount: {
                required: true,
                number: true,
            },
            bookNumber: {
                required: true,
                number: true,
            },
            bookIsbn: {
                required: true,
                number: true,
            },
            bookMaterial: {
                required: true,
            },
            bookCategory: {
                required: true,
                number: true,
            },
        },
        messages: {
            bookName: {
                required: "Lütfen Kitap Adını Giriniz.",
            },
            bookStatus: {
                required: "Lütfen Kitabın Durumunu Giriniz.",
            },
            bookThumbnailUrl: {
                required: "Lütfen Thumbnail Url Giriniz.",
                url: "lütfen Geçerli Bir Url Giriniz.",
            },
            bookPageCount: {
                required: "Lütfen Sadece Sayfa Sayısını Giriniz.",
                number: "Lütfen Sadece Sayı Giriniz."
            },
            bookNumber: {
                required: "Lütfen Kitap Adetini Giriniz.",
                number: "Lütfen Sadece Sayı Giriniz.",
            },
            bookIsbn: {
                required: "Lütfen Kitap Isbn Giriniz.",
                number: "Lütfen Sadece Sayı Giriniz."
            },
            bookMaterial: {
                required: "Lütfen Kitap Isbn Giriniz.",
            },
            bookCategory: {
                required: "Lütfen Kitabın Kategorisini Giriniz",
                number: "Lütfen Sadece Sayı Giriniz."
            }
        },
    });
    var valid = form.valid();
    if (!valid) return;

    $.ajax({
        method: 'POST',
        url: '/api/Book/InsertBook',
        data: bookData,
        dataType: 'json'
    }).done(function (response) {
        loadBooks();
        toastr["success"]("KİTAP EKLEME İŞLEMİ BAŞARILI.", "EKLENDİ")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
    }).fail(function () {
        toastr["error"]("KİTAP EKLEME İŞLEMİNDE HATA OLUŞTU.", "HATA !")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
    });

    modal.modal("hide");
    form.trigger("reset");
}

function deleteBook(btn) {
    var bookDelId = $(btn).attr("data-id");

    $.ajax({
        method: 'POST',
        url: '/api/Book/DeleteBook',
        data: { BookId: bookDelId },
        dataType: 'json'
    }).done(function (response) {

        loadBooks();

        toastr["succes"]("KİTAP BAŞARIYLA SİLİNDİ.", "HATA !")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-bottom-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }

    }).fail(function () {

        toastr["error"]("KİTAP SİLİNEMEDİ.", "HATA !")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-bottom-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
    });
    loadBooks();
}

function deleteAllBooks() {
    $.ajax({
        method: 'POST',
        url: '/api/Book/DeleteAllBooks',
        dataType: 'json'
    }).done(function (response) {
        toastr["success"]("BÜTÜN KİTAPLAR SİLİNDİ.", "BAŞARILI")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-bottom-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }

    }).fail(function () {
        toastr["error"]("KİTAPLAR SİLİNEMEDİ.", "HATA !")
        toastr.options = {
            "closeButton": true,
            "debug": true,
            "newestOnTop": true,
            "progressBar": true,
            "positionClass": "toast-bottom-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }

    });
    loadBooks();
}



// book functions