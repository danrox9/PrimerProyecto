import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Roca } from '../models/roca.model';

@Injectable()
export class RocaService {
  constructor(private http: HttpClient) {}
  getRocaData() : Observable<Roca[]> {
    return this.http.get<Roca[]>(environment.API_URL + 'rocas');
  }

  SacaRoca(id : number) : Observable<Roca> {
    return this.http.get<Roca>(environment.API_URL + 'rocas/'+id);
  }

  postRocaData(body : any) : Roca {
    let bodyData =new Roca();
    bodyData.foto=body.rocaFoto;
    bodyData.nombre=body.rocaNombre;
    bodyData.precio=body.rocaPrecio;


    let result =new Roca();
    this.http.post<Roca>(environment.API_URL + 'rocas',bodyData)
    .subscribe(
      (response) => {                           
        console.log('response received')
        result = response;
      },
      (error) => {                            
        console.error('error caught in component')
      }
    )
    return result;
  }
}
