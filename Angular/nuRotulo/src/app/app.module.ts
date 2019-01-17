import { HttpClientModule } from '@angular/common/http';
import { JuridicoService } from './juridico/juridico.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { JuridicoComponent } from './juridico/juridico.component';
import { from } from 'rxjs';
import { ProdutoComponent } from './produto/produto.component';
import { IngredienteComponent } from './ingrediente/ingrediente.component';




@NgModule({
  declarations: [
    AppComponent,
    JuridicoComponent,
    ProdutoComponent,
    IngredienteComponent

  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [
    JuridicoService
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
