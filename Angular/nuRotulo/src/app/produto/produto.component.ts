import { Ingrediente } from './../ingrediente/ingrediente.component';
import { ProdutoService } from './produto.service';
import { Component, OnInit } from '@angular/core';
import { IngredienteComponent } from '../ingrediente/ingrediente.component';
import { ArrayType } from '@angular/compiler';


@Component({
  selector: 'app-produto',
  templateUrl: './produto.component.html',
  styleUrls: ['./produto.component.css']
})
export class ProdutoComponent implements OnInit {

  public Produto: any = {
    id: 0,
    descricao: '',
    valorVenda: 0,
    preparo: '',
    conservacao: '',
    codigoBarra: '',
    // ingredientes: Array
  }

  constructor(private prodService: ProdutoService) { }

  ngOnInit() {
  }

}
