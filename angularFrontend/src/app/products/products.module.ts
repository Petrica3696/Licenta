import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule }    from '@angular/forms';
import { MatOptionModule } from '@angular/material';
import { MatSelectModule } from '@angular/material';
import { MatFormFieldModule } from '@angular/material';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule  } from '@angular/material/datepicker';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';

import { AllProductsComponent } from './all-products/all-products.component';
import { ProductCardComponent } from './product-card/product-card.component';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { MatNativeDateModule  } from '@angular/material';

import { DataService } from '../_services/data.service';
import { MyProductsComponent } from './my-products/my-products.component';
import { AddProductComponent } from './add-product/add-product.component';
import { MyProductCardComponent } from './my-product-card/my-product-card.component';
import { MyProductDetailsComponent } from './my-product-details/my-product-details.component';


@NgModule({
  declarations: [
    AllProductsComponent,
    ProductCardComponent,
    ProductDetailsComponent,
    MyProductsComponent,
    AddProductComponent,
    MyProductCardComponent,
    MyProductDetailsComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    MatOptionModule,
    MatSelectModule,
    MDBBootstrapModule.forRoot(),
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatButtonModule
  ],
  providers: [
    DataService,
    MatDatepickerModule
  ]
})
export class ProductsModule { }
