import 'bootstrap/dist/css/bootstrap.css';
import '../style/app.less';

import angular from 'angular';
import uirouter from 'angular-ui-router';

import routing from './app.config';
import home from '../features/home';
import contact from '../features/contact';
import clock from '../directives/clock.directive';
import weather from '../directives/weather.directive';

let app = () => {
  return {
    template: require('./app.html'),
    controller: 'AppCtrl',
    controllerAs: 'app'
  }
};

class AppCtrl {
    constructor() {
      
    }
}

AppCtrl.$inject = ['configValues'];

const MODULE_NAME = 'app';

angular.module(MODULE_NAME, [uirouter, home, contact, clock, weather])
    .config(routing)
  .directive('app', app)
  .controller('AppCtrl', AppCtrl);

export default MODULE_NAME;