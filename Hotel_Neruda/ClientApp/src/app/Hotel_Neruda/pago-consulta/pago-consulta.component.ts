import { Component, OnInit } from '@angular/core';
import { PagoService } from 'src/app/services/pago.service';
import { Pago } from '../models/pago';

@Component({
  selector: 'app-pago-consulta',
  templateUrl: './pago-consulta.component.html',
  styleUrls: ['./pago-consulta.component.css']
})
export class PagoConsultaComponent implements OnInit {

  pagos:Pago[];
  searchText:string;
  constructor(private pagoService: PagoService) { }

  ngOnInit() {
    this.pagoService.get().subscribe(result => {
      this.pagos = result;
    });

  }
  buscar(id: string):void{
    if(id!=""){
      
    }

  }

}
