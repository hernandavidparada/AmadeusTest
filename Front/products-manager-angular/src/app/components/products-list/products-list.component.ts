import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductsService } from 'src/app/services/products/products.service';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})
export class ProductsListComponent implements OnInit {

  tittle=["ID","Name", "Type", "Description", "Entry Date", "Cost", "Units", "Store Number", "Dispatcher","Edit", "Delete"];
  data: any =[ ];
  search=false;

  constructor(
    private http: HttpClient,
    private productsService: ProductsService,
    private router: Router
  ) {
    
  }

  async ngOnInit() {
    this.data = await this.productsService.getProducts();
    this.search=true;
  }

  

  create(){
    this.router.navigate(['/productscreate']);
  }

  Edit(){

  }

  async Delete(id:number){
    let response:any;
      response = await this.productsService.deleteProduct(id);
      console.log(response);
      if(response=='1'){
        this.data = await this.productsService.getProducts();
      }
  }


}
