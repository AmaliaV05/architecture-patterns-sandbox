import { Routes } from '@angular/router';
import { SettingListComponent } from './admin-tool/components/setting-list/setting-list.component';

export const routes: Routes = [
  //{ path: 'settings', loadComponent: () => import('../admin-tool/components/setting-list/setting-list.component').then(m => m.SettingListComponent) },
  { path: 'settings', component: SettingListComponent },
];
