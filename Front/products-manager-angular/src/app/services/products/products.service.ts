import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  constructor(private http: HttpClient) { }


  getProducts(){
    return new Promise(async (resolve, reject) => {
      this.http.get<any>('http://localhost:40785/api/Products').subscribe({

        next: data =>{                   
          
          if (data) {
            resolve(data);
          } else {
            reject();
          }
        },
        error: error =>{
          console.log(error);
        }        
      })
     })
   }



  createProduct(prod: Product){

    let parameters = 
      {
        "name": prod.Name,
        "type": prod.Type,
        "description":  prod.Description,
        "entryDate": prod.EntryDate,
        "cost": Number(prod.Cost),
        "units": Number(prod.Units),
        "storeNumber": Number(prod.StoreNumber),
        "dispatcher": prod.Dispatcher
      } ;


    return new Promise(async (resolve, reject) => {
      this.http.post<any>('http://localhost:40785/api/Products',parameters).subscribe({

        next: data =>{          
          console.log(data);
          
          if (data) {
            resolve(data);
          } else {
            reject();
          }
        },
        error: error =>{
          console.log(error);
        }        
      })
    })
  }


  deleteProduct(prod: number){

    
    return new Promise(async (resolve, reject) => {
      this.http.delete<any>('http://localhost:40785/api/Products?id='+prod).subscribe({

        next: data =>{          
          console.log(data);
          
          if (data) {
            resolve(data);
          } else {
            reject();
          }
        },
        error: error =>{
          console.log(error);
        }        
      })
    })
  }



}
