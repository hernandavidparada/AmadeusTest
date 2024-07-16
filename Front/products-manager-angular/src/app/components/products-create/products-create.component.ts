import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup, Validators  } from '@angular/forms';
import { ProductsService } from 'src/app/services/products/products.service';
import { Product } from 'src/app/models/product';
import { Router } from '@angular/router';

@Component({
  selector: 'app-products-create',
  templateUrl: './products-create.component.html',
  styleUrls: ['./products-create.component.css']
})
export class ProductsCreateComponent {

  productEditForm!: FormGroup;
  result!: string;

  constructor(
    private http: HttpClient,
    private productsService: ProductsService,
    private router: Router
  ) {
    this.buildForm();
  }

  ngOnInit(){

  }

  private buildForm() {
    this.productEditForm = new FormGroup({
      name: new FormControl('', [Validators.required]),
      type: new FormControl('', [Validators.required]),
      descrip: new FormControl('', [Validators.required]),
      date: new FormControl('', [Validators.required]),
      units: new FormControl('', [Validators.required]),
      cost: new FormControl('', [Validators.required]),
      storeNumber: new FormControl('', [Validators.required]),
      dispatcher: new FormControl('', [Validators.required])
    })
  }


  async save(){

    if (this.productEditForm.valid){

      var newProduct: Product = {
        Name: this.productEditForm.controls["name"].value,
        Type: this.productEditForm.controls["type"].value,
        Description: this.productEditForm.controls["descrip"].value,
        EntryDate: this.productEditForm.controls["date"].value,
        Cost: this.productEditForm.controls["cost"].value,
        Units: this.productEditForm.controls["units"].value,
        StoreNumber: this.productEditForm.controls["storeNumber"].value,
        Dispatcher: this.productEditForm.controls["dispatcher"].value,
      };
  
      let response:any;
      response = await this.productsService.createProduct(newProduct);
      console.log(response);
      if(response=='1'){
        this.result = "Saved!";
        this.router.navigate(['/productslist']);
      }else{
        this.result = "Error";
      }
      
    }
      
    else
      this.result = "Errors in the form";
   

    
  }


  cancel(){
    this.router.navigate(['/productslist']);
  }

}
