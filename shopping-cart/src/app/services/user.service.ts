import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http'
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { Customer } from '../models/customer';

@Injectable({
    providedIn: 'root'
})

export class UserService{

    constructor(private fb : FormBuilder, private httpClient : HttpClient){}
    private JwtHelper = new JwtHelperService();
    private readonly baseUrl = environment.baseUri + 'Customer/';
    decodeToken: any;

    formModel = this.fb.group({ 
        customername: ['', Validators.required],
        email: ['', [Validators.required, Validators.email]],
        address: [''],
        phone: [''],
        passwords: this.fb.group({
            password: ['', [Validators.required, Validators.minLength(4)]],
            confirmPassword: ['', Validators.required]
        }, {validator : this.comparePasswords})
    }); 
    loggedInUser : Customer ;

    comparePasswords(fg : FormGroup){
        let confirmPasswordCtrl = fg.get('confirmPassword');
        if(confirmPasswordCtrl.errors == null || 'passwordMismatch' in confirmPasswordCtrl.errors){
            if(fg.get('password').value != confirmPasswordCtrl.value)
                confirmPasswordCtrl.setErrors({passwordMismatch:true});
            else
                confirmPasswordCtrl.setErrors(null);
        }
    }

    register(){
        var body = {
            CustomerName : this.formModel.value.customername,
            Email : this.formModel.value.email,
            CustomerAddress : this.formModel.value.address,
            Phone : this.formModel.value.phone,
            Password : this.formModel.value.passwords.password
        };
        console.log(body);
        return this.httpClient.post(this.baseUrl + 'Register', body);
    }

    login(formData){
        console.log(formData);
        return this.httpClient.post(this.baseUrl + 'Login', formData)
                .pipe(
                    map((res:any) => {
                        console.log("inside service login method");
                        const token  = res;
                        if(token){
                            localStorage.setItem('token',JSON.stringify(token));
                            //console.log(formData.email);
                            localStorage.setItem('email',formData.email);
                            this.decodeToken = token;
                            console.log(this.decodeToken);
                            //get user details
                            this.getUserDetails(formData.email).subscribe((customer:Customer)=>{
                                this.loggedInUser = customer;
                                localStorage.setItem('customer', JSON.stringify(this.loggedInUser));
                                console.log(this.loggedInUser);
                                console.log(this.loggedInUser.email);
                            });
                        }
                    })
                );
    }

    userLoggedIn(){
        const token = localStorage.getItem('token');
        console.log("saved val : ", JSON.parse(token));
        return !this.JwtHelper.isTokenExpired(token);
    }

    getUserDetails(email : string) : Observable<Customer>{
        //console.log("In");
        return this.httpClient.get<Customer>(this.baseUrl + email);
    }
}