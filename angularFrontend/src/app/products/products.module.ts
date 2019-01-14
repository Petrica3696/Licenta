import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AllProductsComponent } from './all-products/all-products.component';
import { ProductCardComponent } from './product-card/product-card.component';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { ProductDetailsComponent } from './product-details/product-details.component';

import { DataService } from '../_services/data.service';


@NgModule({
  declarations: [
    AllProductsComponent,
    ProductCardComponent,
    ProductDetailsComponent
  ],
  imports: [
    CommonModule,
    MDBBootstrapModule.forRoot()
  ],
  providers: [
    DataService
  ]
})
export class ProductsModule { }
