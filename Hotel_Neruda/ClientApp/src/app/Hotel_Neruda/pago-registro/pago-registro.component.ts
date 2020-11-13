import { Route } from '@angular/compiler/src/core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from 'src/app/@base/alert-modal/alert-modal.component';
import { ClienteService } from 'src/app/services/cliente.service';
import { PagoService } from 'src/app/services/pago.service';
import { Pago } from '../models/pago';

@Component({
  selector: 'app-pago-registro',
  templateUrl: './pago-registro.component.html',
  styleUrls: ['./pago-registro.component.css']
})
export class PagoRegistroComponent implements OnInit {

  pago:Pago;
  clienteR:boolean=false;
  formGroup: FormGroup;
  idn: string;
  
  constructor(private router: Router,private pagoService:PagoService,private modalService: NgbModal,private clienteService:ClienteService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.buildForm();
    this.esconderDiv();
  }
  private buildForm() {
    this.pago = new Pago();
    this.pago.codigo='';
    this.pago.identificacion = '';
    this.pago.tipo = '';
    this.pago.valorPago = 0.0;
    this.pago.valorIva = 0.0;
    this.pago.fecha = new Date();
    this.formGroup = this.formBuilder.group({
      codigo:[this.pago.codigo, Validators.required],
    identificacion: [this.pago.identificacion, Validators.required],
    tipo: [this.pago.tipo, Validators.required],
    valorPago: [this.pago.valorPago, [Validators.required]],
    valorIva: [this.pago.valorIva, [Validators.required]],
    fecha: [this.pago.fecha, Validators.required],
    
    });
    }
    esconderDiv(){    
      this.clienteR=false;    
    }
    get control() {
      return this.formGroup.controls;
       }
       add(){
        this.pago = this.formGroup.value;
        this.pagoService.post(this.pago).subscribe(p=>{
          if(p!=null){
            alert("Registro Exitoso")
           
            this.pago=p;
          }
        })
      }
      get f(){return this.formGroup.controls;}
      buscarIde(){
        this.clienteService.getId(this.formGroup.value.identificacion).subscribe(p=>{
          if(p!=null){
            var ide=p.identificacion;
            this.f['identificacion'].setValue(p.identificacion);
            alert("la persona existe en nuestra base de datos");
          }else{
            if(confirm('¿la persona no existe, desea registrar la persona identificacion ' + this.formGroup.value.identificacion + '?')){
              this.router.navigate(['/', 'clienteRegistro']);
            }
          }
      });}

       onSubmit(){
        if(this.formGroup.invalid){
          return;
        }
        
        this.add();
      }
      
      
}
