import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserLoginModel } from '../../models/userLoginModel';
import { AuthService } from '../../service/auth.service';

import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-dashboard',
  templateUrl: './passwordreset.component.html',
  styleUrls: ['./passwordreset.component.scss']
})
export class PasswordresetComponent implements OnInit {

  constructor(private fb: FormBuilder,
    private authService: AuthService,
    private toastr: ToastrService,
    private router: Router) { }

  ngOnInit(): void {
  }

  frmResetModel = this.fb.group({
    "Email": ['', [Validators.required, Validators.email]]
  });

  onLogin() {
    var model = {
      email: this.frmResetModel.value.Email
    };

    this.authService.resetPassword(model).subscribe(
      (res: any) => {
        if (res.status) {
          this.toastr.success('Password reset successfully. Proceed to Login', 'Login Successful')
        } else {
          this.toastr.error(res.message, 'Login Failed')
        }
      },
      err => {
        console.log(err);
      }
    )

  }

  registerNow() {
    this.router.navigate(["/register"])
  }

}
