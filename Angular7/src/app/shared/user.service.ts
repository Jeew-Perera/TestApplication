import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private fb:FormBuilder, private http:HttpClient) { }
  readonly BaseURI = 'http://localhost:50726/api';

  formModel = this.fb.group({
    UserName: ['', Validators.required],
    Email: ['', Validators.email],
    FullName: [''],
    Passwords: this.fb.group({
      Password: ['', [Validators.required,Validators.minLength(4)]],
      ConfirmPassword:['', Validators.required]
    },{validator: this.comparePasswords })
  });

  comparePasswords(fb:FormGroup){
    let confirmPswrCtrl = fb.get('ConfirmPassword');
    if(confirmPswrCtrl.errors == null || 'passwordMismatch' in confirmPswrCtrl.errors){
      if(fb.get('Password').value != confirmPswrCtrl.value)
        confirmPswrCtrl.setErrors({ passwordMismatch: true });
      else
        confirmPswrCtrl.setErrors(null);
    }
  }

  register(){
    var body={
      UserName:this.formModel.value.UserName,
      Email:this.formModel.value.Email,
      FullName:this.formModel.value.FullName,
      Password:this.formModel.value.Passwords.Password
    };
    return this.http.post(this.BaseURI+'/ApplicationUser/Register',body);
  }
}
