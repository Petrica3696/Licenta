import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { Product } from '../../_models/product';
import { ProductService } from '../../_services/product.service';

@Component({
  selector: 'app-all-products',
  templateUrl: './all-products.component.html',
  styleUrls: ['./all-products.component.scss']
})
export class AllProductsComponent implements OnInit {
  products: Product[] = [];

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.productService.getAll().pipe(first()).subscribe(products => {
      this.products = products;
      console.log(products);
    });
  }

}