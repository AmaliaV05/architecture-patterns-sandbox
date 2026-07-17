import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from '../../common/services/api.service';
import { ProductDto } from '../dtos/product.dto';

@Injectable({
  providedIn: 'root',
})
export class ProductService {
  constructor(private apiService: ApiService) {}

  getProductsByName(productName: string): Observable<ProductDto[]> {
    return this.apiService.get<ProductDto[]>('Product', { params: { productName } });
  }
}
