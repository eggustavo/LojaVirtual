(function() {
    'use strict';

    angular.module('LV').factory('categoriaFactory', categoriaFactory);

    categoriaFactory.$inject = ['$rootScope', '$http','settings'];

    function categoriaFactory($rootScope, $http, settings) {
        return {
            listar: listar,
            obterPorId: obterPorId,
            salvar: salvar,
            alterar: alterar,
            excluir: excluir
        };

        function listar() {
            return $http.get(settings.constServiceUrl + 'api/v1/categoria/listar', $rootScope.header);
        };

        function obterPorId(categoriaId) {
            return $http.get(settings.constServiceUrl + 'api/v1/categoria/' + categoriaId, $rootScope.header);
        };

        function salvar(categoria) {
            return $http.post(settings.constServiceUrl + 'api/v1/categoria', categoria, $rootScope.header);
        };

        function alterar(categoria) {
            return $http.put(settings.constServiceUrl + 'api/v1/categoria', categoria, $rootScope.header);
        };

        function excluir(categoria) {
            return $http.delete(settings.constServiceUrl + 'api/v1/categoria/' + categoria.id, $rootScope.header);
        };
    };
})();