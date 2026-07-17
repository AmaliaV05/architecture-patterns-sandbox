import { Injectable } from '@angular/core';
import { ApiService } from '../../common/services/api.service';
import { VisualSettings } from '../configuration/visual-settings.config';
import { Observable } from 'rxjs';
import { SettingDto } from '../dtos/setting.dto';

@Injectable({
  providedIn: 'root',
})
export class SettingsService {
  constructor(private apiService: ApiService) {}

  getSettings(): Observable<VisualSettings> {
    return this.apiService.get<VisualSettings>('Settings/Current-Settings');
  }

  updateSettings(settings: SettingDto[]): Observable<void> {
    return this.apiService.put<void, SettingDto[]>(
      'Settings/Update-Settings',
      settings,
    );
  }

  refreshSettings(): Observable<VisualSettings> {
    return this.apiService.post<VisualSettings, null>(
      'Settings/Refresh-Settings',
      null,
    );
  }
}
