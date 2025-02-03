import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgSelectModule } from "@ng-select/ng-select";
import { FormUser } from './components/form/form.component';
import { PageAddUserComponent } from './pages/add/add.component';
import { PageListOfUsersComponent } from './pages/list/list.component';
import { PageUpdateUserComponent } from './pages/update/update.component';

@NgModule({
  declarations: [
    FormUser,
    PageAddUserComponent,
    PageUpdateUserComponent,
    PageListOfUsersComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgSelectModule,
  ]
})
export class UserModule { }