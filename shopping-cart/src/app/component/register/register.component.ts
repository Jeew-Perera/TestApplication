import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { UserService } from 'src/app/services/user.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;

  constructor(public service : UserService, private toastr : ToastrService, private router : Router) { }

  ngOnInit(): void {
    this.service.formModel.reset();
  }

  onSubmit(){
    this.service.register().subscribe( () => { 
      this.service.formModel.reset();
      this.toastr.success('New user added', 'Registration successful');
      this.router.navigateByUrl('/login');
    },
    error => {
      this.toastr.error(error,'Registration failed')
    });
  }
}
