(function() {
    'use strict';

    console.log('module');

    angular.module('LV', 
        ['ngRoute',
         'ui.utils.masks',
         'naif.base64',
         'ngPassword']);
})();