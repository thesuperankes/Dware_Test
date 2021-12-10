import { MaterialModule } from './material.module';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  exports: [MaterialModule, ReactiveFormsModule, FormsModule],
})
export class SharedModule {}
