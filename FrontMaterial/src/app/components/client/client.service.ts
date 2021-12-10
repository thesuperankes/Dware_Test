import { environment } from './../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Client } from './client.model';

@Injectable({
  providedIn: 'root',
})
export class ClientService {
  constructor(private http: HttpClient) {}

  getAllClient() {
    return this.http.get(environment.endpoint + '/client');
  }

  updateClient(data: Client) {
    return this.http.put(environment.endpoint + '/client', { client: data });
  }

  deleteClient(id: number) {
    return this.http.delete(environment.endpoint + '/client/' + id);
  }

  createClient(data:Client){
    return this.http.post(environment.endpoint + '/client',{ client: data});
  }
}
