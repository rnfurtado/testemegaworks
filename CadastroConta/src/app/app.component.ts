import { Component } from '@angular/core';
import {AppService} from './app.service';  
import { FormGroup, FormControl,Validators } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'CadastroConta';

  constructor(private AppService: AppService) { }  
  data: any;  
  CadastroContaForm: FormGroup;  
  submitted = false;   
  EventValue: any = "Cadastrar";  
  
  ngOnInit(): void {  
    this.getdata();  
  
    this.CadastroContaForm = new FormGroup({  
      ContaId: new FormControl(null),  
      Nome: new FormControl("",[Validators.required]),        
      CpfCnpj: new FormControl("",[Validators.required]),  
      BancoId:new FormControl("",[Validators.required]),  
      NumeroConta:new FormControl("",[Validators.required]),  
      NumeroAgencia: new FormControl("",[Validators.required]),  
      DataAbertura: new FormControl("",[Validators.required]),
      Situacao: new FormControl("",[Validators.required]),
    })    
  }  
  getdata() {  
    this.AppService.getData().subscribe((data: any[]) => {  
      this.data = data;  
    })  
  }  
  deleteData(id) {  
    this.AppService.deleteData(id).subscribe((data: any[]) => {  
      this.data = data;  
      this.getdata();  
    })  
  }  
  Cadastrar() {   
    this.submitted = true;  
    
     if (this.CadastroContaForm.invalid) {  
            return;  
     }  
    this.AppService.postData(this.CadastroContaForm.value).subscribe((data: any[]) => {  
      this.data = data;  
      this.resetFrom();
    })  
  }  
  Update() {   
    this.submitted = true;  
    
    if (this.CadastroContaForm.invalid) {  
     return;  
    }        
    this.AppService.putData(this.CadastroContaForm.value.PagamentoId,this.CadastroContaForm.value).subscribe((data: any[]) => {  
      this.data = data;  
      this.resetFrom();  
    })  
  }  
  
  EditData(Data) {  
    this.CadastroContaForm.controls["ContaId"].setValue(Data.ContaId);  
    this.CadastroContaForm.controls["Nome"].setValue(Data.Nome);      
    this.CadastroContaForm.controls["CpfCnpj"].setValue(Data.CpfCnpj);  
    this.CadastroContaForm.controls["BancoId"].setValue(Data.BancoId);  
    this.CadastroContaForm.controls["NumeroConta"].setValue(Data.NumeroConta);  
    this.CadastroContaForm.controls["NumeroAgencia"].setValue(Data.NumeroAgencia);  
    this.CadastroContaForm.controls["DataAbertura"].setValue(Data.DataAbertura);
    this.EventValue = "Atualizar";  
  }  
  
  resetFrom()  
  {     
    this.getdata();  
    this.CadastroContaForm.reset();  
    this.EventValue = "Cadastrar";  
    this.submitted = false;   
  } 
}
