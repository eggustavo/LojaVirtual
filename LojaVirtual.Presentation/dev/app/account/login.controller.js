(function() {
    'use strict';

    angular.module('LV').controller('loginCtrl', loginController);

    loginController.$inject = ['$rootScope', '$location', 'loginFactory', 'usuarioFactory', 'settings'];

    function loginController($rootScope, $location, loginFactory, usuarioFactory, settings) {
        var vm = this;

        vm.usuario = {
            usuarioLogin: '',
            senha: ''
        };

        vm.submit = submit;

        function submit() {
            loginFactory.login(vm.usuario)
                .then(successCallback)
                .catch(errorCallback);

            function successCallback(response) {
                $rootScope.usuario = vm.usuario.usuarioLogin;
                $rootScope.token = response.data.access_token;
                $rootScope.header = {
                    headers: {
                        'Authorization': 'bearer ' + $rootScope.token
                    }
                };

                //Gravando dados do login na sessão do navegador, cada aba aberta é uma sessão diferente
                sessionStorage.setItem(settings.constUsuario, $rootScope.usuario);
                sessionStorage.setItem(settings.constToken, $rootScope.token);                

                $location.path('/');
            };

            function errorCallback(response) {
                toastr.error(response.data.error_description, response.data.error);
            };
        };
    };
})();