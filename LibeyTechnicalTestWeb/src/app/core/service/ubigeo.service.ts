import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { UbigeoResponse } from "src/app/shared/models/ubigeo";

@Injectable({
    providedIn: "root",
})
export class UbigeoService {
    BASE_URL_API = `${environment.pathLibeyTechnicalTest}Ubigeo`;

    constructor(private http: HttpClient) { }

    public getListAll(): Observable<UbigeoResponse> {
        const url = `${this.BASE_URL_API}`;
        return this.http.get<UbigeoResponse>(url);
    }
}