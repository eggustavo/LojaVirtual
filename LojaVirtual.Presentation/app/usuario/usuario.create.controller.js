(function(){
    'use strict';

    angular.module('LV').controller('usuarioCreateCtrl', usuarioCreateController);

    usuarioCreateController.$inject = ['$location', 'usuarioFactory', 'cepFactory'];

    function usuarioCreateController($location, usuarioFactory, cepFactory) {
        var vm = this;

        vm.usuario = {
            nome: '',
            usuarioLogin: '',
            senha: '',
            confirmarSenha: '',
            email: '',
            cep: '',
            logradouro: '',
            numero: '',
            complemento: '',
            bairro: '',
            municipio: '',
            uf: ''
        };

        vm.criar = criar;
        vm.pesquisarCep = pesquisarCep;

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

        function pesquisarCep() {
            if (vm.usuario.cep == null)
                return;

            cepFactory.pesquisar(vm.usuario.cep)
                .then(successCallback)
                .catch(errorCallback);

            function successCallback(response) {
                vm.usuario.logradouro = response.data.logradouro;
                vm.usuario.complemento = response.data.complemento;
                vm.usuario.bairro = response.data.bairro;
                vm.usuario.municipio = response.data.localidade;
                vm.usuario.uf = response.data.uf;
                


    /*

                {
                    "cep": "15991-512",
                    "logradouro": "Avenida José Schimidt",
                    "complemento": "",
                    "bairro": "Nova Cidade",
                    "localidade": "Matão",
                    "uf": "SP",
                    "unidade": "",
                    "ibge": "3529302",
                    "gia": "4418"
                }*/
            };

            function errorCallback(response) {
                toastr.error('Ocorreu um erro ao processar a requisição: ' + message.getMessage(response), 'Loja Virtual');
            };
        };
    };
})();