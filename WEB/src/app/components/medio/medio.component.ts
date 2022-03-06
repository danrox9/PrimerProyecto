import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Roca } from 'src/app/models/roca.model';
import { RocaService } from 'src/app/services/roca.service';

@Component({
  selector: 'app-medio',
  templateUrl: './medio.component.html',
  styleUrls: ['./medio.component.css']
})
export class MedioComponent implements OnInit {
  @Output() likeEvent = new EventEmitter<string>();
  rocas: Roca[] | null;

  @Input() filter: string | null;

  constructor(private _rocaService: RocaService) {
    this.rocas = null;
    this.filter = null;

  }

  like() {
    this.likeEvent.emit();
  }
  ngOnInit(): void {
     this._rocaService.getRocaData().subscribe(apiRocas => this.rocas=apiRocas);
  }
}