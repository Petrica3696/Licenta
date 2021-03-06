import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { FormControl, Validators, FormBuilder, FormGroup } from '@angular/forms';

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

  form: FormGroup;
  loading: boolean = false;

  @ViewChild('fileInput') fileInput: ElementRef;

  constructor(private userService: UserService, public toastr: ToastrManager, private router: Router,  private fb: FormBuilder) {
    this.createForm();
  }

  firstNameFormControl = new FormControl('', [Validators.required]);
  lastNameFormControl = new FormControl('', [Validators.required]);
  usernameFormControl = new FormControl('', [Validators.required]);
  passwordFormControl = new FormControl('', [Validators.required]);

  ngOnInit() {
  }

  createForm() {
    this.form = this.fb.group({
      name: ['', Validators.required],
      avatar: null
    });
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

  onFileChanged(event) {
    let reader = new FileReader();
    if(event.target.files && event.target.files.length > 0) {
      let file = event.target.files[0];
      reader.readAsDataURL(file);
      reader.onload = () => {
        this.form.get('avatar').setValue({
          filename: file.name,
          filetype: file.type,
          value: reader.result
        })
        console.log(this.form.get('avatar').value.value);
      };
    }
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
    this.user.avatar = this.form.get('avatar').value.value;


    this.userService.addUser(this.user).then(result => {
      this.toastr.successToastr('', "Your registration was successful! Please login with your credentials.");
      this.router.navigate(["login"]);
    }).catch(err => {
      this.toastr.errorToastr('', "There was an issue. Please try again");
    });
  }

  onClick() {
    this.router.navigate(['/login']);
  }

}
