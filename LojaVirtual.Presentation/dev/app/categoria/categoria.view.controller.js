(function() {
    'use strict';

    angular.module('LV').controller('categoriaViewCtrl', categoriaViewController);

    categoriaViewController.$inject = ['$routeParams', 'categoriaFactory', 'message'];

    function categoriaViewController($routeParams, categoriaFactory, message) {
        var vm = this;

        vm.categoria = {
            id: null,
            descricao: ''
        };

        initialization();

        function initialization() {
            obterCategoria($routeParams.categoriaId);
        }

        function obterCategoria(categoriaId) {
            categoriaFactory.obterPorId(categoriaId)
                .then(successCallback)
                .catch(errorCallback);

            function successCallback(response) {
                vm.categoria = response.data.dataReturn;
            }

            function errorCallback(response) {
                toastr.error('Ocorreu um erro ao processar a requisição: ' + message.getMessage(response), 'Loja Virtual');
            }
        }    
    }
})();