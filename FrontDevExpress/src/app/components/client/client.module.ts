import { DevExtremeModule } from './../../shared/devextreme.module';
import { ClientComponent } from './client.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClientRoutingModule } from './client-routing.module';


@NgModule({
  declarations: [
    ClientComponent
  ],
  imports: [
    CommonModule,
    ClientRoutingModule,
    DevExtremeModule
  ]
})
export class ClientModule { }
