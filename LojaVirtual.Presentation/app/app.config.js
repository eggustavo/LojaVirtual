(function() {
    'use strict';
    
    angular.module('LV').config(config);      
    config.$inject = ['$routeProvider'];

    function config($routeProvider) {
        $routeProvider
        .when('/', {
            templateUrl: 'app/home/home.html'            
        })
        .when('/categoria/list', {
            templateUrl: 'app/categoria/categoria.list.html',
            controller: 'categoriaListCtrl',
            controllerAs: 'vm'
        })
        .when('/categoria/view/:categoriaId', {
            templateUrl: 'app/categoria/categoria.view.html',
            controller: 'categoriaViewCtrl',
            controllerAs: 'vm'
        })        
        .when('/categoria/create', {
            templateUrl: 'app/categoria/categoria.create.html',
            controller: 'categoriaCreateCtrl',
            controllerAs: 'vm'
        })
        .when('/categoria/edit/:categoriaId', {
            templateUrl: 'app/categoria/categoria.edit.html',
            controller: 'categoriaEditCtrl',
            controllerAs: 'vm'
        })                
        .otherwise({
            redirectTo: '/'
        });
    };
})();