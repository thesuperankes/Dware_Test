import { SharedModule } from './../../shared/shared.module';
import { ClientComponent } from './client.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ClientRoutingModule } from './client-routing.module';
import { ClientdialogComponent } from './clientdialog/clientdialog.component';


@NgModule({
  declarations: [
    ClientComponent,
    ClientdialogComponent,
  ],
  imports: [
    CommonModule,
    ClientRoutingModule,
    SharedModule
  ]
})
export class ClientModule { }
