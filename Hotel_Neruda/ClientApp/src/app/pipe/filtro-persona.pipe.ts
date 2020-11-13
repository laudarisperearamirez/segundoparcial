import { Pipe, PipeTransform } from '@angular/core';
import { Pago } from '../hotel_neruda/models/pago';

@Pipe({
  name: 'filtroPersona'
})
export class FiltroPersonaPipe implements PipeTransform {

  transform(pago: Pago[], searchText: string): any {
    if (searchText == null) { return pago; }
    return pago.filter(p => p.identificacion.toLowerCase().indexOf(searchText.toLowerCase()) !== -1||
      p.tipo.indexOf(searchText.toLowerCase()) !== -1);
  }

}
