import { Component, OnInit } from '@angular/core';
import { PagoService } from 'src/app/services/pago.service';
import { Pago } from '../models/pago';

@Component({
  selector: 'app-pago-consulta',
  templateUrl: './pago-consulta.component.html',
  styleUrls: ['./pago-consulta.component.css']
})
export class PagoConsultaComponent implements OnInit {
  total: string;
  pagos:Pago[];
  searchText:string;
  constructor(private pagoService: PagoService) { }

  ngOnInit() {
    this.pagoService.get().subscribe(result => {
      this.pagos = result;
      this.AsignarTotal();
    });
    }

    AsignarTotal() {
      var total = 0;
      if (this.searchText == undefined) total = this.TotalizarPagos(this.pagos);
      else {
        var pagos = this.pagos.filter(p=> p.tipo.toLowerCase().indexOf(this.searchText.toLowerCase()) !== -1);
        total = this.TotalizarPagos(pagos);
      }
      this.total = 'COP ' + this.SepararPorComas(total) + '.00';
    }

    TotalizarPagos(pagos: Pago[]) {
      var total = 0;
      pagos.forEach(pago => {
        total += pago.valorPago;
      });
      return total;
    }

    SepararPorComas(valor): any {
      while (/(\d+)(\d{3})/.test(valor.toString())) {
        valor = valor.toString().replace(/(\d+)(\d{3})/, '$1' + ',' + '$2');
      }
      return valor;
    }
}
