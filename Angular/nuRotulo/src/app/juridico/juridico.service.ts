import { Jur, Est, Cid, Pai } from './juridico.component';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { analyzeAndValidateNgModules } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class JuridicoService {
  juridicoUrl = 'http://localhost:5000/api/';
  retorno: any;

  constructor(private http: HttpClient) { }

  inserir(jurid: Jur) {
   this.http.post(this.juridicoUrl + 'juridico', JSON.stringify(jurid));
   alert(JSON.stringify(jurid));

   this.retorno = JSON.stringify(jurid).toString;
  }
  getPaises() {
    return this.http.get<any []>(`${this.juridicoUrl + 'pais'} `);
  }
  getEstados(pais: number) {
    return this.http.get<any []>(`${this.juridicoUrl + 'estado/pais/' + pais} `);
  }
  getCidades(estado: number) {
    return this.http.get<any []>(`${this.juridicoUrl + 'cidade/estado/' + estado} `);
  }
  getPaisByName(pais: string) {
    return this.http.get<Pai>(`${this.juridicoUrl + 'pais/name/' + pais} `);
  }
  getEstadoByName(estado: string) {
    return this.http.get<Est>(`${this.juridicoUrl + 'estado/name/' + estado} `);
  }
}
