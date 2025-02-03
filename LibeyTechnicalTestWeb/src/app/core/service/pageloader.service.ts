import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PageLoaderService {
  private loadingSubject = new Subject<boolean>();

  constructor() { }

  startLoading() {
    this.loadingSubject.next(true);
  }

  stopLoading() {
    setTimeout(() => {
      this.loadingSubject.next(false);
    }, 500);
  }

  isLoading(): Observable<boolean> {
    return this.loadingSubject.asObservable();
  }
}
