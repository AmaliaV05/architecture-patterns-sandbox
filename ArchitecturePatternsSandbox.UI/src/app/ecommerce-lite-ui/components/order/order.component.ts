import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { OrderService } from '../../services/order.service';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { Order } from '../../dtos/order.dto';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-order',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
  ],
  templateUrl: './order.component.html',
  styleUrl: './order.component.css',
})
export class OrderComponent {
  orderForm: FormGroup = new FormGroup({
    product: new FormControl(''),
    totalAmount: new FormControl(0),
    customerEmail: new FormControl(''),
  });

  constructor(private orderService: OrderService) {}

  placeOrder() {
    if (this.orderForm.valid) {
      let order: Order = {
        productName: this.orderForm.value.product as string,
        totalAmount: this.orderForm.value.totalAmount as number,
        customerEmail: this.orderForm.value.customerEmail as string,
      };
      this.orderService.placeOrder(order, 'BL2026').subscribe({
        next: (order) => {
          console.log('Order placed successfully:', order);
        },
        error: (error) => {
          console.error('Error placing order:', error);
        },
      });
    }
  }
}
