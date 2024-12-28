import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, Observable } from 'rxjs';
import { environment } from '../../environmentrs/environment';

export interface User {
  iconPath: string;
  name: string;
  age: number;
  registered: string;
  email: string;
  balance: number;
  poundsBalance?: string;
}

@Injectable({
  providedIn: 'root'
})

export class UserService {

  private apiUrl = `${environment.apiUrl}/users`;
  
  constructor(private http:HttpClient) {}

  private formatToPounds(amount: string | number): string {
    const numericValue = typeof amount === 'string' 
      ? parseFloat(amount.replace(/,/g, ''))
      : amount;
    
    if (isNaN(numericValue)) {
      return '£0.00';
    }

    return new Intl.NumberFormat('en-GB', {
      style: 'currency',
      currency: 'GBP',
      minimumFractionDigits: 2,
      maximumFractionDigits: 2
    }).format(numericValue);
  }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.apiUrl).pipe(
      map((users) =>
        users.map((user) => {
          
          const dateFixed = user.registered.replace(' -', '-');

          return {
            ...user,
            registered: dateFixed,
            iconPath: `${environment.apiUrl}/icons/${user.iconPath}`,
            poundsBalance: this.formatToPounds(user.balance)
          };
        })
      )
    );
  }

}
