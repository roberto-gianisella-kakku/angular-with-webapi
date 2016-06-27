import angular from 'angular';

let alert = () => {
    return {
        restrict: 'E',
        scope: {
            show: '=',
            success: '=',
            msg:'='
        },
        template: `
            <div ng-class="success ? 'alert-success' : 'alert-danger'" class="alert alert-dismissible alert-success" role="alert" ng-show="show">{{msg}}</div>
            `
    }
}

export default angular.module('directives.alert', [])
  .directive('alert', alert)
  .name;