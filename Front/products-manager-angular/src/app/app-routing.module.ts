import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsListComponent } from './components/products-list/products-list.component';
import { ProductsCreateComponent } from './components/products-create/products-create.component';

const routes: Routes = [

  { path: 'productscreate', component: ProductsCreateComponent },
  { path: 'productslist', component: ProductsListComponent },
  { path: '**', redirectTo: 'productslist' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
