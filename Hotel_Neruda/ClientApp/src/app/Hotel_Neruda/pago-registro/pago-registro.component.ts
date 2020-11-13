import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PagoService } from 'src/app/services/pago.service';
import { Pago } from '../models/pago';

@Component({
  selector: 'app-pago-registro',
  templateUrl: './pago-registro.component.html',
  styleUrls: ['./pago-registro.component.css']
})
export class PagoRegistroComponent implements OnInit {

  pago:Pago;
  formGroup: FormGroup;
  constructor(private pagoService:PagoService,private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.buildForm();
  }
  private buildForm() {
    this.pago = new Pago();
    this.pago.codigo='';
    this.pago.identificacion = '';
    this.pago.tipoPago = '';
    this.pago.valorPago = 0.0;
    this.pago.valorIva = 0.0;
    this.formGroup = this.formBuilder.group({
      codigo:[this.pago.codigo, Validators.required],
    identificacion: [this.pago.identificacion, Validators.required],
    tipoPago: [this.pago.tipoPago, Validators.required],
    valorPago: [this.pago.valorPago, [Validators.required]],
    valorIva: [this.pago.valorIva, [Validators.required]],
    
    });
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
      buscarIde(){
        
      }

       onSubmit(){
        if(this.formGroup.invalid){
          return;
        }
        
        this.add();
      }
}
