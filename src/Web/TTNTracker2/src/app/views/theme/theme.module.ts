// Angular
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { ColorsComponent } from './colors.component';
import { TypographyComponent } from './typography.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { UserprofileComponent } from './userprofile.component';

// Theme Routing
import { ThemeRoutingModule } from './theme-routing.module';

@NgModule({
  imports: [
    CommonModule,
    ThemeRoutingModule,
    CollapseModule.forRoot(),
    ModalModule.forRoot()
  ],
  declarations: [
    ColorsComponent,
    TypographyComponent,
    UserprofileComponent
  ]
})
export class ThemeModule { }
