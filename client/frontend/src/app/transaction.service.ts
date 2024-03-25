import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, map, of } from 'rxjs';
import { Personal } from './models/personal.Personal';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  private baseUrl = 'https://localhost:44301/api/';
  constructor(private httpClient: HttpClient) { }

  public getAllPersonal(): Observable<Personal[]> {
    return this.httpClient.get<Personal[]>(this.baseUrl + 'personal');
  }


  public postPersonal(personal: Personal): Observable<boolean> {
    return this.httpClient.post<Personal>(this.baseUrl + 'personal', personal).pipe(
      map(() => {
        console.log("Personal data created successfully");
        return true; // Return true on successful creation
      }),
      catchError((error) => {
        console.error("Error creating personal data:", error);
        return of(false); // Return false on error
      })
    );
  }


  public updatePersonal(personal: Personal): Observable<boolean> {
    return this.httpClient.put<Personal>(this.baseUrl + 'personal', personal).pipe(
      map(() => {
        console.log("Personal data updated successfully");
        return true; // Return true on successful creation
      }),
      catchError((error) => {
        console.error("Error updating personal data:", error);
        return of(false); // Return false on error
      })
    );
  }


}
