import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { LibeyUser, UserUpdateorCreateCommand } from "src/app/features/users/models/libeyuser";
import { LibeyUserResponse } from "src/app/features/users/models/libeyuser";

@Injectable({
	providedIn: "root",
})
export class libeyuserService {
	BASE_URL_API = `${environment.pathLibeyTechnicalTest}LibeyUser`;

	constructor(private http: HttpClient) { }

	public getFindResponse(documentNumber: string): Observable<LibeyUserResponse> {
		const uri = `${this.BASE_URL_API}/${documentNumber}`;
		return this.http.get<LibeyUserResponse>(uri);
	}

	public getListAllLibeyUsers(): Observable<LibeyUserResponse> {
		const url = `${this.BASE_URL_API}`;
		return this.http.get<LibeyUserResponse>(url);
	}

	public postCreate(command: UserUpdateorCreateCommand): Observable<any> {
		const uri = `${this.BASE_URL_API}`;
		return this.http.post(uri, command);
	}

	public putUpdate(command: UserUpdateorCreateCommand): Observable<any> {
		const uri = `${this.BASE_URL_API}`;
		return this.http.put(uri, command);
	}

	public delete(documentNumber: string): Observable<any> {
		const uri = `${this.BASE_URL_API}/${documentNumber}`;
		return this.http.delete(uri);
	}

	public getToggleActive(documentNumber: string, isActived: boolean): Observable<any> {
		const uri = `${this.BASE_URL_API}/${documentNumber}/${isActived}`;
		return this.http.get(uri);
	}
}