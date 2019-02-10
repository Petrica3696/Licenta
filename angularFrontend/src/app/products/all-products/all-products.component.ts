import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { interval } from "rxjs/internal/observable/interval";
import { startWith, switchMap } from "rxjs/operators";

import { Product } from '../../_models/product';
import { ProductService } from '../../_services/product.service';
import { User } from 'src/app/_models';
import { FormControl, Validators } from '@angular/forms';
import { SortOrder } from 'src/app/_models/sortOrder';
import { UserService } from 'src/app/_services';

@Component({
  selector: 'app-all-products',
  templateUrl: './all-products.component.html',
  styleUrls: ['./all-products.component.scss']
})
export class AllProductsComponent implements OnInit {
  products: Product[] = [];
  user: User = JSON.parse(localStorage.getItem("currentUser"));
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

  constructor(private productService: ProductService, private userCredentialsService: UserService) { }

  ngOnInit() {

    this.productService.getAll(this.user.username).pipe(first()).subscribe(products => {
      this.products = products;
      console.log(products.length);
    });

    this.sortOrder = new SortOrder("name", "asc", "Name ascending");
  }

  onInputChange(inputSearch) {
    this.inputSearch = inputSearch;
  }

  onOrderChange(sortOrder) {
    this.sortOrder = sortOrder;
  }

}