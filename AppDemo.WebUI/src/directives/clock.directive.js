import angular from 'angular';

let clock = ($filter, $timeout) => {
    return {
        restrict: 'E',
        scope: {
            format: '@'
        },
        link:function(scope, element){
            let updateTime = () => {
                let now = Date.now();
                element.html($filter('date')(now, scope.format));
                $timeout(updateTime, 1000);
            };
            updateTime();
        }
    }
}

export default angular.module('directives.clock', [])
  .directive('clock', clock)
  .name;
