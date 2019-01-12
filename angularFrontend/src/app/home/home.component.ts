import { Component, OnInit, ChangeDetectionStrategy, ChangeDetectorRef } from '@angular/core';
import { first } from 'rxjs/operators';

import { User } from '../_models';
import { UserService } from '../_services';

@Component({
  selector: 'app-home-component',
  templateUrl: 'home.component.html',
  styleUrls: ['./home.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class HomeComponent implements OnInit {
    users: User[] = [];
    userDetails: User;

    constructor(private userService: UserService, private userCredentialsService: UserService, private changeDetectorRef: ChangeDetectorRef) {}

    ngOnInit() {
        this.userService.getAll().pipe(first()).subscribe(users => { 
            this.users = users; 
        });
        this.userCredentialsService.getUserCredentials().subscribe(
            userDetails => {
                this.userDetails = userDetails;
                this.changeDetectorRef.detectChanges();
            }
        );
        
    }
}