import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth/auth.service';
import { NzMessageService } from 'ng-zorro-antd/message';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  remember = false;
  errorList: any;
  constructor(private fb: FormBuilder,private authService: AuthService, private rout : Router,private message: NzMessageService) { }

  ngOnInit() {
    this.loginForm = this.fb.group({
      email: ["", Validators.required],
      password: ["", Validators.required],
    });
    this.errorList = [];
  }
  submitForm(loginData:any): void {
    if (this.loginForm.valid) {
      this.errorList = [];
      this.authService.Login(loginData).subscribe(
        (res) => {
          this.message.create('success', "Đăng nhập thành công");
          console.log("Đăng nhập thành công");
          this.rout.navigate(['']);
          setTimeout(() => {
            location.reload();
          }, 500);
        },
        (err) => {
          console.log(err);
          if (err.status == 400) {
          this.message.create('error', err.error.password[0]);
            if (err.error.errors == undefined) this.errorList = err.error;
            else this.errorList = err.error.errors;
          }
        }
      );
    }
  }
}
