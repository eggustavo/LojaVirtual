(function() {
    'use strict';

    angular.module('LV').service('message', message);

    message.$inject = [];

    function message() {
        this.getMessage = function(objeto) {
            if (objeto.data == null)
                return '<br/> Erro não Catalogado ou Provedor de Dados não está acessível.';

            if (objeto.data.success) {
                return objeto.data.dataReturn.message;
            } else {
                var msg = '<br/> <br/> ';
                objeto.data.notifications.forEach(function(erro) {
                    msg += erro.property + ': ' + erro.message + '<br/>';
                });

                return msg;               
            };
        };
    };
})();