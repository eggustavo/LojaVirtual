(function() {
    'use strict';

    angular.module('etec').directive('valorMaximo500', valorMaximo500);

    function valorMaximo500() {
        console.log('entrou');
        return {
            require: 'ngModel',
            controller: function($element) {
                var ctrl = $element.controller('ngModel');
                console.log(ctrl);
                ctrl.$validators.valorMensalidade =
                    function(modelValue, viewValue) {
                        console.log('entrou');
                        return viewValue && viewValue <= 500;
                };
            }
        };
    };
})();