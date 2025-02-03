import { Component, inject } from '@angular/core';
import { PageLoaderService } from 'src/app/core/service/pageloader.service';

@Component({
  selector: 'app-page-loader',
  templateUrl: './page-loader.component.html',
  styleUrls: ["./page-loader.component.scss"],
})
export class PageLoaderComponent {
  showLoader: boolean = false;

  constructor(private pageLoaderService: PageLoaderService) {
    this.pageLoaderService.isLoading().subscribe((isLoading) => {
      if (isLoading) {
        this.showLoader = true;
      } else {
        this.showLoader = false;
      }
    });
  }

}
