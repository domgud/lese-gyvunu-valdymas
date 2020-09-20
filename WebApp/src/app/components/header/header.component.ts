import {Component, OnInit} from '@angular/core';
import {UserService} from '@app/services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  constructor(private userService: UserService,
              private router: Router) {
  }


  ngOnInit(): void {
  }
  onLogout(): void {
    this.userService.logout();
    this.router.navigate(['/'])
  }
  checkLogin(): boolean {
    return this.userService.isLoggedIn();
  }

}
