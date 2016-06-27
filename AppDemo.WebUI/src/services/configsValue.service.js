import angular from 'angular';

const HTTP = new WeakMap();

class ConfigValues {

    constructor($http) {
        HTTP.set(this, $http);
    }

    apibase() {
        return HTTP.get(this).get('/config.json').then(result => result.data.config.apibase );
    }

    config() {
        return HTTP.get(this).get('/config.json').then(result => result.data.config );
    }
}

export default angular.module('services.config-values', [])
  .service('configValues', ConfigValues)
  .name;