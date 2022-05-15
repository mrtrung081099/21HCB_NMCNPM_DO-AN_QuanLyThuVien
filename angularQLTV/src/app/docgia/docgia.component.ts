import { NhanvienService } from './../services/nhanvien/nhanvien.service';
import { DocGiaForCreationUpdateDto, DocgiaService } from './../services/docgia/docgia.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd/message';

@Component({
  selector: 'app-docgia',
  templateUrl: './docgia.component.html',
  styleUrls: ['./docgia.component.scss']
})
export class DocgiaComponent implements OnInit {
  editCache: { [key: string]: { edit: boolean; data: any } } = {};
  createForm!: FormGroup;
  pageNum: number = 1;
  pageSize: number = 10;
  isVisible: boolean = false;
  isOkLoading: boolean = false;
  isShowInfoDocGia: boolean = false;
  isUpdate: boolean = false;
  isCreate: boolean = false;
  infoDocGiaSimple:any;
  tempId:any;
  totalDG: number = 0;
  search: string = '';
  listDocGia: any[] = [];
  currentUser: any;
  filteredNhanVien: any[] = [];
  arrLoai: Array<string> = ["X", "Y"];

  constructor(
    private fb: FormBuilder,
    private message: NzMessageService,
    private _docgiaService: DocgiaService,
    private _nhanvienService: NhanvienService,
  ) { }

  ngOnInit(): void {
    this.currentUser = JSON.parse(localStorage.getItem('currentUser') || '{}');
    this.getAllDocGias();
    this.getAllNhanViens();

  }

  getAllDocGias() {
    this._docgiaService.GetAllDocGia(this.pageNum, this.pageSize, this.search).subscribe((res: any) => {
      this.listDocGia = res.listDgs;
      this.totalDG = res.total;
      this.updateEditCache();

    }, (err) => {
      console.log(err);
      this.message.create('error', "Đã có lỗi xảy ra");
    });
  }

  getAllNhanViens() {
    this._nhanvienService.GetAllNhanVien().subscribe((res: any) => {
      this.filteredNhanVien = res.listNvs;
    }, (err) => console.log(err));
  }

  startEdit(data: any): void {
    this.tempId= data.id;
    this.createForm = this.fb.group({
      hoTen: [data.hoTen, Validators.required],
      loai: [data.loai, Validators.required],
      ngaySinh: [data.ngaySinh, Validators.required],
      diaChi: [data.diaChi, Validators.required],
      email: [data.email, Validators.required],
      ngayLap: [data.ngayLap, Validators.required],
      tongNo: [0, Validators.required],
      nhanVienId: [data.nhanVienId, Validators.required]
    });
    this.isUpdate=true;
    this.isVisible = true;
  }

  cancelEdit(id: string): void {
    const index = this.listDocGia.findIndex((item: any) => item.id === id);
    this.editCache[id] = {
      data: { ...this.listDocGia[index] },
      edit: false
    };
  }

  saveEdit(): void {
    const index = this.listDocGia.findIndex((item: any) => item.id === this.tempId);
    if(this.createForm.valid){
      this._docgiaService.UpdateDocGia(this.tempId,this.createForm.value).subscribe((res: any) => {
        this.message.create('success', "Sửa thành công");
        Object.assign(this.listDocGia[index], res);
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
    this.listDocGia.forEach((item: any) => {
      this.editCache[item.id] = {
        edit: false,
        data: { ...item }
      };
    });
  }

  deleteDocGia(id: string): void {
    this._docgiaService.DeleteDocGia(id).subscribe((res: any) => {
      this.message.create('success', "Xóa thành công");
      const index = this.listDocGia.findIndex((item: any) => item.id === id);
      this.listDocGia = this.listDocGia.filter((item: any) => item !== this.listDocGia[index]);
      this.totalDG--;
    },
      (err) => {
        console.log(err);
        this.message.create('error', "Đã có lỗi xảy ra");
      });
  }

  showModal(): void {
    this.createForm = this.fb.group({
      hoTen: ["", Validators.required],
      loai: ["", Validators.required],
      ngaySinh: ["", Validators.required],
      diaChi: ["", Validators.required],
      email: ["", Validators.required],
      ngayLap: ["", Validators.required],
      tongNo: [0, Validators.required],
      nhanVienId: ["", Validators.required]
    });
    this.isVisible = true;
    this.isCreate = true;
  }

  handleOk(): void {
    if (this.createForm.valid) {
      this.isOkLoading = true;
      let formValue = this.createForm.value;
      let req = Object.assign({}, formValue) as DocGiaForCreationUpdateDto;
      this._docgiaService.CreateDocGia(req).subscribe((res: any) => {
        this.message.create('success', "Thêm thành công");
        this.isVisible = false;
        this.isOkLoading = false;
        this.getAllDocGias();
      },
        (err) => {
          console.log(err);
          this.isOkLoading = false;
          this.message.create('error', "Đã có lỗi xảy ra");
        });
    }
    else {
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
  handleCancelInfo(): void {
    this.isShowInfoDocGia = false;
  }
  getByPaging(input: any): void {
    this.pageNum = input;
    this.getAllDocGias();
  }

  searchNv(isClear: any): void {
    if (isClear) {
      this.getAllDocGias();
    }
    else {
      this.search = '';
      this.getAllDocGias();
    }
  }
  showInfoDocGia(data:any){
    this.infoDocGiaSimple = data;
    this.isShowInfoDocGia = true
  }
  onChangeDate(date:Date){
    if(date.toString() != ""){
      var today = new Date();
      var age = today.getFullYear() - date.getFullYear();
      var m = today.getMonth() - date.getMonth();
      if (m < 0 || (m === 0 && today.getDate() < date.getDate())) {
          age--;
      }
      if(!(18<age && age<=55)){
        this.createForm.controls['ngaySinh'].setValue("");
        this.message.create('warning', "Tuổi độc giả từ 18 đến 55");
      }
    }
  }
  onChangeNhanVien(id:any){
    if(id != ""){
      const index = this.filteredNhanVien.findIndex((item: any) => item.id === id);
      if(this.filteredNhanVien[index].boPhan != "Thủ Thư"){
        this.createForm.controls['nhanVienId'].setValue("");
        this.message.create('warning', "Người lập thẻ độc giả phải là nhân viên thuộc bộ phận thủ thư");
      }
    }
  }
  handleCancelModalCreate(): void {
    this.isVisible = false;
    this.isCreate = false;
    this.isUpdate = false;
  }
}
