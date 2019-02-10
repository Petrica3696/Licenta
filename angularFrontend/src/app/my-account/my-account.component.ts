import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { User } from '../_models';
import { FormControl, Validators } from '@angular/forms';
import { UserService } from '../_services';
import { ToastrManager } from 'ng6-toastr-notifications';

@Component({
  selector: 'app-my-account',
  templateUrl: './my-account.component.html',
  styleUrls: ['./my-account.component.scss']
})
export class MyAccountComponent implements OnInit {

  user: User = new User;
  toggleToEdit: boolean = false;
  changedUser: User = new User;
  buttonText: string = 'Back';
  buttonColor: string = 'warn';

  inputFirstName: string;
  inputLastName: string;
  inputUsername: string;
  inputPassowrd: string;

  constructor(private userService: UserService, private changeDetectorRef: ChangeDetectorRef, public toastr: ToastrManager) { }

  inputFirstNameFormControl = new FormControl('', Validators.nullValidator);
  inputLastNameFormControl = new FormControl('', Validators.nullValidator);
  inputUsernameFormControl = new FormControl('', Validators.nullValidator);
  inputPasswordFormControl = new FormControl('', Validators.nullValidator);

  ngOnInit() {
    this.userService.getUserCredentials().subscribe(
      userDetails => {
        this.user = userDetails;
        console.log(this.user.rate);
        this.changeDetectorRef.detectChanges();
      });
  }

  onFirstNameChange(inputFirstName) {
    this.inputFirstName = inputFirstName;
    console.log(this.inputFirstName);
    this.isAnyFieldValid();
  }

  onLastNameChange(inputLastName) {
    this.inputLastName = inputLastName;
    this.isAnyFieldValid();
  }

  onUsernameChange(inputUsername) {
    this.inputUsername = inputUsername;
    this.isAnyFieldValid();
  }

  onPasswordChange(inputPassowrd) {
    this.inputPassowrd = inputPassowrd;
    console.log(this.inputPassowrd);
    this.isAnyFieldValid();
  }

  isAnyFieldValid() {
    if (
      (this.inputFirstName !== undefined && this.inputFirstName !== '' && this.inputFirstName !== this.user.firstName) ||
      (this.inputLastName !== undefined && this.inputLastName !== '' && this.inputLastName !== this.user.lastName) ||
      (this.inputUsername !== undefined && this.inputUsername !== '' && this.inputUsername !== this.user.username)
    ) {
      this.buttonText = 'Edit';
      this.buttonColor = 'primary';
    }
    else {
      this.buttonText = 'Back';
      this.buttonColor = 'warn';
    }

  }

  onEdit() {
    this.toggleToEdit = true;
  }

  onSubmit() {

    if (this.buttonText === 'Edit') {
      if (this.inputFirstName !== undefined && this.inputFirstName !== '' && this.inputFirstName !== this.user.firstName) this.changedUser.firstName = this.inputFirstName;
      if (this.inputLastName !== undefined && this.inputLastName !== '' && this.inputLastName !== this.user.lastName) this.changedUser.lastName = this.inputLastName;
      if (this.inputUsername !== undefined && this.inputUsername !== '' && this.inputUsername !== this.user.username) this.changedUser.username = this.inputUsername;
      if (this.inputPassowrd !== undefined && this.inputPassowrd !== '') this.changedUser.password = this.inputPassowrd;

      this.userService.editUser(this.user.id.toString(), this.changedUser).then(result => {
        this.toastr.successToastr('', "The profile was successfuly edited!");
        this.userService.getUserCredentials().subscribe(
          userDetails => {
            this.user = userDetails;
            this.changeDetectorRef.detectChanges();
          }
        );
      }).catch(err => {
        this.toastr.errorToastr('', "There was an issue when editing your profile. Please try again");
      });
    }

    this.toggleToEdit = false;
  }
}
