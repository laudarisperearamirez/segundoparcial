import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ClienteConsultaComponent } from './Hotel_Neruda/cliente-consulta/cliente-consulta.component';
import { ClienteRegistroComponent } from './Hotel_Neruda/cliente-registro/cliente-registro.component';



const routes: Routes = [
  {
    path: 'clienteConsulta',
    component: ClienteConsultaComponent
  },
  {
    path: 'clienteRegistro',
    component: ClienteRegistroComponent
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
