(function() {
    'use strict';

    angular.module('LV').factory('loginFactory', loginFactory);

    loginFactory.$inject = ['$rootScope', '$http', 'settings'];

    function loginFactory($rootScope, $http, settings) {
        return {
            login: login,
            alterarSenha: alterarSenha
        };

        function login(usuario) {
            var data = 'grant_type=password&username=' + usuario.usuarioLogin + '&password=' + usuario.senha;
            var url = settings.constServiceUrl + 'api/v1/usuario/token';
            var header = {
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded'
                }
            };

            return $http.post(url, data, header);
        }

        function alterarSenha(alterarSenhaRequest) {
            return $http.post(settings.constServiceUrl + 'api/usuario-alterar-senhha', alterarSenhaRequest, $rootScope.header);
        }
    }
})();