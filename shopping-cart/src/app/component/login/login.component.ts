import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CartService } from 'src/app/services/cart.service';

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

  constructor(private service : UserService, private router : Router, private toastr : ToastrService, private cartService : CartService) { }

  public cartHasItems : boolean = false;

  ngOnInit(): void {
  }

  onSubmit(loginForm : NgForm){
    console.log(loginForm.value);
    this.service.login(loginForm.value).subscribe(
      next => {
        this.toastr.success('Logged in successfully','Message');
        this.cartHasItems = this.cartService.checkCartHasItems();
        if(this.cartHasItems)
          this.router.navigateByUrl('/cart');
        else
          this.router.navigateByUrl('/products');
      },
      error => {
        if(error.status == 400)
          this.toastr.error('Incorrect username or password','Authentication failed');
        else  
          console.log(error);
      }
    );
  }
}
