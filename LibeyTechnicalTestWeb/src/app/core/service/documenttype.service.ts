import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { DocumentTypeResponse } from "src/app/shared/models/documenttype";

@Injectable({
    providedIn: "root",
})
export class DocumentTypeService {
    BASE_URL_API = `${environment.pathLibeyTechnicalTest}DocumentType`;

    constructor(private http: HttpClient) { }

    public getListAll(): Observable<DocumentTypeResponse> {
        const url = `${this.BASE_URL_API}`;
        return this.http.get<DocumentTypeResponse>(url);
    }
}