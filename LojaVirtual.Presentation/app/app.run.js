(function() {
    'use strict';

    console.log('run');

    angular.module('LV').run(lojaVirtualRun);

    lojaVirtualRun.$inject = ['$rootScope', '$location', 'settings'];

    function lojaVirtualRun($rootScope, $location, settings) {
        //Recuperando dados do login da sessão do navegador, cada aba aberta é uma sessão diferente
        var usuario = sessionStorage.getItem(settings.constUsuario);
        var token = sessionStorage.getItem(settings.constToken);
        var carrinho = sessionStorage.getItem(settings.constCarrinho);

        $rootScope.usuario = null;
        $rootScope.token = null;
        $rootScope.header = null; 
        $rootScope.carrinho = [];      

        if (usuario && usuario) {
            $rootScope.usuario = usuario;
            $rootScope.token = token;
            $rootScope.header = {
                headers: {
                    'Authorization': 'bearer ' + $rootScope.token
                }
            };
        };

        if (carrinho) {
            var itemsCarrinho = angular.fromJson(carrinho);
            angular.forEach(itemsCarrinho, function (value, key) {
                $rootScope.carrinho.push(value);
            });           
        };

        $rootScope.$on("$routeChangeStart", function (event, next, current) {
            //console.log('Event: ', event);
            //console.log('Next: ', next);
            //console.log('Current: ', current);
            //console.log('Next Restrito: ', next.restrito);
            //console.log('rootScopeUsuario: ', $rootScope.usuario);

            if (next.restrito && $rootScope.usuario == null) {
                $location.path("/login");              
            };
        });        
    };
})();