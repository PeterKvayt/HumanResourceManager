import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class HttpService {

  constructor(private httpClient: HttpClient) { }

  public get(url: string) {
    return this.httpClient.get(url);
  }

  public getById(url: string, id: number){
    const query = url + '/' + id.toString();
    return this.httpClient.get(query);
  }

  public post<ModelType>(url: string, model: ModelType){
     const headers = { 'content-type': 'application/json'};
     return this.httpClient.post(url, model, {headers});
  }

  public delete(url: string, id: number){
    const action = url + '/' + id;
    return this.httpClient.delete(action);
  }

  public put<ModelType>(url: string, model: ModelType){
    const headers = { 'content-type': 'application/json'};
    return this.httpClient.put(url, model, {headers});
  }
}
