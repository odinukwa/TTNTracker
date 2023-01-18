import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserLoginModel } from '../../models/userLoginModel';
import { AuthService } from '../../service/auth.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: 'login.component.html'
})
export class LoginComponent {
  invalidLogin: Boolean;
  constructor(private fb: FormBuilder, private authService: AuthService, private toastr: ToastrService, private router: Router) { }
  ngOnInit() {
    if (localStorage.getItem("token") != null)
      this.router.navigateByUrl('/devices')
  }
  frmLoginModel = this.fb.group({
    "Email": ['', [Validators.required, Validators.email]],
    "Password": ['', [Validators.required]]
  });

  onLogin() {
    var loginModel = new UserLoginModel();
    loginModel.email = this.frmLoginModel.value.Email;
    loginModel.password = this.frmLoginModel.value.Password;

    this.authService.loginUser(loginModel).subscribe(
      (res: any) => {
        if (res.status) {
          localStorage.setItem('token', res.data.token);
          this.invalidLogin = false;
          this.router.navigate(["/devices"])
        } else {
          this.invalidLogin = true;
          this.toastr.error(res.message, 'Login Failed')
        }
      },
      err => {
        this.invalidLogin = true;
        console.log(err);
      }
    )

  }

  registerNow() {
    this.router.navigate(["/register"])
  }

}
