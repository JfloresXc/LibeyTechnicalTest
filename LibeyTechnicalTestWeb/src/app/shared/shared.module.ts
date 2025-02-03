import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgSelectModule } from "@ng-select/ng-select";
import { PageLoaderComponent } from './components/page-loader/page-loader.component';

@NgModule({
  declarations: [
    PageLoaderComponent
  ],
  imports: [
    CommonModule,
    NgSelectModule
  ],
  exports: [
    PageLoaderComponent
  ]
})
export class SharedModule { }