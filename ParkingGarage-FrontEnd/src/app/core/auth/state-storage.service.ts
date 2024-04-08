import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class StateStorageService {
  private authenticationKey = 'gst-authenticationToken';

  constructor() {}

  storeAuthenticationToken(authenticationToken: string): void {
    authenticationToken = JSON.stringify(authenticationToken);
    this.clearAuthenticationToken();

    localStorage.setItem(this.authenticationKey, authenticationToken);
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
