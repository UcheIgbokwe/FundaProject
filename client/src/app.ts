import {Router, RouterConfiguration} from 'aurelia-router';
import {inject, PLATFORM} from 'aurelia-framework';

import { TestPortalAPI } from './api/agent';

@inject(TestPortalAPI) 
export class App {
  router: Router;

  constructor(public api: TestPortalAPI) {}

  configureRouter(config: RouterConfiguration, router: Router){
    config.title = 'Funda Portal';
    config.options.pushState = true;
    config.options.root = '/';
    config.map([
      { route: '',               moduleId: PLATFORM.moduleName('./components/propertyList/topTenAgents'), title:'Funda' },
      { route: 'tuin/',       moduleId: PLATFORM.moduleName('./components/propertyGardenList/topTenAgents'), name:'GardenProperties' }
    ]);

    this.router = router;
  }
}
