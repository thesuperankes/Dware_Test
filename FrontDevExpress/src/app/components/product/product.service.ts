import { environment } from './../../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http:HttpClient) { }

  getAllProduct() {
    return this.http.get(environment.endpoint + '/product');
  }

  updateProduct(data: any) {
    return this.http.put(environment.endpoint + '/product', { product: data });
  }

  deleteProduct(id: number) {
    return this.http.delete(environment.endpoint + '/product/' + id);
  }

  createProduct(data:any){
    return this.http.post(environment.endpoint + '/product',{ product: data});

  }
}
