(function() {
    'use strict';

    angular.module('LV').controller('logoutCtrl', logoutController);

    logoutController.$inject = ['$rootScope', '$location', 'settings'];

    function logoutController($rootScope, $location, settings) {
        var vm = this;

        initialization();

        function initialization() {
            $rootScope.usuario = null;
            $rootScope.token = null;
            $rootScope.header = null;

            sessionStorage.removeItem(settings.constUsuario);
            sessionStorage.removeItem(settings.constToken);
            $location.path('/');
        };
    };
})();