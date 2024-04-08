import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpErrorResponse, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { MatSnackBar } from '@angular/material/snack-bar';


  @Injectable()
  export class ErrorHandlerInterceptor implements HttpInterceptor {
    constructor(private snackBar: MatSnackBar) {}

    intercept(
      request: HttpRequest<any>,
      next: HttpHandler
    ): Observable<HttpEvent<any>> {
      return next.handle(request).pipe(
        tap({
          error: (err: HttpErrorResponse) => {
            if (
              !(
                err.status === 401 &&
                (err.message === '' || err.url?.includes('/api/account'))
              )
            ) {
              this.openSnackBar(err.error);
            }
          },
        })
      );
    }

    openSnackBar(message: string) {
      this.snackBar.open(message, 'Close', {
        duration: 3000, // Duration of the snackbar in milliseconds
        horizontalPosition: 'center',
        verticalPosition: 'bottom',
      });
    }
  }
