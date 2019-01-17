
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-ingrediente',
  templateUrl: './ingrediente.component.html',
  styleUrls: ['./ingrediente.component.css']
})
export class IngredienteComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
export class Ingrediente {
    id: 0;
    Produto: null;
    // materiaPrima
    valorEnergetico: 0;
    valorDiario: 0;
}
