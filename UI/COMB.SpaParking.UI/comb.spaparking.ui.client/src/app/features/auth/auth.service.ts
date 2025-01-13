import {
    HttpClient,
    HttpErrorResponse,
    HttpHeaders,
  } from '@angular/common/http';
  import { toObservable } from '@angular/core/rxjs-interop';
  import { inject, Injectable, signal } from '@angular/core';
  import { Observable, of } from 'rxjs';
  import { catchError, map, shareReplay, switchMap, tap } from 'rxjs/operators';
  import { UserClaim } from './auth.models';
  
  @Injectable({
    providedIn: 'root',
  })
  export class AuthService {
    readonly http: HttpClient = inject(HttpClient);
    private httpOptions = { headers: new HttpHeaders({ 'X-CSRF': '1' }) }; //this is a fake header, replace it with your own. it's used to enforce a checking on server side
  
    
  }
  