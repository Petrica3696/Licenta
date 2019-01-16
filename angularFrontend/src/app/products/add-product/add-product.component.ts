import { Component, OnInit } from '@angular/core';
import { ToastrManager } from 'ng6-toastr-notifications';
import { Router } from '@angular/router';

import { CategoryService } from '../../_services/categories.service';
import { ProductService } from '../../_services/product.service';

import { Category } from 'src/app/_models/category';
import { ProductWrite } from '../../_models/productWrite';
import { FormControl, Validators } from '@angular/forms';
import { User } from 'src/app/_models';


@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.scss']
})
export class AddProductComponent implements OnInit {

  categories: Category[] = [];
  newProduct: ProductWrite = new ProductWrite;

  inputCategory: string;
  inputName: string;
  inputPrice: number;
  inputDate: Date;
  inputDescription: string;
  buttonValue: boolean = true;
  user: User = JSON.parse(localStorage.getItem('currentUser'));

  constructor(private categoryService: CategoryService, private productService: ProductService, public toastr: ToastrManager, private router: Router) { }

  dropdownFormControl = new FormControl('', [Validators.required]);
  inputNameFormControl = new FormControl('', [Validators.required]);
  inputPriceFormControl = new FormControl('', [Validators.required]);
  inputDateFormControl = new FormControl('', [Validators.required]);
  inputDescriptionFormControl = new FormControl('', [Validators.required]);

  ngOnInit() {
    this.categoryService.getAll().subscribe(categories => this.categories = categories);
  }

  onCategoryChange(inputCategory) {
    this.inputCategory = inputCategory;
    this.verifyAllFilled();
  }

  onNameChange(inputName) {
    this.inputName = inputName;
    this.verifyAllFilled();
  }

  onPriceChange(inputPrice) {
    this.inputPrice = inputPrice;
    this.verifyAllFilled();
  }

  onDateChange(inputDate) {
    this.inputDate = inputDate;
    this.verifyAllFilled();
  }

  onDescriptionChange(inputDescription) {
    this.inputDescription = inputDescription;
    this.verifyAllFilled();
  }

  verifyAllFilled() {
    if (this.dropdownFormControl.status == 'VALID'
      && this.inputNameFormControl.status == 'VALID'
      && this.inputPriceFormControl.status == 'VALID'
      && this.inputDateFormControl.status == 'VALID'
      && this.inputDescriptionFormControl.status == 'VALID') this.buttonValue = false;
    else this.buttonValue = true;
  }

  onSubmit() {
    this.categories.forEach(category => {
      if (category.name == this.inputCategory) {
        this.newProduct.categoryId = category.id;
      }
    });
    this.newProduct.username = this.user.username;
    this.newProduct.name = this.inputName;
    this.newProduct.description = this.inputDescription;
    this.newProduct.startPrice = this.inputPrice;
    this.newProduct.deadline = this.inputDate;

    this.productService.addProduct(this.newProduct).then(result => {
      this.toastr.successToastr('', "The product was successfuly added!");
      this.router.navigate(["my-products"]);
    }).catch(err => {
      this.toastr.errorToastr('', "There was an issue when adding product. Please try again");
    });
  }

}
