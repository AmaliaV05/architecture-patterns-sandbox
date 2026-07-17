import { Component, OnInit } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import { debounceTime, distinctUntilChanged, switchMap } from 'rxjs/operators';
import { ProductDto } from '../../dtos/product.dto';
import { ProductService } from '../../services/product.service';
import { AsyncPipe, CommonModule } from '@angular/common';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [
    CommonModule,
    AsyncPipe
  ],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css',
})
export class ProductListComponent implements OnInit {
  private searchProduct = new Subject<string>();
  products$!: Observable<ProductDto[]>;

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.products$ = this.searchProduct.pipe(
      debounceTime(500),
      distinctUntilChanged(),
      switchMap((productName: string) => this.productService.getProductsByName(productName))
    );
  }

  onSearchInput(event: Event): void {
    const value = (event.target as HTMLInputElement).value;
    this.searchProduct.next(value);
  }
}
