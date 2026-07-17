import { Status } from '../enums/status.enum';

export interface VerificationDto {
  id: string;
  url: string;
  status: Status;
  latency: string;
}
