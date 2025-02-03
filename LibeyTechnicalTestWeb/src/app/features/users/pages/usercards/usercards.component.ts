import { Component, OnInit } from "@angular/core";
import { libeyuserService } from "src/app/features/users/services/libeyuser/libeyuser.service";
@Component({
	selector: "app-usercards",
	templateUrl: "./usercards.component.html",
	styleUrls: ["./usercards.component.css"],
})
export class UsercardsComponent implements OnInit {
	constructor(private libeyuserService: libeyuserService) { }
	ngOnInit(): void {
		this.libeyuserService.getFindResponse("46257869").subscribe(response => {
			console.log(response, "User");
		});
	}
}