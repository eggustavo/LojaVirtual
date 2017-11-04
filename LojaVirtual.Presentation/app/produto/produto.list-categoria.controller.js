(function() {
    'use strict';

    angular.module('LV').controller('produtoListCategoriaCtrl', produtoListCategoriaCtrl);

    produtoListCategoriaCtrl.$inject = ['$routeParams', 'produtoFactory', 'message'];

    function produtoListCategoriaCtrl($routeParams, produtoFactory, message) {
        var vm = this;

        vm.colecaoProduto = [];

        initialization();

        function initialization() {
            listarProdutosPorCategoria($routeParams.categoriaId);
        };

        function listarProdutosPorCategoria(categoriaId) {
            produtoFactory.listarPorCategoria(categoriaId)
                .then(successCallback)
                .catch(errorCallback);

            function successCallback(response) {
                vm.colecaoProduto = response.data.dataReturn;
            };

            function errorCallback(response) {
                toastr.error('Ocorreu um erro ao processar a requisição: ' + message.getMessage(response), 'Loja Virtual');
            };
        };

        function adicionarAoCarrinho(produto) {
            $rootScope.cart.push(product);
            localStorage.setItem(SETTINGS.CART_ITEMS, angular.toJson($rootScope.cart));
            toastr.success('O item <strong>' + product.title + '</strong> foi adicionado ao seu carrinho', 'Produto Adicionado');
        }        
    };
})();