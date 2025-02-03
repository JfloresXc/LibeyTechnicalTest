import { Component, OnInit } from '@angular/core';
import { usersMock } from 'src/app/shared/mocks/users';
import { LibeyUser, LibeyUserResponse } from '../../models/libeyuser';
import { libeyuserService } from '../../services/libeyuser/libeyuser.service';
import { PageLoaderService } from 'src/app/core/service/pageloader.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class PageListOfUsersComponent {
  public users: LibeyUser[] = []
  public usersUI: LibeyUser[] = []

  constructor(
    private libeyuserService: libeyuserService,
    private pageLoaderService: PageLoaderService,
  ) {
    this.loadLibeyusers()
  }

  private loadLibeyusers(): void {
    this.pageLoaderService.startLoading();
    this.libeyuserService.getListAllLibeyUsers().subscribe({
      next: data => this.handleLibeyusers(data),
      error: err => {
        this.pageLoaderService.stopLoading();
        console.error('Error fetching libey users', err)
      }
    });
  }

  private handleLibeyusers(response: LibeyUserResponse): void {
    this.pageLoaderService.stopLoading();
    if (response && response.data && response.data.length > 0) {
      this.usersUI = this.users = response.data;
    } else {
      console.warn('No found or insufficient data');
    }
  }

  searchUsers(event: Event): void {
    let inputValue = (event.target as HTMLInputElement).value
    if (!inputValue.trim()) this.usersUI = this.users;

    inputValue = inputValue.toLowerCase();

    this.usersUI = this.users.filter(user =>
      Object.values(user).some(value =>
        typeof value === 'string' && value.toLowerCase().includes(inputValue)
      )
    );
  }

  deleteUser(documentNumber: string): void {
    this.libeyuserService.delete(documentNumber).subscribe({
      next: () => this.handleDeleteUser(documentNumber),
      error: err => console.error('Error deleting user', err)
    });
  }

  private handleDeleteUser(documentNumber: string): void {
    this.users = this.usersUI = this.users.filter(user => user.documentNumber !== documentNumber);
    this.loadLibeyusers()
  }
}