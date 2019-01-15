import { Component, OnInit } from '@angular/core';

import { CategoryService } from '../../_services/categories.service';
import { Category } from 'src/app/_models/category';
import { FormControl, Validators } from '@angular/forms';


@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.scss']
})
export class AddProductComponent implements OnInit {

  categories: Category[] = [];

  inputName : string;

  constructor(private categoryService: CategoryService) { }

  dropdownFormControl = new FormControl('', [Validators.required]);
  inputNameFormControl = new FormControl('', [Validators.required]);
  inputPriceFormControl = new FormControl('', [Validators.required]);
  inputDateFormControl = new FormControl('', [Validators.required]);
  inputDescriptionFormControl = new FormControl('', [Validators.required]);

  ngOnInit() {
    this.categoryService.getAll().subscribe(categories => this.categories = categories);
  }

  onModelChange(inputName) {
    this.inputName=inputName;
    console.log(this.inputNameFormControl.status);
  }

  onSubmit() {
    
  }

}
