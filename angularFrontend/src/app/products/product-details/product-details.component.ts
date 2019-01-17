import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ProductService } from '../../_services/product.service';

import { Product, User } from 'src/app/_models';
import { ToastrManager } from 'ng6-toastr-notifications';
import { ProductBid } from 'src/app/_models/productBid';
import { UserService } from 'src/app/_services';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  productId: string;
  product: Product;
  buttonToggle: boolean = true;
  placedBid: number;
  productBid: ProductBid = new ProductBid;
  userDetails: User;

  constructor(private productService: ProductService, private route: ActivatedRoute, public toastr: ToastrManager, private userCredentialsService: UserService, private changeDetectorRef: ChangeDetectorRef) { }

  ngOnInit() {
    this.productId = this.route.snapshot.paramMap.get("id");
    this.productService.getProductById(this.productId).subscribe(product => this.product = product);
    this.userCredentialsService.getUserCredentials().subscribe(
      userDetails => {
          this.userDetails = userDetails;
          this.changeDetectorRef.detectChanges();
      }
  );
  }

  onPriceChange(placedBid) {
    this.placedBid = placedBid;
    this.productService.getProductById(this.productId).subscribe(product => {
      this.product = product;
      if(this.product.finalPrice < this.placedBid) { this.buttonToggle = false; }
      else { this.buttonToggle = true; }
    });
  }

  onSubmit() {
    this.productService.getProductById(this.productId).subscribe(product => {
      this.product = product;
      if(this.product.finalPrice < this.placedBid) { 
        this.buttonToggle = false;
        this.productBid.finalPrice = this.placedBid;
        this.productBid.winnerId = this.userDetails.id.toString();
        this.productService.bidProduct(this.product.id, this.productBid).then(result => {
          this.toastr.successToastr('', "Bid success!");
          product.finalPrice = this.placedBid;
        }).catch(err => {
          this.toastr.errorToastr('', "Bid error. Please try again");
        });

      }
      else { 
        this.buttonToggle = true;
        this.toastr.errorToastr('', "Somebody aleady place that amount");
       }
    });
  }

}
