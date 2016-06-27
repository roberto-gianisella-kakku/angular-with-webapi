import angular from 'angular';
import configValues from './configsValue.service';

const HTTP = new WeakMap();

const INIT = new WeakMap();
const SERVICE = new WeakMap();

class ContactService {

    constructor($http, configValues) {
        HTTP.set(this, $http);

        //SERVICE.set(this, configValues);
        //INIT.set(this, () => {
        //    SERVICE.get(this).apibase().then(apibase => {
        //        this.apiBase = apibase;
        //    });
        //});
        //INIT.get(this)();

    }

    sendRequest(request, apiBase) {
        return HTTP.get(this).post(apiBase + 'contact/request', request).then(result => result.data);
    }
}

//ContactService.$inject = ['$http','configValues'];

export default angular.module('services.contact', [configValues])
  .service('contactService', ContactService)
  .name;