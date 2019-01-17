import { Component, OnInit, Input, ChangeDetectionStrategy, ChangeDetectorRef } from '@angular/core';
import { Product, ProductEdit, User } from 'src/app/_models';
import { DataService } from '../../_services/data.service';
import { ProductService, UserService } from 'src/app/_services';
import { ToastrManager } from 'ng6-toastr-notifications';
import { ProductBid } from 'src/app/_models/productBid';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.scss']
})
export class ProductCardComponent implements OnInit {

  @Input() product: Product;
  userDetails: User;

  productQuickBid: ProductBid = new ProductBid;

  constructor(private dataService: DataService, private productService: ProductService, private userCredentialsService: UserService, private changeDetectorRef: ChangeDetectorRef, public toastr: ToastrManager) { }

  ngOnInit() {
    this.userCredentialsService.getUserCredentials().subscribe(
      userDetails => {
          this.userDetails = userDetails;
          this.changeDetectorRef.detectChanges();
      }
  );
  }

  onSendProduct(product) {
    this.dataService.changeProduct(product);
  }

  onQuickBid() {

    this.productService.getProductById(this.product.id).subscribe(product => {
      if(product.finalPrice != this.product.finalPrice) {
        this.product.finalPrice = product.finalPrice;
        this.toastr.errorToastr('', "Somebody aleady place that amount");
      }
      else {
        
        if (this.product.finalPrice == 0) {
          this.product.finalPrice = this.product.startPrice;
          this.productQuickBid.finalPrice = this.product.finalPrice;
          
        }
        else {
          this.product.finalPrice ++;
          this.productQuickBid.finalPrice = this.product.finalPrice;
        }
        this.productQuickBid.winnerId = this.userDetails.id.toString();
    
        this.productService.bidProduct(this.product.id, this.productQuickBid).then(result => {
          this.toastr.successToastr('', "Bid success!");
        }).catch(err => {
          this.toastr.errorToastr('', "Bid error. Please try again");
        });

      }
  
    });
  }

}
