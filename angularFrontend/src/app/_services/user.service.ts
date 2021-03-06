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

    getByUsername(username: string) {
        return this.http.get<User>('http://localhost:44800/api/users/' + username);
    }

    getById(id: string) {
        return this.http.get<User>('http://localhost:44800/api/users/get-by-id/' + id);
    }

    async addUser(user: User): Promise<User> {
        return this.http.post<User>('http://localhost:4900/api/users', user).toPromise<User>();
    }

    async editUser(id: string, user: User): Promise<User> {
        return this.http.put<User>('http://localhost:4900/api/users/' + id, user).toPromise<User>();
    }

    async rateUser(id: string, rating: number): Promise<number> {
        return this.http.put<number>('http://localhost:4900/api/users/rate/' + id, rating).toPromise<number>();
    }
}