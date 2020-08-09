import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginFormModel = {
    email : [''],
    password : ['']
  }

  constructor(private service : UserService, private router : Router, private toastr : ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(loginForm : NgForm){
    console.log(loginForm.value);
    this.service.login(loginForm.value).subscribe(
      next => {
        this.toastr.success('Logged in successfully','Message');
        //localStorage.setItem('token',res.token);
        this.router.navigateByUrl('/profile');
      },
      error => {
        if(error.status == 400)
          this.toastr.error('Incorrect username or password','Authentication failed');
        else  
          console.log(error);
      }
    );

    // this.service.login(loginForm.value).subscribe(
    //   (res:any)=>{
    //     localStorage.setItem('token',res.token);
    //     this.router.navigateByUrl('/profile');
    //   },
    //   err => {
    //     if(err.status == 400)
    //       this.toastr.error('Incorrect username or password','Authentication failed');
    //     else  
    //       console.log(err);
    //   }
    // );
  }
}
