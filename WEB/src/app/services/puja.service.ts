import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Puja } from '../models/puja.model';

@Injectable()
export class PujaService {
  constructor(private http: HttpClient) {}

  getPujaData() : Observable<Puja[]> {
    return this.http.get<Puja[]>(environment.API_URL + 'pujas');
  }

  getIdPujaData(id: number): Observable<Puja> {
      return this.http.get<Puja>(environment.API_URL + 'pujas/' + id);
  }

  getRocaPujaData(id: number): Observable<Puja[]> {
    return this.http.get<Puja[]>(environment.API_URL + 'pujas/roca' + id);
}

  SacaPuja(id : number) : Observable<Puja> {
    return this.http.get<Puja>(environment.API_URL + 'pujas/'+id);
  }

  postPujaData(Id: number, body : any) : Puja {
    let bodyData =new Puja();
    bodyData.idPiedra=Id;
    bodyData.precio=body.pujaPrecio;


    let result =new Puja();
    this.http.post<Puja>(environment.API_URL + 'pujas',bodyData)
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
