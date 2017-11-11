(function() {
    'use strict';

    angular.module('LV').controller('trocarSenhaCtrl', trocarSenhaController);

    trocarSenhaController.$inject = ['$rootScope', '$location', 'usuarioFactory', 'message'];

    function trocarSenhaController($rootScope, $location, usuarioFactory, message) {
        var vm = this;

        vm.usuario = {
            senha: '',
            novaSenha: '',
            confirmarNovaSenha: ''
        };

        vm.submit = submit;

        function submit() {
            usuarioFactory.trocarSenha(vm.usuario)
                .then(successCallback)
                .catch(errorCallback);

            function successCallback(response) {
                $location.path('/');
                toastr.success(message.getMessage(response), 'Loja Virtual');
            };

            function errorCallback(response) {
                toastr.error('Ocorreu um erro ao processar a requisição: ' + message.getMessage(response), 'Loja Virtual');
            };
        };
    };
})();