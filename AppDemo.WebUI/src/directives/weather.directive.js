import angular from 'angular';
import weatherService from '../services/weather.service';
import configValues from '../services/configsValue.service';

let weather = ($timeout, weatherService, configValues) => {
    return {
        template:
            `
            <span>{{desc}}</span>
<img ng-src="http://openweathermap.org/img/w/{{icon}}.png">
            `,
        link: function (scope, element, attrs) {

            configValues.config().then((config) => {
                
                weatherService.getForecast(config.weatherurl).then((forecast) => {
                    let updateWeather = () => {

                        let w = forecast.data.weather[0];

                        scope.desc = w.description;
                        scope.icon = w.icon;

                        //1h
                        $timeout(updateWeather, 3600000);
                    };
                    updateWeather();
                }, () => {
                    scope.desc = 'add your appid to public/config.json -> weatherurl to have weather widget working';
                });
            });
        },
        restrict: 'E'
    }
}

export default angular.module('directives.weather', [weatherService, configValues])
  .directive('weather', weather)
  .name;