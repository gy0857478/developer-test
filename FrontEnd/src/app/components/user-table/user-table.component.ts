import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { UserService, User } from '../../services/user.service';
import { BehaviorSubject, Observable } from 'rxjs';

@Component({
  selector: 'app-user-table',
  standalone: true,
  imports: [CommonModule, FormsModule, HttpClientModule],
  templateUrl: './user-table.component.html',
  styleUrl: './user-table.component.css'
})
export class UserTableComponent implements OnInit {
  users$: Observable<User[]> | undefined;
  filteredUsers$: BehaviorSubject<User[]> = new BehaviorSubject<User[]>([]);
  searchTerm: string = '';

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.userService.getUsers().subscribe((users) => {
      const sortedUsers = users.sort((a, b) => a.name.localeCompare(b.name));
      this.filteredUsers$.next(sortedUsers);
    });
  }

  onSearch(): void {
    const searchTermLower = this.searchTerm.toLowerCase();
    const filteredUsers = this.filteredUsers$.value.filter((user) =>
      user.name.toLowerCase().includes(searchTermLower)
    );
    this.filteredUsers$.next(filteredUsers);
  }

  resetBalances(): void {
    const resetUsers = this.filteredUsers$.value.map((user) => ({
      ...user, 
      balance: 0,
      poundsBalance: "£0.00"
    }));
    this.filteredUsers$.next(resetUsers);
  }
}