import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from '../../common/services/api.service';
import { TransactionDto } from '../dtos/transaction.dto';
import { PagedResult } from '../models/paged-result.model';

@Injectable({
  providedIn: 'root',
})
export class TransactionService {
  constructor(private apiService: ApiService) {}

  getTransactions(page: number, pageSize: number): Observable<PagedResult<TransactionDto>> {
    return this.apiService.get(`Transactions/Page/${page}/PageSize/${pageSize}`);
  }
}
