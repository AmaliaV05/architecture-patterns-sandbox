import { Routes } from '@angular/router';
import { SettingListComponent } from './admin-tool/components/setting-list/setting-list.component';
import { VerificationListComponent } from './status-check-system/verification-log-list/verification-list.component';
import { OrderComponent } from './ecommerce-lite-ui/components/order/order.component';

export const routes: Routes = [
  { path: 'settings', component: SettingListComponent },
  { path: 'verification-log',  component: VerificationListComponent },
  { path: 'order', component: OrderComponent },
];
