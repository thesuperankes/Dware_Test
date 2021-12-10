import { ClientService } from './../client/client.service';
import { environment } from './../../../environments/environment';
import { Component, OnInit } from '@angular/core';
import CustomStore from 'devextreme/data/custom_store';
import { OrderService } from './order.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css'],
  providers: [OrderService, ClientService],
})
export class OrderComponent implements OnInit {
  Orders: any[] = [];
  clients: any[] = [];
  dataSource: any;
  clientData: any;

  toastOpen = false;

  constructor(
    private service: OrderService,
    private clientService: ClientService
  ) {
    this.clientService
      .getAllClient()
      .subscribe((data: any) => (this.clients = data.client));

    this.dataSource = new CustomStore({
      key: 'OrderId',
      load: () => this.getAllOrder(),
      remove: (key) => this.deleteOrder(key),
      onRemoved: () => (this.toastOpen = true),
    });
  }

  ngOnInit(): void {}

  getAllOrder() {
    return this.service
      .getAllOrder()
      .toPromise()
      .then((data: any) => {
        let list = data.order.map((x: any) => {
          let name = this.getIdName(x.ClientId);
          return Object.assign(x, { ClientName: name });
        });

        this.Orders = list;
        return list;
      });
  }

  deleteOrder(key: number) {
    return this.service
      .deleteOrder(key)
      .toPromise()
      .then((data: any) => data);
  }

  getIdName(clientId: number) {
    let found = this.clients.find((x) => x.ClientId == clientId);
    return `${found.FirstName} ${found.LastName}`;
  }
}
