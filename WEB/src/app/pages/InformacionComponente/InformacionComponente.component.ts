import { RocaService } from 'src/app/services/roca.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Roca } from 'src/app/models/roca.model';
import { Validators } from '@angular/forms';
import { PujaService } from 'src/app/services/puja.service';
import { Puja } from 'src/app/models/puja.model';
import { FormBuilder } from '@angular/forms';
import { ThisReceiver } from '@angular/compiler';


@Component({
  selector: 'app-InformacionComponente',
  templateUrl: './InformacionComponente.component.html',
  styleUrls: ['./InformacionComponente.component.css']

})
export class InformacionComponenteComponent implements OnInit {

    piedra: Roca | null;
    idPiedra: number;
    imagen: string | null;
    texto: string;
    maxPuja: number | null;
    pujas: Puja[] | null;

    pujaForm = this.fb.group({
      pujaPrecio: ['',Validators.required],
    });


  constructor(private fb: FormBuilder,private activatedRoute: ActivatedRoute, private servicio : RocaService, private PuJaSeRvIcE: PujaService) {
    this.piedra = null;
    this.idPiedra = 0;
    this.imagen = "";
    this.maxPuja = 0;
    this.pujas = null;
    this.texto ='';

  }

  ngOnInit(): void {

  this.activatedRoute.paramMap.subscribe((parameters: any) => {
    this.idPiedra = parameters.get('idPiedra');
  });

  this.servicio.SacaRoca(this.idPiedra).subscribe((x) => (this.piedra = x ));

  this.PuJaSeRvIcE
  .getRocaPujaData(this.idPiedra)
  .subscribe((x) => (this.pujas = x) && this.updateMax());
  }

  guardarPuja(){
    if (this.pujaForm.value.pujaPrecio == '') {
      this.texto = 'Introduce un valor';
      return;
    }
    if (this.maxPuja != null) {
      if (this.pujaForm.value.pujaPrecio < this.maxPuja) {
        this.texto = 'La cantidad minima es:' + this.maxPuja + '€';
        return;
      }
      alert('Has pujado ' + this.pujaForm.value.pujaPrecio + '€');
      this.PuJaSeRvIcE.postPujaData(this.idPiedra, this.pujaForm.value);
      // window.location.reload();
    }
  }

  updateMax() {
    if (this.pujas != null) {
      this.pujas.forEach((element) => {
        if (
          element.precio != null &&
          this.maxPuja != null &&
          element.precio > this.maxPuja
        ){
          this.maxPuja = element.precio;
        }
      })
    }
  }
}

