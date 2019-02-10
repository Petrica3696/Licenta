import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Product } from 'src/app/_models';
import { Router } from '@angular/router';
import { ProductService, UserService } from 'src/app/_services';

@Component({
  selector: 'app-my-product-card',
  templateUrl: './my-product-card.component.html',
  styleUrls: ['./my-product-card.component.scss']
})
export class MyProductCardComponent implements OnInit {

  @Input() product: Product;
  base64Image
  currentDate: Date = new Date();

  constructor(
    private router: Router,
    private productService: ProductService,
    private userService: UserService
    ) { }

  ngOnInit() {
    this.productService.getProductById(this.product.id).subscribe(product => {
      this.product = product;
      this.currentDate = new Date();
      this.product.deadline = new Date(this.product.deadline);
    });
  }

  onViewDetails() {
    this.router.navigate(['/my-product-details/' + this.product.id]);
  }
}
