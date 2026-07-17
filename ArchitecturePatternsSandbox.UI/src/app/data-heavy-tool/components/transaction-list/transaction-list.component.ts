import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { TransactionService } from '../../services/transaction.service';
import { TransactionDto as TransactionDto } from '../../dtos/transaction.dto';
import { TransactionType } from '../../enums/transaction-type.enum';
import { PagedResult } from '../../models/paged-result.model';

@Component({
  selector: 'app-transaction-list',
  standalone: true,
  imports: [
    CommonModule,
  ],
  templateUrl: './transaction-list.component.html',
  styleUrl: './transaction-list.component.css',
})
export class TransactionListComponent implements OnInit {
  transactions: TransactionDto[] = [];
  transactionType = TransactionType;

  constructor(private transactionService: TransactionService) {}

  ngOnInit(): void {
    this.getTransactions(1, 10);
  }

  getTransactions(page: number, pageSize: number) {
    this.transactionService.getTransactions(page, pageSize).subscribe({
      next: (result: PagedResult<TransactionDto>) => {
        this.transactions = result.data;
        console.log('Transactions fetched successfully:', result);
      },
      error: (error) => {
        console.error('Error fetching transactions:', error);
      },
    });
  }
}
