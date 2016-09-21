(function () {
    'use strict';

    angular
        .module('bookStore')
        .controller('BookListCtrl', ['bookResource', 'checkoutResource', BookListCtrl]);

    function BookListCtrl(bookResource, checkoutResource) {
        var vm = this;

        vm.searchCriteria = '';

        bookResource.query({ searchString: vm.searchCriteria }, function (data) {
            vm.books = data;
        });

        vm.search = function () {
            bookResource.query({ searchString: vm.searchCriteria }, function (data) {
                vm.books = data;
            });
        };

        vm.order = {};

        var ShoppingCartModel = function () {
            var self = this;

            self.items = [];

            self.addItem = function (item) {

                var indexOfItem = self.items.indexOf(item);

                if (indexOfItem === -1) {
                    item.quantity = 1;
                    self.items.push(item);
                } else {
                    self.items[indexOfItem].quantity += 1;
                }
                
                self.totalSum();
            };

            self.removeItem = function(item) {
                var indexOfItem = self.items.indexOf(item);

                if (indexOfItem === -1) {
                    return;
                }

                if (self.items[indexOfItem].quantity > 1) {
                    self.items[indexOfItem].quantity -= 1;
                } else {
                    self.items.splice(indexOfItem, 1);
                }
                
            };

            self.totalSum = function() {
                var totalSum = 0;
                
                self.items.forEach(function(item) {
                    totalSum += item.price * item.quantity;
                });

                return totalSum;
            };

            self.checkOut = function () {
                if (self.items.length > 0) {
                    checkoutResource.save({ rows: self.items }, function (order) {
                        self.items = [];
                        vm.order = order;
                    });
                }
            };
        };

        vm.shoppingCart = new ShoppingCartModel();
    }
}());