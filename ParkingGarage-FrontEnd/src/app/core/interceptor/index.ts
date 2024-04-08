import { HTTP_INTERCEPTORS } from '@angular/common/http';

import { AuthInterceptor } from '../interceptor/auth.interceptor'
import { AuthExpiredInterceptor } from '../interceptor/auth-expired.interceptor';
import { ErrorHandlerInterceptor } from '../interceptor/error-handler.interceptor';
import { NotificationInterceptor } from '../interceptor/notification.interceptor';

export const httpInterceptorProviders = [
  {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true,
  },
  {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthExpiredInterceptor,
    multi: true,
  },
  {
    provide: HTTP_INTERCEPTORS,
    useClass: ErrorHandlerInterceptor,
    multi: true,
  },
  {
    provide: HTTP_INTERCEPTORS,
    useClass: NotificationInterceptor,
    multi: true,
  },
];
