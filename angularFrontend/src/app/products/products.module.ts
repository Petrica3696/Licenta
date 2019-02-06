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
import { ModalModule, ButtonsModule, WavesModule, InputsModule, CollapseModule } from 'angular-bootstrap-md';
import { MatExpansionModule } from '@angular/material/expansion';

import { AllProductsComponent } from './all-products/all-products.component';
import { ProductCardComponent } from './product-card/product-card.component';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { MatNativeDateModule  } from '@angular/material';

import { MyProductsComponent } from './my-products/my-products.component';
import { AddProductComponent } from './add-product/add-product.component';
import { MyProductCardComponent } from './my-product-card/my-product-card.component';
import { MyProductDetailsComponent } from './my-product-details/my-product-details.component';
import { CountdownTimerModule } from 'ngx-countdown-timer';
import { DatePipe } from '@angular/common';
import { SearchPipe } from './_pipes/search.pipe';
import { OrderByPipe } from './_pipes/order-by.pipe';
import { WishlistComponent } from './wishlist/wishlist.component';
import { CommentaryComponent } from './commentary/commentary.component';


@NgModule({
  declarations: [
    AllProductsComponent,
    ProductCardComponent,
    ProductDetailsComponent,
    MyProductsComponent,
    AddProductComponent,
    MyProductCardComponent,
    MyProductDetailsComponent,
    SearchPipe,
    OrderByPipe,
    WishlistComponent,
    CommentaryComponent
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
    MatButtonModule,
    CountdownTimerModule.forRoot(),
    ButtonsModule,
    WavesModule,
    CollapseModule,
    ModalModule,
    InputsModule,
    MatExpansionModule
  ],
  exports: [
    ProductCardComponent
  ],
  providers: [
    MatDatepickerModule,
    DatePipe,
  ]
})
export class ProductsModule { }
