import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatDividerModule } from '@angular/material/divider';
import { MatButtonModule } from '@angular/material/button';
import { VerificationDto } from '../dtos/VerificationDto';
import { VerificationService } from '../services/verification.service';
import { Status } from '../enums/status.enum';

@Component({
  selector: 'app-verification-list',
  standalone: true,
  imports: [
    CommonModule,
    MatIconModule,
    MatListModule,
    MatDividerModule,
    MatButtonModule,
  ],
  templateUrl: './verification-list.component.html',
  styleUrl: './verification-list.component.css',
})
export class VerificationListComponent implements OnInit {
  verifications: VerificationDto[] = [];
  statusUp = Status.Up;

  constructor(private verificationService: VerificationService) {}

  ngOnInit(): void {
    this.getVerifications();
  }

  getVerifications() {
    this.verificationService
      .getStatus()
      .subscribe((response: VerificationDto[]) => {
        this.verifications = response;
      });
  }

  refreshVerifications(): void {
    this.getVerifications();
  }
}
