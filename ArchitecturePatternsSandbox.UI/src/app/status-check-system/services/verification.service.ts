import { Injectable } from '@angular/core';
import { VerificationDto } from '../dtos/VerificationDto';
import { Observable } from 'rxjs';
import { ApiService } from '../../common/services/api.service';

@Injectable({
  providedIn: 'root',
})
export class VerificationService {
  constructor(private apiService: ApiService) {}

  getStatus(): Observable<VerificationDto[]> {
    return this.apiService.get<VerificationDto[]>('Verification');
  }
}
