import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, Validators } from '@angular/forms';
import { ToastrManager } from 'ng6-toastr-notifications';

import { CategoryService } from '../../_services/categories.service';
import { ProductService } from '../../_services/product.service';

import { Category } from 'src/app/_models/category';
import { ProductWrite } from '../../_models/productWrite';
import { User } from 'src/app/_models';


@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.scss']
})
export class AddProductComponent implements OnInit {

  categories: Category[] = [];
  newProduct: ProductWrite = new ProductWrite;

  minDate = new Date();
  enableTimer: boolean = true;

  inputCategory: string;
  inputName: string;
  inputPrice: number;
  inputDate: Date;
  inputDescription: string;
  buttonValue: boolean = true;
  inputHours: number;
  inputMinutes: number;
  user: User = JSON.parse(localStorage.getItem('currentUser'));

  constructor(private categoryService: CategoryService, private productService: ProductService, public toastr: ToastrManager, private router: Router) { }

  dropdownFormControl = new FormControl('', [Validators.required]);
  inputNameFormControl = new FormControl('', [Validators.required]);
  inputPriceFormControl = new FormControl('', [Validators.required, Validators.min(1)]);
  inputDateFormControl = new FormControl('', [Validators.required]);
  inputDescriptionFormControl = new FormControl('', [Validators.required]);
  inputHoursFormControl = new FormControl({ value: '0', disabled: this.enableTimer }, [Validators.required, Validators.min(0), Validators.max(23)]);
  inputMinutesFormControl = new FormControl({ value: '0', disabled: this.enableTimer }, [Validators.required, Validators.min(0), Validators.max(59)]);

  ngOnInit() {
    this.categoryService.getAll().subscribe(categories => this.categories = categories);
    this.minDate.setDate(this.minDate.getDate());
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
    if (this.inputDateFormControl.status == 'VALID') { 
      this.inputHoursFormControl.enable();
      this.inputMinutesFormControl.enable();
      this.inputHours = 0;
      this.inputMinutes = 0;
      console.log("inDate: ", this.inputDate);
    }
    else { 
      this.inputHoursFormControl.disable();
      this.inputMinutesFormControl.disable();
      this.inputHours = null;
      this.inputMinutes = null;
    }
    this.verifyAllFilled();
  }

  onHoursChange(inputHours) {
      this.inputHours = inputHours;
      if (inputHours) {
        this.inputDate.setHours(inputHours + 2);
        this.inputDate.setSeconds(0);
        console.log(this.inputDate);
      }
      this.verifyAllFilled();
  }
  onMinutesChange(inputMinutes) {
    if (this.inputMinutesFormControl.status == 'VALID') {
      this.inputMinutes = inputMinutes;
      if(inputMinutes) {
        this.inputDate.setMinutes(this.inputMinutes);
      }
      console.log(this.inputDate);
    }
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
      && this.inputDescriptionFormControl.status == 'VALID'
      && this.inputHoursFormControl.status == 'VALID'
      && this.inputMinutesFormControl.status == 'VALID') {
      this.buttonValue = false;
    }
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
