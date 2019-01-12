import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User } from '../_models';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class UserService {
    private userCredentials: User;
    constructor(private http: HttpClient) { }

    getAll() {
        return this.http.get<User[]>('http://localhost:44800/api/users');
    }

    getUserCredentials() {
        return Observable.create(observer => {
            this.http.get<User>("http://localhost:44800/api/users/current")
            .subscribe((res) => {
                this.userCredentials = res;
                observer.next(res);
                observer.complete();
                error => {
                    observer.error(error);
                }
            });
        });
    }
}