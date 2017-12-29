(function() {
    'use strict';

    angular.module('LV').controller('produtoListCtrl', produtoListController);

    produtoListController.$inject = ['produtoFactory', 'message'];

    function produtoListController(produtoFactory, message) {
        var vm = this;

        vm.colecaoProduto = [];
        vm.excluir = excluir;

        initialization();

        function initialization() {
            listarProdutos();
        }

        function listarProdutos() {
            produtoFactory.listar()
                .then(successCallback)
                .catch(errorCallback);

            function successCallback(response) {
                vm.colecaoProduto = response.data.dataReturn;
            }

            function errorCallback(response) {
                toastr.error('Ocorreu um erro ao processar a requisição: ' + message.getMessage(response), 'Loja Virtual');
            }
        }

        function excluir(produto) {
            produtoFactory.excluir(produto.id)
                .then(successCallback)
                .catch(errorCallback);

            function successCallback(response) {
                var idx = vm.colecaoProduto.indexOf(produto);
                vm.colecaoProduto.splice(idx, 1);
                toastr.info(message.getMessage(response));
            }

            function errorCallback(response) {
                toastr.error('Ocorreu um erro ao processo a requisição: ' + message.getMessage(response), 'Loja Virutal');
            }
        }
    }
})();