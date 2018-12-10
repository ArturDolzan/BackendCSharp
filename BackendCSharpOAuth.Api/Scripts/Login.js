﻿(function () {

    var me = this;

    me.autenticar = function(usuario, senha){

        $.ajax({
            type: 'POST',
            url: Url.config.backEnd + '/Token',
            data: {
                'username': usuario,
                'password': senha,
                'grant_type': 'password'
            },
            success: function (resp) {
                Cookies.set("AppToken", resp.access_token, { expires: 1 });
                Cookies.set("AppUser", usuario, { expires: 1 });

                onSubmitForm();
            },
            error: function(resp) {
               $('#errmsg').html(resp.responseJSON.error_description);
            },
            dataType: 'json',
            async: false
        });

    };

    return true;

})();