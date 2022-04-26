import { TestPortalAPI } from '../../api/agent';
import {observable} from 'aurelia-framework';
import {autoinject} from 'aurelia-dependency-injection';
  
@autoinject
export class TopTenAgentsWithGardenList {
  gardenReports;
  @observable
  public currentLocale: string;

  constructor(private api: TestPortalAPI) { 
    
  }


  bind() {
    this.api.getAgentsRankedByMostPropertiesAndGarden().then(result => {
      this.gardenReports = result;
    });
  }
}
  

  