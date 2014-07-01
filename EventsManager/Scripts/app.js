﻿var EventsCalendarApp = angular.module("EventsCalendarApp", ["ngRoute", "ngResource"]).
    config(function ($routeProvider) {
        $routeProvider.
            when('/', { controller: ListCtrl, templateUrl: 'list.html' }).
            when('/new', { controller: CreateCtrl, templateUrl: 'details.html' }).
            when('/edit/:editId', { controller: EditCtrl, templateUrl: 'details.html' }).
            otherwise({ redirectTo: '/' });
    });

EventsCalendarApp.factory('CalendarEvent', function ($resource) {
    return $resource('/api/CalendarEvent/:id', { id: '@id' }, { update: { method: 'PUT' } });
});


var CreateCtrl = function ($scope, $location, CalendarEvent) {
    $scope.action = "Add";
    $scope.save = function () {
        CalendarEvent.save($scope.item, function() {
            $location.path('/');
        });
    };
};

var EditCtrl = function ($scope, $location, $routeParams, CalendarEvent) {
    var id = $routeParams.editId;
    $scope.item = CalendarEvent.get({ id: id });
    $scope.action = "Update";

    $scope.save = function () {
        CalendarEvent.update({ id: id }, $scope.item, function () {
            $location.path('/');
        });
    };
};

var ListCtrl = function ($scope, $location, CalendarEvent) {
    // this one appends results - as it's show more
    $scope.search = function () {
        CalendarEvent.query({
                q: $scope.query,
                sort: $scope.sort_order,
                desc: $scope.is_desc,
                offset: $scope.offset,
                limit: $scope.limit
            },
            function (data) {
                $scope.more = data.length === 20;
            $scope.items = $scope.items.concat(data);
        });
    };

    $scope.sort = function (col) {
        if ($scope.sort_order === col) {
            $scope.is_desc = !$scope.is_desc;
        } else {
            $scope.sort_order = col;
            $scope.is_desc = false;
        }
        $scope.sort_order = col;
        $scope.reset();
    };

    $scope.show_more= function() {
        $scope.offset += $scope.limit;
        $scope.search();
    }

    $scope.has_more = function() {
        return $scope.more;
    }

    $scope.reset = function() {
        $scope.limit = 20;
        $scope.offset = 0;
        $scope.items = [];
        $scope.more = true;
        $scope.search();
    };

    $scope.delete = function() {
        var id =  this.calendarEvent.Id;
        CalendarEvent.delete({ id: id }, function() {
                $('#event_' + id).fadeOut();
            }
        );
        $('#event_' + id).fadeOut();
    };


    $scope.sort_order = "EventDate";
    $scope.is_desc = false;
   
    $scope.reset();

};