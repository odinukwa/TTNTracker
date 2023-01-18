import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProfilesettingComponent } from './profilesetting/profilesetting.component';
import { UserComponent } from './user.component';

const routes: Routes = [
  {
    path: '',
    component: UserComponent,
    data: {
      title: 'User'
    }
  }
  // , {
  //   path: 'profile-settings',
  //   component: ProfilesettingComponent,
  //   data: {
  //     title: 'Profile Settings'
  //   }
  // }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
