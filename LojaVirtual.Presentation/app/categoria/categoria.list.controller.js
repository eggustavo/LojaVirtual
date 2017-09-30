(function() {
    'use strict';

    angular.module('LV').controller('categoriaListCtrl', categoriaListController);

    categoriaListController.$inject = ['categoriaFactory'];

    function categoriaListController(categoriaFactory) {
        var vm = this;

        vm.colecaoCategoria = [];
        vm.excluir = excluir;

        initialization();

        function initialization() {
            listarCategorias();
        };

        function listarCategorias() {
            categoriaFactory.listar()
                .then(successCallback)
                .catch(errorCallback);

            function successCallback(response) {
                vm.colecaoCategoria = response.data;
            };

            function errorCallback(response) {
                toastr.error('Ocorreu um erro ao processar a requisição: ' + response.data, 'Loja Virtual');
            };
        };

        function excluir(categoria) {
            categoriaFactory.excluir(categoria)
                .then(successCallback)
                .catch(errorCallback);

            function successCallback(response) {
                var idx = vm.colecaoCategoria.indexOf(categoria);
                vm.colecaoCategoria.splice(idx, 1);
                toastr.info("Categoria: " + categoia.id + ' - ' + categoria.nome + ". \n Foi excluído com Sucesso.")
            };

            function errorCallback(response) {
                toastr.error('Ocorreu um erro ao processo a requisição: ' + response.data, 'Loja Virutal');
            };
        };
    };
})();