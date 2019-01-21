import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';

import { UserService } from '../_services/user.service';
import { User } from '../_models/user';
import { ToastrManager } from 'ng6-toastr-notifications';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  inputFirstName: string;
  inputLastName: string;
  inputUsername: string;
  inputPassword: string;
  registerDisabled: boolean = true;
  user: User = new User();

  constructor(private userService: UserService, public toastr: ToastrManager, private router: Router) { }

  firstNameFormControl = new FormControl('', [Validators.required]);
  lastNameFormControl = new FormControl('', [Validators.required]);
  usernameFormControl = new FormControl('', [Validators.required]);
  passwordFormControl = new FormControl('', [Validators.required]);

  ngOnInit() {
  }

  onFirstNameChange(inputFirstName) {
    this.inputFirstName = inputFirstName;
    this.verifyAllFilled();
  }

  onLastNameChange(inputLastName) {
    this.inputLastName = inputLastName;
    this.verifyAllFilled();
  }

  onUsernameChange(inputUsername) {
    this.inputUsername = inputUsername;
    this.verifyAllFilled();
  }

  onPasswordChange(inputPassword) {
    this.inputPassword = inputPassword;
    this.verifyAllFilled();
  }

  verifyAllFilled() {
    if(this.firstNameFormControl.status == 'VALID' &&
    this.lastNameFormControl.status == 'VALID' &&
    this.usernameFormControl.status == 'VALID' &&
    this.passwordFormControl.status == 'VALID') {
      this.registerDisabled = false;
    }
    else {
      this.registerDisabled = true;
    }
  }

  onSubmit() {
    this.user.firstName = this.inputFirstName;
    this.user.lastName = this.inputLastName;
    this.user.username = this.inputUsername;
    this.user.password = this.inputPassword;
    console.log(this.user);
    this.userService.addUser(this.user).then(result => {
      this.toastr.successToastr('', "Your registration was successful! Please login with your credentials.");
      this.router.navigate(["login"]);
    }).catch(err => {
      this.toastr.errorToastr('', "There was an issue. Please try again");
    });
  }

}
