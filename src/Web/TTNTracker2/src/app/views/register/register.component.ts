import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import Validation from '../../util/validation';
import { AuthService } from '../../service/auth.service';
import { UserProfileModel } from '../../models/userProfileModel';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-dashboard',
  templateUrl: 'register.component.html'
})
export class RegisterComponent {


  constructor(private fb: FormBuilder, private service: AuthService, private toastr: ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }
  formModel = this.fb.group({
    Email: ['', [Validators.required, Validators.email]],
    LastName: ['', Validators.required],
    FirstName: ['', Validators.required],
    Passwords: this.fb.group({
      Password: ['', [Validators.required, Validators.minLength(4)]],
      ConfirmPassword: ['', Validators.required]
    },
      {
        validators: [Validation.match('Password', 'ConfirmPassword')]
      })
  });

  onSubmit() {

    var user = new UserProfileModel();
    user.lastName = this.formModel.value.LastName;
    user.firstName = this.formModel.value.FirstName;
    user.email = this.formModel.value.Email;
    user.password = this.formModel.value.Passwords.Password;
    user.confirmPassword = this.formModel.value.Passwords.ConfirmPassword;
    console.log(user)
    this.service.registerUser(user).subscribe(
      (res: any) => {
        if (res.status) {
          this.resetForm();
          this.toastr.success("New User Created!<br/> Redirecting....", 'Registeration Successful');
        } else {
          if (res.data != null) {
            console.log(res);
            res.data.errors
              .forEach(element => {
                console.log(element)
                switch (element.code) {
                  case "DuplicateUserName": {
                    //Email Already exist!!!
                    this.toastr.error("Email Already exist!!!", 'Registeration Failed');
                    break
                  }
                  default: {
                    //Registeration Failed
                    this.toastr.error(res.message, 'Registeration Failed');
                    break;
                    //
                  }
                }
              });
          }
        }
      },
      err => {
        console.log(err)
      }
    );
  }

  resetForm() {
    this.formModel.reset();
  }
}
