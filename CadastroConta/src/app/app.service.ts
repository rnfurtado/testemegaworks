import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders }    from '@angular/common/http';  

@Injectable({
  providedIn: 'root'
})
export class AppService {
  
  readonly rootURL = 'http://localhost:1168/api';

  constructor(private http: HttpClient) { }  
      httpOptions = {  
        headers: new HttpHeaders({  
          'Content-Type': 'application/json'  
        })  
      }    
      
      getData(){  
        return this.http.get(this.rootURL + '/ContaBancaria'); 
      }  
      
      postData(formData){  
        return this.http.post(this.rootURL + '/ContaBancaria', JSON.stringify(formData));  
      }  
      
      putData(id,formData){  
        return this.http.put(this.rootURL + '/ContaBancaria/'+id,formData);  
      }  
      deleteData(id){  
        return this.http.delete(this.rootURL + '/ContaBancaria/'+id);  
      }  
}