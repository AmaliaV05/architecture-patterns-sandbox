import { Component, DestroyRef, inject, Inject, Renderer2 } from '@angular/core';
import { VisualSettings } from '../../configuration/visual-settings.config';
import { SettingsService } from '../../services/settings.services';
import { CommonModule, DOCUMENT } from '@angular/common';
import { SettingDto } from '../../dtos/setting.dto';
import { Theme } from '../../enums/theme.enum';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatIconModule } from '@angular/material/icon';
import { MatChipsModule } from '@angular/material/chips';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faLightbulb as darkThemeLightbulb } from '@fortawesome/free-solid-svg-icons';
import { faLightbulb as lightThemeLightbulb } from '@fortawesome/free-regular-svg-icons';
import { faCircleCheck as maintenanceModeOnCircle } from '@fortawesome/free-solid-svg-icons';
import { faCircleXmark as maintenanceModeOffCircle } from '@fortawesome/free-regular-svg-icons';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { SkillCategory } from '../../../common/models/skill-category.model';
import { adminToolCategories } from '../../constants/skills.constant';

@Component({
  selector: 'app-setting-list',
  standalone: true,
  imports: [
    CommonModule,
    MatButtonModule,
    MatCardModule,
    MatDividerModule,
    MatIconModule,
    FontAwesomeModule,
    MatChipsModule,
  ],
  templateUrl: './setting-list.component.html',
  styleUrl: './setting-list.component.css',
})
export class SettingListComponent {
  settings: VisualSettings = {
    theme: '',
    maintenanceMode: false,
  };
  isMaintenanceModeOn: boolean = false;
  darkTheme = darkThemeLightbulb;
  lightTheme = lightThemeLightbulb;
  maintenanceModeOn = maintenanceModeOnCircle;
  maintenanceModeOff = maintenanceModeOffCircle;
  categories: SkillCategory[] = adminToolCategories;

  private destroyRef$ = inject(DestroyRef);

  constructor(
    private settingsService: SettingsService,
    private renderer: Renderer2,
    @Inject(DOCUMENT) private document: Document,
  ) {}

  ngOnInit(): void {
    this.getSettings();
  }

  getSettings(): void {
    this.settingsService
      .getSettings()
      .pipe(takeUntilDestroyed(this.destroyRef$))
      .subscribe((response) => {
        this.settings = response;
        this.applyTheme(this.settings.theme);
        this.isMaintenanceModeOn = this.settings.maintenanceMode;
      });
  }

  updateSettings(): void {
    let settings: SettingDto[] = [
      { key: 'VisualSettings:Theme', value: this.settings.theme },
      {
        key: 'VisualSettings:MaintenanceMode',
        value: this.settings.maintenanceMode.toString(),
      },
    ];
    this.settingsService.updateSettings(settings).subscribe(() => {
      this.settingsService.refreshSettings().subscribe((response) => {
        this.settings = response;
        this.applyTheme(this.settings.theme);
        this.isMaintenanceModeOn = this.settings.maintenanceMode;
      });
    });
  }

  applyTheme(theme: string) {
    if (theme === Theme.Dark) {
      this.renderer.addClass(this.document.body, 'dark-theme');
    } else {
      this.renderer.removeClass(this.document.body, 'dark-theme');
    }
  }

  changeTheme(theme: string) {
    if (theme === Theme.Dark) {
      this.settings.theme = Theme.Light;
      this.applyTheme(this.settings.theme);
    } else if (theme === Theme.Light) {
      this.settings.theme = Theme.Dark;
      this.applyTheme(this.settings.theme);
    }
  }

  changeMaintenanceMode(mode: boolean) {
    if (mode === true) {
      this.settings.maintenanceMode = false;
      this.isMaintenanceModeOn = false;
    } else if (mode === false) {
      this.settings.maintenanceMode = true;
      this.isMaintenanceModeOn = true;
    }
  }
}
