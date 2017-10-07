(function() {
    'use strict';

    angular.module('LV').factory('categoriaFactory', categoriaFactory);

    categoriaFactory.$inject = ['$http','settings'];

    function categoriaFactory($http, settings) {
        return {
            listar: listar,
            obterPorId: obterPorId,
            salvar: salvar,
            alterar: alterar,
            excluir: excluir
        };

        function listar() {
            return $http.get(settings.constServiceUrl + 'api/v1/categoria/listar');
        };

        function obterPorId(categoriaId) {
            return $http.get(settings.constServiceUrl + 'api/v1/categoria/' + categoriaId);
        };

        function salvar(categoria) {
            return $http.post(settings.constServiceUrl + 'api/v1/categoria', categoria);
        };

        function alterar(categoria) {
            return $http.put(settings.constServiceUrl + 'api/v1/categoria', categoria);
        };

        function excluir(categoria) {
            return $http.delete(settings.constServiceUrl + 'api/v1/categoria/' + categoria.id);
        };
    };
})();