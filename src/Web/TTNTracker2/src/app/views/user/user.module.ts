import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms'


import { CollapseModule } from 'ngx-bootstrap/collapse';
import { ModalModule } from 'ngx-bootstrap/modal';
import { UserComponent } from './user.component';
import { ProfilesettingComponent } from './profilesetting/profilesetting.component';

import { UserRoutingModule } from './user-routing.module';
import { ChangepasswordComponent } from './changepassword/changepassword.component';


@NgModule({

  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    UserRoutingModule,
    CollapseModule.forRoot(),
    ModalModule.forRoot()
  ],
  declarations: [UserComponent, ProfilesettingComponent, ChangepasswordComponent],
})
export class UserModule { }
