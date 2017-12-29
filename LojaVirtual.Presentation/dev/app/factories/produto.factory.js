(function() {
    'use strict';

    angular.module('LV').factory('produtoFactory', produtoFactory);

    produtoFactory.$inject = ['$rootScope', '$http','settings'];

    function produtoFactory($rootScope, $http, settings) {
        return {
            listar: listar,
            listarPorCategoria: listarPorCategoria,
            obterPorId: obterPorId,
            salvar: salvar,
            alterar: alterar,
            excluir: excluir
        };

        function listar() {
            return $http.get(settings.constServiceUrl + 'api/v1/produto/listar', $rootScope.header);
        }

        function listarPorCategoria(categoriaId) {
            return $http.get(settings.constServiceUrl + 'api/v1/produto/listar/categoria/' + categoriaId, $rootScope.header);
        }

        function obterPorId(produtoId) {
            return $http.get(settings.constServiceUrl + 'api/v1/produto/' + produtoId, $rootScope.header);
        }

        function salvar(produto) {
            return $http.post(settings.constServiceUrl + 'api/v1/produto', produto, $rootScope.header);
        }

        function alterar(produto) {
            return $http.put(settings.constServiceUrl + 'api/v1/produto', produto, $rootScope.header);
        }

        function excluir(produtoId) {
            return $http.delete(settings.constServiceUrl + 'api/v1/produto/' + produtoId, $rootScope.header);
        }
    }
})();