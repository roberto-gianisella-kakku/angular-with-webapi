import angular from 'angular';

let loader = () => {
    return {
        restrict: 'E',
        scope: {
            show: '='
        },
        template: `
            <div id="loading-overlay" class="overlay-background" ng-show="show">
                <h1>Please Wait...</h1>
            </div>
            ` 
    }
}

export default angular.module('directives.loader', [])
  .directive('loader', loader)
  .name;