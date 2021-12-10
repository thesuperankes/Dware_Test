import { Component, OnInit } from '@angular/core';
import CustomStore from 'devextreme/data/custom_store';
import { ProductService } from './product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
  providers:[ProductService]
})
export class ProductComponent implements OnInit {
  products: any[] = [];
  dataSource: any;

  toastOpen = false;
  toastMessage = 'Operacion realizada con exito';
  toastType: 'error' | 'success' = 'success';

  constructor(private service: ProductService) {
    this.dataSource = new CustomStore({
      key: 'ProductId',
      load: () => this.getAllProduct(),
      insert: (values) => this.createProduct(values),
      update: (key, values) => this.updateProduct(key, values),
      remove: (key) => this.deleteProduct(key),
      onInserted: () => {
        this.toastOpen = true;
        this.toastType = 'success';
        this.toastMessage = 'Se creo un nuevo registro';
      },
      onRemoved: () => {
        this.toastOpen = true;
        this.toastType = 'success';
        this.toastMessage = 'Registro eliminado';
      },
      onUpdated: () => {
        this.toastOpen = true;
        this.toastType = 'success';
        this.toastMessage = 'Se actualizo el registro';
      },
    });
  }

  ngOnInit(): void {}

  getAllProduct() {
    return this.service
      .getAllProduct()
      .toPromise()
      .then((data: any) => {
        this.products = data.product;
        return data.product;
      });
  }

  updateProduct(key: number, body: any) {
    let found = this.products.find((x) => x.ProductId == key);
    let obj = Object.assign(found, body);
    return this.service
      .updateProduct(obj)
      .toPromise()
      .then((data: any) => data);
  }

  deleteProduct(key: number) {
    return this.service
      .deleteProduct(key)
      .toPromise()
      .then((data: any) => data);
  }

  createProduct(body: any) {
    return this.service
      .createProduct(body)
      .toPromise()
      .then((data: any) => {
        let obj = Object.assign(body, { ProductId: data.productId });
        this.products.push(obj);
        return obj;
      });
  }
}
