import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';

const routes: Routes = [
  {
    path: '',
    children: [
      { path: '', loadChildren: () => import('./components/client/client.module').then(mod=>mod.ClientModule)},
      { path: 'client', loadChildren: () => import('./components/client/client.module').then(mod=>mod.ClientModule)},
      { path: 'order', loadChildren: () => import('./components/order/order.module').then(mod=>mod.OrderModule)},
      { path: 'product', loadChildren: () => import('./components/product/product.module').then(mod=>mod.ProductModule)},
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
