import { NgModule } from "@angular/core";
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { RouterModule } from "@angular/router";
import { UserModule } from "./features/users/users.module";
import { SharedModule } from "./shared/shared.module";
import { SidebarComponent } from "./shared/components/sidebar/sidebar.component";

@NgModule({
	declarations: [AppComponent, SidebarComponent],
	imports: [
		BrowserModule, AppRoutingModule, BrowserAnimationsModule, RouterModule, HttpClientModule, UserModule, SharedModule],
	providers: [],
	bootstrap: [AppComponent],
})
export class AppModule { }