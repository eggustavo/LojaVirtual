(function () {
    'use strict';

    angular.module('LV').controller('carrinhoCtrl', carrinhoController);

    carrinhoController.$inject = ['$rootScope', '$location', 'pedidoFactory', 'settings', 'message'];

    function carrinhoController($rootScope, $location, pedidoFactory, settings, message) {
        var vm = this;

        vm.itensCarrinho = [];
        vm.total = 0;
        vm.desconto = 0;
        vm.taxaEntrega = 0;

        vm.atualizarCarrinho = atualizarCarrinho;
        vm.obterTotal = obterTotal;
        vm.remover = remover;
        vm.login = login;
        vm.finalizarCompra = finalizarCompra;

        activate();

        function activate() {
            obterItensCarrinho();
            obterTotal();
        };

        function obterItensCarrinho() {
            angular.forEach($rootScope.carrinho, function (value, key) {
                vm.itensCarrinho.push({
                    id: value.id,                    
                    descricao: value.descricao,
                    imagem: value.imagem,
                    quantidade: value.quantidade,
                    preco: value.preco,
                    total: value.preco * value.quantidade
                });
            });
        };

        function atualizarCarrinho() {  
            $rootScope.carrinho = vm.itensCarrinho;
            localStorage.setItem(settings.constCarrinho, angular.toJson($rootScope.carrinho));
            obterTotal();
        };

        function obterTotal() {
            var total = 0;
            angular.forEach(vm.itensCarrinho, function (value, key) {                
                total += (value.preco * value.quantidade);
            });
            vm.total = (total + vm.taxaEntrega) - vm.desconto;
        }

        function remover(itemCarrinho) {
            var index = vm.itensCarrinho.indexOf(itemCarrinho);
            vm.itensCarrinho.splice(index,1);
            atualizarCarrinho();
        };

        function login() {
            $location.path('/login');
        };

        function finalizarCompra() {
            var pedido = {
                usuarioId: null,
                taxaEntrega: vm.taxaEntrega,
                desconto: vm.desconto,
                itens: []
            };

            angular.forEach(vm.itensCarrinho, function (value, key) {
                pedido.itens.push({
                    produtoId: value.id,
                    quantidade: value.quantidade
                })
            });

            pedidoFactory.salvar(pedido)
                .then(successCallback)
                .catch(errorCallback)

            function successCallback(response) {
                $rootScope.carrinho = null;
                localStorage.removeItem(settings.constCarrinho);
                toastr.success('Pedido realizado com Sucesso.', 'Loja Virtual');
                $location.path('/');
            };

            function errorCallback(response) {
                toastr.error('Ocorreu um erro ao salvar o pedido: ' + message.getMessage(response), 'Loja Virtual');
            };

            /*
            public decimal TaxaEntrega { get; set; }
            public decimal Desconto { get; set; }
            public IEnumerable<AdicionarItemRequest> Itens { get; set; }
            
            
            public Guid ProdutoId { get; set; }
            public int Quantidade { get; set; }
            */
         
        };
    };
})();