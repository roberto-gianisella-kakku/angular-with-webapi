import angular from 'angular';
import configValues from './configsValue.service';

const HTTP = new WeakMap();

class WeatherService {

    constructor($http, configValues) {

        HTTP.set(this, $http);
    }
    getForecast(weatherApiUrl) {
        return HTTP.get(this).get(weatherApiUrl).then(forecast => forecast);
    }
}

WeatherService.$inject = ['$http','configValues'];

export default angular.module('services.weather', [configValues])
  .service('weatherService', WeatherService).name;
