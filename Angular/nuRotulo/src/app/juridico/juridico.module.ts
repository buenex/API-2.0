import { JuridicoComponent } from './juridico.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    JuridicoComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
  ],
  exports: [
    JuridicoComponent,
  ]
})
export class JuridicoModule { }

