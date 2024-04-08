import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ApplicationConfigService {
  private endpointPrefix = 'http://localhost:5196';

  constructor() {}

  getEndpointFor(api: string): string {
    return `${this.endpointPrefix}${api}`;
  }
}
