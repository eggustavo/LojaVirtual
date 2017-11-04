(function() {
    'use strict';

    angular.module('LV').factory('usuarioFactory', usuarioFactory);

    usuarioFactory.$inject = ['$http','settings'];

    function usuarioFactory($http, settings) {
        return {
            criar: criar
        };

        function criar(usuario) {
            return $http.post(settings.constServiceUrl + 'api/v1/usuario', usuario);
        };
    };
})();