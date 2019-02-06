import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatOptionModule } from '@angular/material';
import { MatSelectModule } from '@angular/material';

import { ProductsModule } from './products/products.module';
import { CarouselModule, ModalModule, ButtonsModule, WavesModule, InputsModule, IconsModule, CollapseModule } from 'angular-bootstrap-md';

// used to create fake backend
//import { fakeBackendProvider } from './_helpers';

import { AppComponent } from './app.component';
import { routing } from './app-routing.module';

import { JwtInterceptor, ErrorInterceptor } from './_helpers';
import { HomeComponent } from './home';
import { LoginComponent } from './login';
import { NavbarComponent } from './commons/navbar/navbar.component';
import { ToastrModule } from 'ng6-toastr-notifications';
import { RegisterComponent } from './register/register.component';
import { MyAccountComponent } from './my-account/my-account.component';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material';

@NgModule({
    imports: [
        BrowserModule,
        ReactiveFormsModule,
        FormsModule,
        HttpClientModule,
        routing,
        MDBBootstrapModule.forRoot(),
        ProductsModule,
        BrowserAnimationsModule,
        MatOptionModule,
        MatSelectModule,
        ToastrModule.forRoot(),
        MatButtonModule,
        MatInputModule,
        MatFormFieldModule,
        CarouselModule,
        WavesModule,
        ModalModule,
        ButtonsModule,
        InputsModule,
        CollapseModule,
        IconsModule
    ],
    declarations: [
        AppComponent,
        HomeComponent,
        LoginComponent,
        NavbarComponent,
        RegisterComponent,
        MyAccountComponent
    ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }