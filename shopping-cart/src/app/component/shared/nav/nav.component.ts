import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { Customer } from 'src/app/models/customer';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  loggedInUser : Customer ;
  tokenVal : string;
  currentPage :string;
  constructor(private router : Router, public service :UserService) { }

  ngOnInit(): void {
    // if(this.loggedIn()){
    //   var email = localStorage.getItem('email');
    //   console.log(email);
    //   console.log(this.service.getUserDetails(email));
    //   localStorage.setItem('customer', JSON.stringify(this.service.getUserDetails(email)));
    // }
  }

  loggedIn(){
    return this.service.userLoggedIn();
  }

  onLogout(){
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }

  getUserEmail(){ 
    var retrivedCustomerDetails = localStorage.getItem('customer');
    const cusDetails = JSON.parse(retrivedCustomerDetails);
    return cusDetails['email'];
  }

}
