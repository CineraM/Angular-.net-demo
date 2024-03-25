import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
// import { Post } from './models/post.Post';
import { Personal } from '../models/personal.Personal';

@Injectable({
  providedIn: 'root'
})

export class TransactionService 
{
  private baseUrl = 'https://localhost:44301/api/';
  constructor(private httpClient: HttpClient) { }

  public getAllPersonal(): Observable<Personal[]> {
    return this.httpClient.get<Personal[]>(this.baseUrl + 'personal');
  }

//   public createPost(post: Post): Observable<Post> {
//     return this.httpClient.post<Post>(this.baseUrl + 'posts/create', post);
//   }
}