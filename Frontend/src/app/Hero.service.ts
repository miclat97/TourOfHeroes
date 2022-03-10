import { Injectable } from '@angular/core';
import { hero } from './hero';
import { Observable, of, tap } from 'rxjs';
import { MessagesService } from './messages.service';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class HeroService {
  constructor(private messageService: MessagesService, private http: HttpClient) { }

  private apiUrl = 'https://localhost:7299/api/Heroes';

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   *
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  /** GET heroes from the server */
  getHeroes(): Observable<hero[]> {
    return this.http.get<hero[]>(`${this.apiUrl}/getAll`);
  }

  /** GET hero by id. Will 404 if id not found */
  getHero(id: number): Observable<hero> {
    const url = `${this.apiUrl}/getById/${id}`;
    return this.http.get<hero>(url);
  }

  searchHeroes(term: string): Observable<hero[]> {
    if (!term.trim()) {
      return of([]);
    }

    return this.http.get<hero[]>(`${this.apiUrl}/search/${term}`);
  }

  saveHero(id: number, name: string, power: number): Observable<hero> {
    return this.http.put<hero>(`${this.apiUrl}/update/${id}/${name}/${power}`, null);
  }

  private log(message: string) {
    this.messageService.add(`HeroService: ${message}`);
  }
}
