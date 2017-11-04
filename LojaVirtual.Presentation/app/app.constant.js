(function() {
    'use strict';

    console.log('constant');

    angular.module('LV').constant('settings', {
        'constServiceUrl': 'http://localhost:64451/',
        'constCarrinho': 'lv-carrinho',
        'constUsuario': 'lv-usuario',
        'constToken': 'lv-token' 
    });
})();