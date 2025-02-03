import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { ProvinceResponse } from "src/app/shared/models/province";

@Injectable({
    providedIn: "root",
})
export class ProvinceService {
    BASE_URL_API = `${environment.pathLibeyTechnicalTest}Province`;

    constructor(private http: HttpClient) { }

    public getListAll(): Observable<ProvinceResponse> {
        const url = `${this.BASE_URL_API}`;
        return this.http.get<ProvinceResponse>(url);
    }
}