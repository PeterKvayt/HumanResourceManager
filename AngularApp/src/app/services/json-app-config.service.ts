import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiConfig } from '../../assets/configure/api-config';

@Injectable({
  providedIn: 'root'
})
export class JsonAppConfigService extends ApiConfig{

  constructor(private httpClient: HttpClient) {
    super();
  }

  load(){
    return this.httpClient.get<ApiConfig>('./assets/configure/api.config.json')
    .toPromise()
    .then(data => {
      this.url = data.url;
      this.activityTypes = data.activityTypes;
      this.positions = data.positions;
      this.companies = data.companies;
      this.employees = data.employees;
      this.legalForms = data.legalForms;
    })
    .catch(() => {
      console.error('Could not load api configuration.');
    });
  }
}
