
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../service/auth.service';
import { navItems } from '../../_nav';

@Component({
  selector: 'app-dashboard',
  templateUrl: './default-layout.component.html'
})
export class DefaultLayoutComponent implements OnInit {
  public sidebarMinimized = false;
  public navItems = navItems;
  constructor(private router: Router,
    private authService: AuthService) { }
  toggleMinimize(e) {
    this.sidebarMinimized = e;
  }

  ngOnInit(): void {
    this.authService.userProfile().subscribe(
      (res: any) => {
        //console.log(res);
      },
      err => {

      }
    )
  }

  logout() {
    localStorage.removeItem('token');
    //this.router.navigate(["/login"]);
    this.router.navigate(["/register"])
  }
}
