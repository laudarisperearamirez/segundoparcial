import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ClienteConsultaComponent } from './Hotel_Neruda/cliente-consulta/cliente-consulta.component';
import { ClienteRegistroComponent } from './Hotel_Neruda/cliente-registro/cliente-registro.component';
import { PagoRegistroComponent } from './hotel_neruda/pago-registro/pago-registro.component';
import { PagoConsultaComponent } from './hotel_neruda/pago-consulta/pago-consulta.component';



const routes: Routes = [
  {
    path: 'clienteConsulta',
    component: ClienteConsultaComponent
  },
  {
    path: 'clienteRegistro',
    component: ClienteRegistroComponent
  },
  {
    path: 'pagoRegistro',
    component: PagoRegistroComponent
  },
  {
    path: 'pagoConsulta',
    component: PagoConsultaComponent
  }
 
  
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)

  ],
  exports: [RouterModule]

})
export class AppRoutingModule { }
