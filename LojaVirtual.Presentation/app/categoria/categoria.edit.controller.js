(function() {
    'use strict';

    angular.module('LV').controller('categoriaEditCtrl', categoriaEditController);

    categoriaEditController.$inject = ['$routeParams', '$location', 'categoriaFactory', 'message'];

    function categoriaEditController($routeParams, $location, categoriaFactory, message) {
        var vm = this;

        vm.categoria = {
            id: null,
            descricao: ''
        };

        vm.alterar = alterar;

        initialization();

        function initialization() {
            ObterCategoria($routeParams.categoriaId);
        };

        function ObterCategoria(categoriaId) {
            categoriaFactory.obterPorId(categoriaId)
                .then(successCallback)
                .catch(errorCallback);

            function successCallback(response) {
                vm.categoria = response.data.dataReturn;
            };

            function errorCallback(response) {
                toastr.error('Ocorreu um erro ao processar a requisição: ' + message.getMessage(response), 'Loja Virtual');
            };
        };

        function alterar() {
            categoriaFactory.alterar(vm.categoria)
                .then(successCallback)
                .catch(errorCallback);

            function successCallback(response) {
                $location.path('/categoria/list');
                toastr.success(message.getMessage(response));
            };

            function errorCallback(response) {
                toastr.error('Ocorreu um erro ao processar a requisição: ' + message.getMessage(response), 'Loja Virtual');
            };
        };        
    };
})();