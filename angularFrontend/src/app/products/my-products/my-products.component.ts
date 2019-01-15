import { Component, OnInit } from '@angular/core';

import { ProductService } from '../../_services/product.service';
import { Product } from 'src/app/_models';

@Component({
  selector: 'app-my-products',
  templateUrl: './my-products.component.html',
  styleUrls: ['./my-products.component.scss']
})
export class MyProductsComponent implements OnInit {

  username: string;
  myProducts: Product[];

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.username = JSON.parse(localStorage.getItem("currentUser")).username;
    this.productService.getAllMyProducts(this.username).subscribe(products => {this.myProducts = products; console.log(this.myProducts)});
  }

}
