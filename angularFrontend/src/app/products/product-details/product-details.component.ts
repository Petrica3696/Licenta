import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ProductService } from '../../_services/product.service';

import { Product } from 'src/app/_models';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  productId: string;
  product: Product;

  constructor(private productService: ProductService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.productId = this.route.snapshot.paramMap.get("id");
    this.productService.getProductById(this.productId).subscribe(product => {this.product = product; console.log("productDest: ", this.product);});
    console.log("destinatie: ", this.productId);
  }

}
