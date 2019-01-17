
import { JuridicoModule } from './juridico.module';
import { JuridicoService } from './juridico.service';
import { Component, OnInit, Input } from '@angular/core';


@Component({
  selector: 'app-juridico',
  templateUrl: './juridico.component.html',
  styleUrls: ['./juridico.component.css']
})

export class JuridicoComponent implements OnInit {


  constructor(private JurService: JuridicoService) {
  }

  juridico: Jur = new Jur;
  paises: Pai[];
  estados: Est[];
  cidades: Cid[];
  paisAtual: Pai;
  estAtual: Est;
  cidAtual: Cid;
  confirmaSenha: string;
  submit() {
    if (this.juridico.senha !== this.confirmaSenha) {
      alert('As senhas não conferem!');
      this.confirmaSenha = '';
    } else if (this.juridico.senha === this.confirmaSenha) {
      // logica de inserção
      this.JurService.inserir(this.juridico);
      }


  }

  getClass() {
    return this.juridico;
  }

  clear() {
    this.juridico.razaoSocial = '';
    this.juridico.cnpj = 1000;
    this.juridico.email = '';
    this.juridico.senha = '';
    this.juridico.pessoa.nome = '';
    this.juridico.pessoa.endereco.descricao = '';
  }
  ngOnInit() {
    this.paisAtual = new Pai;
    this.estAtual = new Est;
    this.cidAtual = new Cid;
    this.getPaises();
    this.juridico = new Jur;
    this.juridico.pessoa = new Pes;
    this.juridico.pessoa.endereco = new End;
    this.juridico.pessoa.endereco.cidade = this.cidAtual;
    this.juridico.pessoa.endereco.cidade.estado = this.estAtual;
    this.juridico.pessoa.endereco.cidade.estado.pais = this.paisAtual;
  }
  getPaises() {
    this.JurService.getPaises().subscribe(dados => this.paises = dados );
  }
  getEstados(pais: Pai) {
    this.JurService.getEstados(pais.id).subscribe(dados => this.estados = dados );
  }
  getCidades(estado: Est) {
    this.JurService.getCidades(estado.id).subscribe(dados => this.cidades = dados );
  }

  getPaisByName() {
    this.JurService.getPaisByName(
      this.paisAtual.descricao
      ).subscribe(dados => this.juridico.pessoa.endereco.cidade.estado.pais = dados);
  }

  getEstadoByName() {
    this.JurService.getEstadoByName(
      this.estAtual.descricao
      ).subscribe(dados => this.juridico.pessoa.endereco.cidade.estado = dados);
    }

  check() {
    alert(this.estAtual.pais.descricao);
  }

}

export class Jur {
  razaoSocial: string;
  cnpj: number;
  email: string;
  senha: string;
  pessoa: Pes;
}
export class Pes {
  id: number;
  nome: string;
  dataCadastro: Date;
  endereco: End;
  grupoUsuario: Gru;
}
export class Gru {
  id: number;
  descricao: string;
}
export class End {
  id: number;
  descricao: string;
  bairro: string;
  cidade: Cid;
}

export class Est {
  id: number;
  descricao: string;
  pais: Pai;
}
export class Cid {
  id: number;
  descricao: string;
  estado: Est;
}
export class Pai {
  id: number;
  descricao: string;
}
