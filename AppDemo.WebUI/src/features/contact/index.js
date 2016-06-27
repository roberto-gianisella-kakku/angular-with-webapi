import angular from 'angular';
import uirouter from 'angular-ui-router';

import routing from './contact.routes';
import ContactController from './contact.controller';

import contactService from '../../services/contact.service';
import configValues from '../../services/configsValue.service';
import alert from '../../directives/alert.directive';
import loader from '../../directives/loader.directive';

ContactController.$inject = ['contactService','configValues'];

export default angular.module('app.contact', [uirouter,contactService,configValues, alert, loader])
  .config(routing)
  .controller('ContactController', ContactController)
  .name;
