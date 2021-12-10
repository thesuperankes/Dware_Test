import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {  DxListModule, DxSelectBoxModule, DxTemplateModule, DxToolbarModule,DxDataGridModule, DxToastModule } from 'devextreme-angular';



@NgModule({
  declarations: [],
  exports: [
    CommonModule,
    DxListModule,
    DxToolbarModule,
    DxSelectBoxModule,
    DxTemplateModule,
    DxDataGridModule,
    DxToastModule
  ]
})
export class DevExtremeModule { }
