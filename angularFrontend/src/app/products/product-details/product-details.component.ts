import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { ProductService } from '../../_services/product.service';

import { Product, User, Comment } from 'src/app/_models';
import { ToastrManager } from 'ng6-toastr-notifications';
import { ProductBid } from 'src/app/_models/productBid';
import { UserService } from 'src/app/_services';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {

  productId: string;
  product: Product;
  buttonToggle: boolean = true;
  disableInput: boolean = false;
  disableSave: boolean = true;
  placedBid: number;
  productBid: ProductBid = new ProductBid;
  userDetails: User;
  sellerDetails: User = new User;
  lastMinute: Date = new Date();
  commentInfo: Comment = new Comment;
  comments: Comment[] = [];

  constructor(
    private productService: ProductService,
    private route: ActivatedRoute,
    public toastr: ToastrManager,
    private router: Router,
    private userService: UserService) { }

  inputComment: string;
  inputDescriptionFormControl = new FormControl('', [Validators.nullValidator]);
  ratingFormControl = new FormControl('', [Validators.required, Validators.min(1), Validators.max(10)])
  inputRating: number = 0;

  ngOnInit() {
    this.productId = this.route.snapshot.paramMap.get("id");

    this.productService.getProductById(this.productId).subscribe(
      product => {
        this.product = product;
        if (new Date(this.product.deadline) <= new Date()) {
          this.disableInput = true;
          this.buttonToggle = true;
        }
        //get seller details
        this.userService.getByUsername(this.product.username).subscribe(
          sellerDetails => {
            this.sellerDetails = sellerDetails;
          }
        );

        //get comments for this specific product
        this.productService.getComments(product.id).subscribe(
          comments => { this.comments = comments; console.log(comments); console.log("length: ", comments.length) }
        );
      });

    this.userService.getUserCredentials().subscribe(
      userDetails => {
        this.userDetails = userDetails;
      }
    );
  }

  onPriceChange(placedBid) {
    this.placedBid = placedBid;
    this.productService.getProductById(this.productId).subscribe(product => {
      this.product = product;
      if (this.product.finalPrice < this.placedBid) { this.buttonToggle = false; }
      else { this.buttonToggle = true; }
    });
  }

  onSubmit() {
    this.productService.getProductById(this.productId).subscribe(product => {
      this.product = product;
      if (new Date(this.product.deadline) <= new Date()) {
        this.disableInput = true;
        this.buttonToggle = true;

        if(this.userDetails.id.toString() != this.product.winnerId) {
          this.router.navigate(['/wishlist']);
          this.toastr.infoToastr('', "Unfortunately, you lose this auction!");
        }
        else {
          this.toastr.successToastr('', "Congratulations! You won this auction!");
        }

        return;
      }
      if (this.product.finalPrice < this.placedBid) {
        this.buttonToggle = false;
        this.productBid.finalPrice = this.placedBid;
        this.productBid.winnerId = this.userDetails.id.toString();
        this.product.deadline = new Date(product.deadline);

        this.lastMinute = new Date();
        this.lastMinute.setMinutes(this.lastMinute.getMinutes() + 1);
        if (this.lastMinute > this.product.deadline) {
          this.productBid.deadline = new Date();
          this.productBid.deadline.setMinutes(this.productBid.deadline.getMinutes() + 1);
          this.product.deadline = this.lastMinute;

          this.productBid.deadline.setHours(this.productBid.deadline.getHours() + 2);
        }

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

  onRefresh() {
    this.productService.getProductById(this.product.id).subscribe(product => {
      this.product = product;
      if (new Date(this.product.deadline) <= new Date()) {
        this.disableInput = true;
        this.buttonToggle = true;

        if(this.userDetails.id.toString() != this.product.winnerId) {
          this.router.navigate(['/wishlist']);
          this.toastr.infoToastr('', "Unfortunately, you lose this auction!");
        }
        else {
          this.toastr.successToastr('', "Congratulations! You won this auction!");
        }

        return;
      }
    });
  }

  onRatingChange(inputRating) {
    this.inputRating = inputRating;
    if (this.ratingFormControl.status === 'VALID') {
      this.disableSave = false;
    }
    else {
      this.disableSave = true;
    }
  }

  onSubmitRate() {
    this.userService.rateUser(this.sellerDetails.id.toString(), this.inputRating).then(result => {
      this.toastr.successToastr('', "Thanks for your rate!");
      this.userService.getByUsername(this.product.username).subscribe(sellerDetails => { this.sellerDetails = sellerDetails; });
    }).catch(err => {
      this.toastr.errorToastr('', "Rate error. Please try again later");
    });
  }

  onCommentChange(inputComment) {
    this.inputComment = inputComment;
  }

  onSubmitComment() {
    this.commentInfo.productId = this.product.id;
    this.commentInfo.userId = this.userDetails.id.toString();
    this.commentInfo.text = this.inputComment;

    this.productService.submitComment(this.commentInfo).then(result => {
      this.toastr.successToastr('', "Commentary placed!");

      this.productService.getComments(this.product.id).subscribe(
        comments => {
          this.comments = comments;
          this.inputComment = '';
        }
      );

    }).catch(err => {
      this.toastr.errorToastr('', "There was an issue when trying to place your comment. Please try again later!");
    });
  }

}
