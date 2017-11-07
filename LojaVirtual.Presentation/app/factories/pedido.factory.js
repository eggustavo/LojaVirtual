(function() {
    'use strict';

    angular.module('LV').factory('pedidoFactory', pedidoFactory);

    pedidoFactory.$inject = ['$rootScope', '$http','settings'];

    function pedidoFactory($rootScope, $http, settings) {
        return {
            listar: listar,
            obter: obter,
            salvar: salvar
        };

        function listar() {
            return $http.get(settings.constServiceUrl + 'api/v1/pedido/listar', $rootScope.header);
        };

        function obter(pedidoId) {
            return $http.get(settings.constServiceUrl + 'api/v1/pedido/obter/' + pedidoId, $rootScope.header);
        };

        function salvar(pedido) {
            return $http.post(settings.constServiceUrl + 'api/v1/pedido', pedido, $rootScope.header);
        };
    };
})();