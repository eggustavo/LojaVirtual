(function() {
    'use strict';

    angular.module('LV').factory('usuarioFactory', usuarioFactory);

    usuarioFactory.$inject = ['$rootScope', '$http','settings'];

    function usuarioFactory($rootScope, $http, settings) {
        return {
            criar: criar
        };

        function criar(usuario) {
            return $http.post(settings.constServiceUrl + 'api/v1/usuario', usuario);
        };
    };
})();