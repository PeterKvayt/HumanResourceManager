import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class HttpService {

  constructor(private httpClient: HttpClient) { }

  public get(url: string) {
    return this.httpClient.get(url);
  }

  public post<ModelType>(url: string, model: ModelType){
     const headers = { 'content-type': 'application/json'};
     return this.httpClient.post(url, model, {headers});
  }
}
