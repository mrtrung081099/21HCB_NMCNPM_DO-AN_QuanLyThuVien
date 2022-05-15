import { Component } from '@angular/core';
import { AuthService } from './services/auth/auth.service';
import { NzMessageService } from 'ng-zorro-antd/message';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  isCollapsed = false;
  isLogin: any;
  user: any;
  tenNhanVien:any;
  constructor(private authService: AuthService,private message: NzMessageService,public router: Router) {}

  ngOnInit() {
    this.checkLogin();
  }
  checkLogin() {
    var user = JSON.parse(localStorage.getItem('currentUser') || '{}');
    if (user.id) {
      this.isLogin = false;
      this.tenNhanVien = user.email;
    } else {
      this.router.navigate(['login']);
      this.isLogin = true;
    }
  }
  logOut(){
    this.authService.LogOut();
    this.message.create('success', "Đăng xuất thành công");
  }
}
