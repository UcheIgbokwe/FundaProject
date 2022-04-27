import {HttpClient, json} from 'aurelia-fetch-client';
import {inject} from 'aurelia-framework';
import * as toastr from 'toastr';

@inject(HttpClient)
export class TestPortalAPI{
  isRequesting = false;

  constructor(private http: HttpClient) {
    const baseUrl = 'http://localhost:5156/api/';

    http.configure(config => {
      config.withBaseUrl(baseUrl);
    })
  }

  //Get Top 10 properties
  getAgentsRankedByMostProperties(){
    this.isRequesting = true;
    return this.http.fetch('PropertyDetails/GetAgentsRankedByMostProperties')
      .then(response => response.json())
      .then(result => {
        this.isRequesting = false;
        return result;
      })
    .catch(error => {
      if(!this.IsJson(error))
      {
        this.isRequesting = false
        toastr.error("Pleas try again", 'Error!')
        return [];
      }
      this.isRequesting = false
      toastr.error(error, 'Error!')
      return [];
    });  
  }

  //Get Top 10 properties with garden
  getAgentsRankedByMostPropertiesAndGarden(){
    this.isRequesting = true;
    return this.http.fetch('PropertyDetails/GetAgentsRankedByMostPropertiesAndGarden')
      .then(response => response.json())
      .then(result => {
        this.isRequesting = false;
        return result;
      })
    .catch(errorLog => {
      if(!this.IsJson(errorLog))
      {
        this.isRequesting = false
        toastr.error("Pleas try again", 'Error!')
        return [];
      }
      this.isRequesting = false
      toastr.error(errorLog, 'Error!')
      return [];
    });  
  }

  IsJson(str) {
    try {
        JSON.parse(str);
    } catch (e) {
        return false;
    }
    return true;
}

}
