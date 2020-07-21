import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http'

@Injectable({
    providedIn: 'root'
})

export class UserService{

    constructor(private fb : FormBuilder, private httpClient : HttpClient){}
    readonly BaseUri = 'http://localhost:59278/api';

    formModel = this.fb.group({
        name: ['', Validators.required],
        email: ['', [Validators.required, Validators.email]],
        address: [''],
        phone: [''],
        passwords: this.fb.group({
            password: ['', [Validators.required, Validators.minLength(4)]],
            confirmPassword: ['', Validators.required]
        }, {validator : this.comparePasswords})
    });

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
            Name : this.formModel.value.Name,
            Email : this.formModel.value.Email,
            Address : this.formModel.value.Address,
            Phone : this.formModel.value.Phone,
            Password : this.formModel.value.Password
        };
        return this.httpClient.post(this.BaseUri+'/Customer/Register', body);
    }
}