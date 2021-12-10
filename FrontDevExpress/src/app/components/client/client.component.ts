import { environment } from './../../../environments/environment';
import { Component, OnInit } from '@angular/core';
import { ClientService } from './client.service';
import CustomStore from 'devextreme/data/custom_store';
import { HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css'],
  providers: [ClientService],
})
export class ClientComponent implements OnInit {
  clients: any[] = [];
  dataSource: any;

  toastOpen = false;
  toastMessage = 'Operacion realizada con exito';
  toastType:'error' | 'success' = 'success'

  constructor(private service: ClientService) {
    this.dataSource = new CustomStore({
      key: 'ClientId',
      load: () => this.getAllClient(),
      insert: (values) => this.createClient(values),
      update: (key, values) => this.updateClient(key, values),
      remove: (key) => this.deleteClient(key),
      onInserted: () => { this.toastOpen = true; this.toastType= 'success'; this.toastMessage = 'Se creo un nuevo registro'; },
      onRemoved: () => { this.toastOpen = true; this.toastType= 'success'; this.toastMessage = 'Registro eliminado'; },
      onUpdated: () => { this.toastOpen = true; this.toastType= 'success'; this.toastMessage = 'Se actualizo el registro'; }
    });
  }

  ngOnInit(): void {}

  getAllClient() {
    return this.service
      .getAllClient()
      .toPromise()
      .then((data: any) => {
        this.clients = data.client;
        return data.client;
      });
  }

  updateClient(key: number, body: any) {
    let found = this.clients.find((x) => x.ClientId == key);
    let obj = Object.assign(found, body);
    return this.service
      .updateClient(obj)
      .toPromise()
      .then((data: any) => data);
  }

  deleteClient(key: number) {
    return this.service
      .deleteClient(key)
      .toPromise()
      .then((data: any) => data);
  }

  createClient(body: any) {
    return this.service
      .createClient(body)
      .toPromise()
      .then((data: any) => {
        let obj = Object.assign(body, { ClientId: data.clientId });
        this.clients.push(obj);
        return obj;
      });
  }
}
