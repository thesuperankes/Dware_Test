import { environment } from './../../../environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  constructor(private http: HttpClient) {}

  getAllOrder() {
    return this.http.get(environment.endpoint + '/order');
  }

  deleteOrder(id: number) {
    return this.http.delete(environment.endpoint + '/order/' + id);
  }
}
