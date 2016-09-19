(function () {
    'use strict';

    angular
        .module('bookStore')
        .controller('BookListCtrl', ['bookResource', BookListCtrl]);

    function BookListCtrl(bookResource) {
        var vm = this;
        vm.searchCriteria = '';

        vm.search = function () {
            console.log('Quering!');
            bookResource.query({ searchString: vm.searchCriteria }, function (data) {
                vm.books = data;
                console.log(data);
            });
        };

        bookResource.query({ searchString: vm.searchCriteria }, function (data) {
            vm.books = data;
        });
    }

}());