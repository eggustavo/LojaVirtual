(function() {
    'use strict';

    angular.module('LV').factory('usuarioFactory', usuarioFactory);

    usuarioFactory.$inject = ['$rootScope', '$http','settings'];

    function usuarioFactory($rootScope, $http, settings) {
        return {
            criar: criar,
            trocarSenha: trocarSenha
        };

        function criar(usuario) {
            return $http.post(settings.constServiceUrl + 'api/v1/usuario', usuario);
        }

        function trocarSenha(usuario) {
            return $http.put(settings.constServiceUrl + 'api/v1/usuario/alterar-senha', usuario, $rootScope.header);
        }
    }
})();