import { TestPortalAPI } from '../../api/agent';
import {observable} from 'aurelia-framework';
import {autoinject} from 'aurelia-dependency-injection';
  
@autoinject
export class TopTenAgentsList {
  reports;
  @observable
  public currentLocale: string;

  constructor(private api: TestPortalAPI) { 
    
  }


  bind() {
    this.api.getAgentsRankedByMostProperties().then(result => {
      this.reports = result;
    });
  }

}
  

  