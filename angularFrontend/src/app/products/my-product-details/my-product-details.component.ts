import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, Validators, ValidatorFn, AbstractControl } from '@angular/forms';
import { ToastrManager } from 'ng6-toastr-notifications';

import { ProductService } from '../../_services/product.service';
import { CategoryService } from '../../_services/categories.service';

import { Product, ProductEdit, Category } from 'src/app/_models';

@Component({
  selector: 'app-my-product-details',
  templateUrl: './my-product-details.component.html',
  styleUrls: ['./my-product-details.component.scss']
})
export class MyProductDetailsComponent implements OnInit {

  productId: string;
  product: Product;
  category: Category;
  categories: Category[] = [];
  newProduct: ProductEdit = new ProductEdit;

  inputCategory: string = null;
  inputName: string = null;
  inputPrice: number = null;
  inputDate: Date = null;
  inputDescription: string = null;
  buttonValue: boolean = true;

  constructor(private categoryService: CategoryService, private productService: ProductService, private route: ActivatedRoute, public toastr: ToastrManager, private router: Router) { }

  ngOnInit() {
    this.productId = this.route.snapshot.paramMap.get("id");
    this.productService.getProductById(this.productId).subscribe(product => {
      this.product = product;
      this.categoryService.getCategoryById(this.product.categoryId).subscribe(category => this.category = category);
    });
    this.categoryService.getAll().subscribe(categories => this.categories = categories);
  }

  onCategoryChange(inputCategory) {
    this.inputCategory = inputCategory;
    this.isAnyFieldChanged();
  }

  onNameChange(inputName) {
    this.inputName = inputName;
    this.isAnyFieldChanged();
  }

  onPriceChange(inputPrice) {
    this.inputPrice = inputPrice;
    this.isAnyFieldChanged();
  }

  onDateChange(inputDate) {
    this.inputDate = inputDate;
    this.isAnyFieldChanged();
  }

  onDescriptionChange(inputDescription) {
    this.inputDescription = inputDescription;
    this.isAnyFieldChanged();
  }

  isAnyFieldChanged() {
    if ((this.inputCategory !== null)
      || (this.inputName !== null && this.inputName.trim() !== '')
      || (this.inputPrice != null)
      || (this.inputDate != null)
      || (this.inputDescription != null && this.inputDescription.trim() !== '')) {
      this.buttonValue = false;
    }
    else {
      this.buttonValue = true;
    }
  }

  onSubmit() {
    this.categories.forEach(category => {
      if (category.name == this.inputCategory) {
        this.newProduct.categoryId = category.id;
      }
    });
    if (this.newProduct.categoryId == null) { this.newProduct.categoryId = this.product.categoryId };
    this.inputName ? this.newProduct.name = this.inputName : this.newProduct.name = this.product.name;
    this.inputDescription ? this.newProduct.description = this.inputDescription : this.newProduct.description = this.product.description;
    (this.inputPrice && this.inputPrice > this.product.startPrice) ? this.newProduct.startPrice = this.inputPrice : this.newProduct.startPrice = this.product.startPrice;
    this.inputDate ? this.newProduct.deadline = this.inputDate : this.newProduct.deadline = this.product.deadline;

    this.productService.updateProduct(this.productId, this.newProduct).then(result => {
      this.toastr.successToastr('', "The product was successfuly edited!");
      this.router.navigate(["my-products"]);
    }).catch(err => {
      this.toastr.errorToastr('', "There was an issue when adding product. Please try again");
    });
  }

}
