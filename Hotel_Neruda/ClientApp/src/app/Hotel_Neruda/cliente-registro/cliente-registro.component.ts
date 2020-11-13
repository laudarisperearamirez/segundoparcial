import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import{ClienteService}from'./../../services/cliente.service';
import{Cliente}from'./../models/cliente';

@Component({
  selector: 'app-cliente-registro',
  templateUrl: './cliente-registro.component.html',
  styleUrls: ['./cliente-registro.component.css']
})
export class ClienteRegistroComponent implements OnInit {
cliente:Cliente;
  constructor(private router: Router,private clienteService:ClienteService) { }

  ngOnInit() {
    this.cliente= new Cliente;
  }
  add(){
    this.clienteService.post(this.cliente).subscribe(p => {

      if (p != null) {
      
        if(confirm('La persona fue registrada exitosamente')){
          this.router.navigate(['/', 'pagoRegistro']);
        }
      
      this.cliente = p;
      
      }
      
      });
  }
}
