import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  activateHome: string;
  activateAllProd: string;
  activateMyProd: string;
  activateAddProd: string;
  activateMyAuct: string;


  constructor(private router: Router) { }

  ngOnInit() {
  }

  onHome() {
    this.activateHome = "active";
    this.activateAllProd = "";
    this.activateMyProd = "";
    this.activateAddProd = "";
    this.activateMyAuct  ="";
    this.router.navigate(['']);
  }

  onAllProd() {
    this.activateHome = "";
    this.activateAllProd = "active";
    this.activateMyProd = "";
    this.activateAddProd = "";
    this.activateMyAuct  ="";
    this.router.navigate(['/all-products']);
  }

  onMyProd() {
    this.activateHome = "";
    this.activateAllProd = "";
    this.activateMyProd = "active";
    this.activateAddProd = "";
    this.activateMyAuct  ="";
    this.router.navigate(['/my-products']);
  }

  onAddProd() {
    this.activateHome = "";
    this.activateAllProd = "";
    this.activateMyProd = "";
    this.activateAddProd = "active";
    this.activateMyAuct  ="";
    this.router.navigate(['add-product'])
  }

  onMyAuct() {
    this.activateHome = "";
    this.activateAllProd = "";
    this.activateMyProd = "";
    this.activateAddProd = "";
    this.activateMyAuct  ="active";
    this.router.navigate(['wishlist'])
  }

  onMyAccount() {
    this.activateHome = "";
    this.activateAllProd = "";
    this.activateMyProd = "";
    this.activateAddProd = "";
    this.activateMyAuct  ="";
    this.router.navigate(['/my-account'])
  }
}
