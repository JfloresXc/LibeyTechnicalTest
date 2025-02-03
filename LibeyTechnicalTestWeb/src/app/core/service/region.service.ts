import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { RegionResponse } from "src/app/shared/models/region";

@Injectable({
    providedIn: "root",
})
export class RegionService {
    BASE_URL_API = `${environment.pathLibeyTechnicalTest}Region`;

    constructor(private http: HttpClient) { }

    public getListAll(): Observable<RegionResponse> {
        const url = `${this.BASE_URL_API}`;
        return this.http.get<RegionResponse>(url);
    }
}