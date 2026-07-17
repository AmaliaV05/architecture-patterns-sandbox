import { TransactionType } from "../enums/transaction-type.enum";

export interface TransactionDto {
  id: number;
  assetTicker: string;
  transactionType: TransactionType;
  quantity: number;
  pricePerUnit: number;
  transactionDate: Date;
  fee: number;
}