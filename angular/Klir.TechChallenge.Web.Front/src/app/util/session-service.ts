import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';

@Injectable({
  providedIn: 'root'
})
export class SessionService {
  private sessionCartId: string;

  constructor() {
    
    let storedGuid = localStorage.getItem('myCartId');
    if( storedGuid == null || storedGuid == undefined ){
      storedGuid = Guid.create().toString();
      localStorage.setItem('myCartId', storedGuid);
    }
    
    this.sessionCartId = storedGuid;
  }

  getCartId(): string {
    return this.sessionCartId;
  }
}