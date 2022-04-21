import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NZ_I18N } from 'ng-zorro-antd/i18n';
import { en_US } from 'ng-zorro-antd/i18n';
import { registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { IconsProviderModule } from './icons-provider.module';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NhanvienComponent } from './nhanvien/nhanvien.component';
import { RouterModule } from '@angular/router';
import { DocgiaComponent } from './docgia/docgia.component';
import { LoginComponent } from './login/login.component';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzInputModule } from 'ng-zorro-antd/input';
import { ReactiveFormsModule } from '@angular/forms';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { NzGridModule } from 'ng-zorro-antd/grid';
import { NzAvatarModule } from 'ng-zorro-antd/avatar';
import { NzDropDownModule } from 'ng-zorro-antd/dropdown';
import { NzMessageModule } from 'ng-zorro-antd/message';
import { NzTableModule } from 'ng-zorro-antd/table';
import { NzSelectModule } from 'ng-zorro-antd/select';
import { NzPopconfirmModule } from 'ng-zorro-antd/popconfirm';
import { NzDatePickerModule } from 'ng-zorro-antd/date-picker';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzPaginationModule } from 'ng-zorro-antd/pagination';
import { NzSpinModule } from 'ng-zorro-antd/spin';
import { NzInputNumberModule } from 'ng-zorro-antd/input-number';
import { SachComponent } from './sach/sach.component';
import { PhieumuonComponent } from './phieumuon/phieumuon.component';
import { PhieutraComponent } from './phieutra/phieutra.component';
import { PhieuphatComponent } from './phieuphat/phieuphat.component';
import { PhieumatComponent } from './phieumat/phieumat.component';
import { ThanhlysachComponent } from './thanhlysach/thanhlysach.component';
registerLocaleData(en);

@NgModule({
  declarations: [
    AppComponent,
    NhanvienComponent,
    DocgiaComponent,
    LoginComponent,
    SachComponent,
    PhieumuonComponent,
    PhieutraComponent,
    PhieuphatComponent,
      PhieumatComponent,
      ThanhlysachComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    IconsProviderModule,
    NzLayoutModule,
    NzMenuModule,
    NzFormModule,
    NzInputModule,
    ReactiveFormsModule,
    NzIconModule,
    NzButtonModule,
    NzGridModule,
    NzAvatarModule,
    NzDropDownModule,
    NzMessageModule,
    NzTableModule,
    NzSelectModule,
    NzPopconfirmModule,
    NzDatePickerModule,
    NzModalModule,
    NzPaginationModule,
    NzSpinModule,
    NzInputNumberModule,
    RouterModule.forRoot([
      { path: 'login', component: LoginComponent,pathMatch: 'full' },
      { path: 'nhanviens', component: NhanvienComponent, pathMatch: 'full'},
      { path: 'docgias', component: DocgiaComponent, pathMatch: 'full' },
      { path: 'sachs', component: SachComponent, pathMatch: 'full' },
      { path: 'phieumuons', component: PhieumuonComponent, pathMatch: 'full' },
      { path: 'phieutras', component: PhieutraComponent, pathMatch: 'full' },
      { path: 'phieuphats', component: PhieuphatComponent, pathMatch: 'full' },
      { path: 'phieumats', component: PhieumatComponent, pathMatch: 'full' },
      { path: 'thanhlysachs', component: ThanhlysachComponent, pathMatch: 'full' }
    ], {
      onSameUrlNavigation: 'reload'
    })
  ],
  providers: [{ provide: NZ_I18N, useValue: en_US }],
  bootstrap: [AppComponent]
})
export class AppModule { }
