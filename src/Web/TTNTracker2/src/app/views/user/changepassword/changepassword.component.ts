import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../../../service/auth.service';
import Validation from '../../../util/validation';

@Component({
  selector: 'app-changepassword',
  templateUrl: './changepassword.component.html',
  styles: [
  ]
})
export class ChangepasswordComponent implements OnInit {

  constructor(private fb: FormBuilder,
    private service: AuthService,
    private toastr: ToastrService) { }

  // formModel = this.fb.group({
  //   oldPassword: ['', [Validators.required, Validators.minLength(4)]],
  //   newPassword: ['', [Validators.required, Validators.minLength(4)]],
  //   confirmNewPassword: ['', Validators.required]
  // },
  //   {
  //     validators: [Validation.match('newPassword', 'confirmNewPassword')]
  //   });

  formModel = this.fb.group({
    oldPassword: ['', [Validators.required, Validators.minLength(4)]],
    Passwords: this.fb.group({
      newPassword: ['', [Validators.required, Validators.minLength(4)]],
      confirmNewPassword: ['', [Validators.required]]
    },
      {
        validators: [Validation.match('newPassword', 'confirmNewPassword')]
      })
  });
  ngOnInit(): void {
  }
  isCollapsed: boolean = true;

  collapsed(event: any): void {
    // console.log(event);
  }

  expanded(event: any): void {
    console.log(event);
    //event.textContent = 'Collapse';
  }

  onSubmit() {
    console.log(this.formModel.value)
  }
}
