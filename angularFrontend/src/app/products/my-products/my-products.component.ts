import { Component, OnInit } from '@angular/core';

import { ProductService } from '../../_services/product.service';
import { Product } from 'src/app/_models';
import { SortOrder } from 'src/app/_models/sortOrder';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-my-products',
  templateUrl: './my-products.component.html',
  styleUrls: ['./my-products.component.scss']
})
export class MyProductsComponent implements OnInit {

  username: string;
  myProducts: Product[];
  inputSearch: string = '';
  sortOrder: SortOrder;

  dropdownFormControl = new FormControl('', [Validators.nullValidator]);
  orderModel: SortOrder[] = [new SortOrder('name', 'asc', 'Name ascending'),
                                new SortOrder('name', 'desc', 'Name descending'),
                                new SortOrder('finalPrice', 'asc', 'Current Price ascending'),
                                new SortOrder('finalPrice', 'desc', 'Current Price descending'),
                                new SortOrder('deadline', 'asc', 'Date ascending'),
                                new SortOrder('deadline', 'desc', 'Date descending')
                              ];

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.username = JSON.parse(localStorage.getItem("currentUser")).username;
    this.productService.getAllMyProducts(this.username).subscribe(products => this.myProducts = products);
    this.sortOrder = new SortOrder("name", "asc", "Name ascending");
  }

  onInputChange(inputSearch) {
    this.inputSearch = inputSearch;
  }

  onOrderChange(sortOrder) {
    this.sortOrder = sortOrder;
  }
}
