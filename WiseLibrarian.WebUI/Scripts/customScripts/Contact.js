

function sendMessage() {

    var messageForm = $("#contactMessageForm");

    var contactMessage = {
        SenderName: $("#senderFirstName").val(),
        SenderLastName: $("#senderLastName").val(),
        SenderEmail: $("#senderEmail").val(),
        SenderPhoneNumber: $("#senderPhoneNumber").val(), 
        SenderMessage: $("#senderMessage").val()
    }

    messageForm.validate({

        rules: {
            senderFirstName: {
                required: true,
                minlength: 3,
                maxlength: 20
            },
            senderLastName: {
                required: true,
                minlength: 3,
                maxlength: 20
            },
            senderPhoneNumber: {
                required: true,
                number: true,
                minlength: 10,
                maxlength: 10
            },
            senderEmail: {
                required: true,
                email: true
            },
            senderMessage: {
                required: true,
                minlength: 10,
                maxlength: 200,
                lettersonly: true
            }
        },
        messages: {
            senderFirstName: {
                required: "Lütfen Adınızı Giriniz.",
                minlength: "Lütfen en az 3 harften oluşan bir ad giriniz.",
                maxlength: "Lütfen en fazla 20 harften oluşan bir ad giriniz."
            },
            senderLastName: {
                required: "Lütfen Soyadınızı Giriniz.",
                minlength: "Lütfen en az 3 harften oluşan bir soyad giriniz.",
                maxlength: "Lütfen en fazla 20 harften oluşan bir soyad giriniz."
            },
            senderPhoneNumber: {
                required: "Lütfen Telefon Numaranızı Giriniz.",
                minlength: "Lütfen Numaranızı Başında 0 olmadan 10 haneli giriniz.",
                maxlength: "Lütfen Numaranızı Başında 0 olmadan 10 haneli giriniz."
            },
            senderEmail: {
                required: "Lütfen Emailinizi Giriniz.",
                email: "Lütfen Geçerli Bir Mail Adresi Giriniz."
            },
            senderMessage: {
                required: "Lütfen talep veya isteğinizi giriniz.",
                minlength: "Lütfen en az 10 karakter giriniz!",
                maxlength: "Lütfen en fazla 200 karakter giriniz!!",
                lettersonly: "Lütfen sadece harf giriniz."
            }
        }
    });

    var valid = messageForm.valid();
    if (!valid) return;

    $.ajax({
        url: '/api/ContactMessage/InsertContactMessage',
        method: 'POST',
        data: contactMessage,
        dataType: 'json'
    }).done(function (response) {

        toastr["success"]("MESAJINIZ BAŞARIYLA GÖNDERİLDİ.", "GÖNDERİLDİ.")
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
        messageForm.trigger("reset");
        }).fail(function () {
            toastr["error"]("MESAJINIZ GÖNDERİLEMEDİ.", "GÖNDERİLEMEDİ!!!")
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



