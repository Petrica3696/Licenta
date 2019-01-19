import { Component, OnInit, Input, ChangeDetectionStrategy, ChangeDetectorRef } from '@angular/core';
import { Product, ProductEdit, User } from 'src/app/_models';
import { DataService } from '../../_services/data.service';
import { ProductService, UserService } from 'src/app/_services';
import { ToastrManager } from 'ng6-toastr-notifications';
import { ProductBid } from 'src/app/_models/productBid';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.scss']
})
export class ProductCardComponent implements OnInit {

  userDetails: User;
  toggleButton: boolean = false;
  productQuickBid: ProductBid = new ProductBid;
  currentDate: Date = new Date();
  lastMinute: Date = new Date();

  @Input() product: Product;

  constructor(private dataService: DataService, private productService: ProductService, private datePipe: DatePipe, private userCredentialsService: UserService, private changeDetectorRef: ChangeDetectorRef, public toastr: ToastrManager) { }

  ngOnInit() {
    this.userCredentialsService.getUserCredentials().subscribe(
      userDetails => {
        this.userDetails = userDetails;
        this.changeDetectorRef.detectChanges();
      }
    );

    this.product.deadline = new Date(this.product.deadline);
    if (this.product.deadline > this.currentDate) {
      this.toggleButton = false;
    }
    else {
      this.toggleButton = true;
    }
  }

  onQuickBid() {

    this.productService.getProductById(this.product.id).subscribe(product => {

      if (product.finalPrice != this.product.finalPrice) {
        this.product.finalPrice = product.finalPrice;
        this.toastr.errorToastr('', "Somebody aleady place that amount");
        this.product.deadline = product.deadline;
      }
      else {
        this.product.deadline = new Date(product.deadline);
        console.log("product-deadline: ", product.deadline);
        this.currentDate = new Date();
        this.lastMinute = new Date();
        if (this.product.deadline > this.currentDate) {
          this.toggleButton = false;

          if (this.product.finalPrice == 0) {
            this.product.finalPrice = this.product.startPrice;
            this.productQuickBid.finalPrice = this.product.finalPrice;
  
          }
          else {
            this.product.finalPrice++;
            this.productQuickBid.finalPrice = this.product.finalPrice;
          }
          this.productQuickBid.winnerId = this.userDetails.id.toString();
          

          this.lastMinute.setMinutes(this.lastMinute.getMinutes() + 1);
          if(this.lastMinute > this.product.deadline) {
            this.productQuickBid.deadline = new Date();
            this.productQuickBid.deadline.setMinutes(this.productQuickBid.deadline.getMinutes() + 1);
            this.product.deadline = this.lastMinute;
            
            this.productQuickBid.deadline.setHours(this.productQuickBid.deadline.getHours() + 2);
          }
          console.log(new Date(), ' ', this.productQuickBid.deadline);
          
          this.productService.bidProduct(this.product.id, this.productQuickBid).then(result => {
            this.toastr.successToastr('', "Bid success!");
          }).catch(err => {
            this.toastr.errorToastr('', "Bid error. Please try again");
          });
  
        }
        else {
          this.toggleButton = true;
          this.toastr.infoToastr('', "This auction has ended!");
          return;
        }
      }

    });
  }

  onRefresh() {
    this.productService.getProductById(this.product.id).subscribe(product => this.product = product);
  }
}
