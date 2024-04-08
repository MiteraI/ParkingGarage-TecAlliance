import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class StateStorageService {
  private authenticationKey = 'gst-authenticationToken';

  constructor() {}

  storeAuthenticationToken(
    authenticationToken: string,
    rememberMe: boolean
  ): void {
    authenticationToken = JSON.stringify(authenticationToken);
    this.clearAuthenticationToken();
    if (rememberMe) {
      localStorage.setItem(this.authenticationKey, authenticationToken);
    } else {
      sessionStorage.setItem(this.authenticationKey, authenticationToken);
    }
  }

  getAuthenticationToken(): string | null {
    const authenticationToken =
      localStorage.getItem(this.authenticationKey) ??
      sessionStorage.getItem(this.authenticationKey);
    return authenticationToken
      ? (JSON.parse(authenticationToken) as string | null)
      : authenticationToken;
  }

  clearAuthenticationToken(): void {
    sessionStorage.removeItem(this.authenticationKey);
    localStorage.removeItem(this.authenticationKey);
  }
}
