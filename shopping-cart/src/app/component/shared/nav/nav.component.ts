import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  tokenVal : string;
  currentPage :string;
  constructor(private router : Router, public service :UserService) { }

  ngOnInit(): void {
  }

  loggedIn(){
    return this.service.userLoggedIn();
  }

  onLogout(){
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  }

}
