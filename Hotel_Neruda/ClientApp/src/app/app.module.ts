import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import{ClienteService}from'./services/cliente.service';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ClienteRegistroComponent } from './Hotel_Neruda/cliente-registro/cliente-registro.component';
import { ClienteConsultaComponent } from './Hotel_Neruda/cliente-consulta/cliente-consulta.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { PagoConsultaComponent } from './hotel_neruda/pago-consulta/pago-consulta.component';
import { PagoRegistroComponent } from './hotel_neruda/pago-registro/pago-registro.component';
import { AlertModalComponent } from './@base/alert-modal/alert-modal.component';
import { FiltroPersonaPipe } from './pipe/filtro-persona.pipe';
import { CommonModule } from '@angular/common';
@NgModule({
  declarations: [
    AppComponent,
    AlertModalComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ClienteRegistroComponent,
    ClienteConsultaComponent,
    HeaderComponent,
    FooterComponent,
    PagoConsultaComponent,
    PagoRegistroComponent,
    FiltroPersonaPipe
  ],
  imports: [
    NgbModule,
    ReactiveFormsModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    CommonModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
    ]),
    AppRoutingModule
  ],
  providers: [ClienteService],
  bootstrap: [AppComponent]
})
export class AppModule { }
