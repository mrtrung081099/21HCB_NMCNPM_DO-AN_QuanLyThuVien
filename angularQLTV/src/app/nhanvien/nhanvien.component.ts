import { Component, OnInit } from '@angular/core';
import { FormGroup , FormBuilder, Validators} from '@angular/forms';
import { NhanvienService } from '../services/nhanvien/nhanvien.service';
import { NzMessageService } from 'ng-zorro-antd/message';
@Component({
  selector: 'app-nhanvien',
  templateUrl: './nhanvien.component.html',
  styleUrls: ['./nhanvien.component.scss']
})
export class NhanvienComponent implements OnInit {
  editCache: { [key: string]: { edit: boolean; data: any } } = {};
  totalNv:any;
  pageNum=1;
  pageSize=10;
  search:string | null = null;
  listNhanVien:any;
  currentUser:any;
  infoNhanVienSimple:any;
  tempId:any;
  isVisible = false;
  isOkLoading = false;
  isShowInfoNhanVien = false;
  isCreate:boolean=false;
  isUpdate:boolean=false;
  arrBangCap: Array<string> = ["Cao Đẳng","Đại Học","Thạc Sĩ","Tiến Sĩ","Tú Tài"];
  arrBoPhan: Array<string> = ["Thủ Kho","Thủ Thư","Thủ Quỹ","Ban Giám Đốc"];
  arrChucVu: Array<string> = ["Nhân Viên","Phó Phòng","Trưởng Phòng","Phó Giám Đốc","Giám Đốc"];
  createForm!: FormGroup;
  constructor(private nhanvienService: NhanvienService,private fb: FormBuilder, private message: NzMessageService) { }
  ngOnInit(): void {
    this.currentUser = JSON.parse(localStorage.getItem('currentUser') || '{}');
    this.getAllNhanViens();
  }
  startEdit(data: any): void {
    this.tempId= data.id;
    this.createForm = this.fb.group({
      hoTen: [data.hoTen, Validators.required],
      diaChi: [data.diaChi, Validators.required],
      ngaySinh: [data.ngaySinh, Validators.required],
      sdt: [data.sdt, Validators.required],
      bangCap: [data.bangCap, Validators.required],
      boPhan: [data.boPhan, Validators.required],
      chucVu: [data.chucVu, Validators.required]
    });
    this.isUpdate = true;
    this.isVisible = true;
  }

  cancelEdit(id: string): void {
    const index = this.listNhanVien.findIndex((item:any) => item.id === id);
    this.editCache[id] = {
      data: { ...this.listNhanVien[index] },
      edit: false
    };
  }

  saveEdit(): void {
    const index = this.listNhanVien.findIndex((item:any) => item.id === this.tempId);
    if(this.createForm.valid){
      this.isOkLoading = true;
      this.nhanvienService.UpdateNhanVien(this.tempId,this.createForm.value).subscribe((res:any) => {
        this.message.create('success', "Sửa thành công");
        Object.assign(this.listNhanVien[index], res);
        this.isVisible = false;
        this.isUpdate=false;
        this.isOkLoading = false;
      },
      (err) => {
        console.log(err);
        this.message.create('error', "Đã có lỗi xảy ra");
      });
    }
    else{
      this.message.create('warning', "Vui lòng điền đủ thông tin");
      Object.values(this.createForm.controls).forEach(control => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
    }
  }

  updateEditCache(): void {
    this.listNhanVien.forEach((item:any) => {
      this.editCache[item.id] = {
        edit: false,
        data: { ...item }
      };
    });
  }

  getAllNhanViens(){
    this.nhanvienService.GetAllNhanVienByPaging(this.pageNum,this.pageSize,this.search).subscribe((res:any) => {
      this.listNhanVien = res.listNvs;
      this.totalNv = res.total;
      this.updateEditCache();
    },
    (err) => {
      console.log(err);
    });
  }

  deleteNhanVien(id: string): void {
    this.nhanvienService.DeleteNhanvien(id).subscribe((res:any) => {
      this.message.create('success', "Xóa thành công");
      const index = this.listNhanVien.findIndex((item:any) => item.id === id);
      this.listNhanVien = this.listNhanVien.filter((item:any) => item !== this.listNhanVien[index]);
      this.totalNv--;
    },
    (err) => {
      console.log(err);
      this.message.create('error', "Đã có lỗi xảy ra");
    });
  }

  showModal(): void {
    this.isVisible = true;
    this.isCreate = true;
    this.createForm = this.fb.group({
      hoTen: ["", Validators.required],
      diaChi: ["", Validators.required],
      ngaySinh: ["", Validators.required],
      sdt: ["", Validators.required],
      bangCap: ["", Validators.required],
      boPhan: ["", Validators.required],
      chucVu: ["", Validators.required]
    });
  }

  handleOk(): void {
    if(this.createForm.valid){
      this.isOkLoading = true;
      this.nhanvienService.CreateNhanVien(this.createForm.value).subscribe((res:any) => {
        this.message.create('success', "Thêm thành công");
        this.isVisible = false;
        this.isOkLoading = false;
        this.getAllNhanViens();
      },
      (err) => {
        console.log(err);
        this.isOkLoading = false;
        this.message.create('error', "Đã có lỗi xảy ra");
      });
    }
    else{
      this.message.create('warning', "Vui lòng điền đủ thông tin");
      Object.values(this.createForm.controls).forEach(control => {
        if (control.invalid) {
          control.markAsDirty();
          control.updateValueAndValidity({ onlySelf: true });
        }
      });
    }
  }

  handleCancel(): void {
    this.isVisible = false;
  }

  getByPaging(input:any): void {
    this.pageNum=input;
    this.getAllNhanViens();
  }
  searchNv(isClear:any):void{
    if(isClear){
      this.getAllNhanViens();
    }
    else{
      this.search = null;
      this.getAllNhanViens();
    }
  }
  showInfoSach(data:any){
    this.isShowInfoNhanVien = true;
    this.infoNhanVienSimple=data;
  }
  handleCancelInfo(){
    this.isShowInfoNhanVien = false;
  }
  handleCancelModalCreate(): void {
    this.isVisible = false;
    this.isCreate = false;
    this.isUpdate = false;
  }
}
