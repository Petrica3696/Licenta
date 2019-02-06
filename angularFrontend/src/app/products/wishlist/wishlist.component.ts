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
  selector: 'app-wishlist',
  templateUrl: './wishlist.component.html',
  styleUrls: ['./wishlist.component.scss']
})
export class WishlistComponent implements OnInit {
  products: Product[] = [];
  user: User = JSON.parse(localStorage.getItem("currentUser"));
  inputSearch: string = '';
  sortOrder: SortOrder;
  userDetails: User;

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

    this.userCredentialsService.getUserCredentials().subscribe(
      userDetails => {
        this.userDetails = userDetails;
        this.productService.getWishlistProducts(this.userDetails.id.toString()).pipe(first()).subscribe(products => {
          this.products = products;
          console.log("Products: ", products);
        });
      }
    );

    this.sortOrder = new SortOrder("name", "asc", "Name ascending");
  }

  onInputChange(inputSearch) {
    this.inputSearch = inputSearch;
  }

  onOrderChange(sortOrder) {
    this.sortOrder = sortOrder;
  }

}