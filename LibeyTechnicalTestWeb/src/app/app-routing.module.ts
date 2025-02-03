import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { AppComponent } from "./app.component";
import { PageListOfUsersComponent } from "./features/users/pages/list/list.component";
import { PageAddUserComponent } from "./features/users/pages/add/add.component";
import { PageUpdateUserComponent } from "./features/users/pages/update/update.component";

const routes: Routes = [
	{
		path: "",
		redirectTo: "/user/list",
		pathMatch: "full",
	},
	{
		path: "user",
		children: [
			{ path: "add", component: PageAddUserComponent },
			{ path: "list", component: PageListOfUsersComponent },
			{ path: "update/:documentNumber", component: PageUpdateUserComponent }
		],
	},
	{ path: "**", component: AppComponent },
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule],
})
export class AppRoutingModule { }