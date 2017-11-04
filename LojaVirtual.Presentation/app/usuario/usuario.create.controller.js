(function(){
    'use strict';

    angular.module('LV').controller('usuarioCreateCtrl', usuarioCreateController);

    usuarioCreateController.$inject = ['$location', 'usuarioFactory'];

    function usuarioCreateController($location, usuarioFactory) {
        var vm = this;

        vm.usuario = {
            nome: '',
            usuarioLogin: '',
            senha: '',
            confirmarSenha: '',
            email: ''
        };

        vm.criar = criar;

        function criar() {
            usuarioFactory.criar(vm.usuario)
                .then(successCallback)
                .catch(errorCallback);

            function successCallback(response) {
                $location.path('/login');
                toastr.success(message.getMessage(response), 'Loja Virtual');
            };

            function errorCallback(response) {
                toastr.error('Ocorreu um erro ao processar a requisição: ' + message.getMessage(response), 'Loja Virtual');
            };
        };
    };
})();