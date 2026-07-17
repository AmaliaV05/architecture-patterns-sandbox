import { Injectable } from '@angular/core';
import { Order } from '../dtos/order.dto';
import { Observable } from 'rxjs';
import { ApiService } from '../../common/services/api.service';

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  constructor(private apiService: ApiService) {}

  placeOrder(order: Order, promoCode: string): Observable<Order> {
    return this.apiService.post(`ECommerceLite/Promo/${promoCode}`, order);
  }
}
