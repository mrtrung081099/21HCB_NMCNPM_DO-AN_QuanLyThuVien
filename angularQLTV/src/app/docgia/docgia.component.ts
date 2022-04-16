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
    this.createForm = this.fb.group({
      hoTen: ["", Validators.required],
      loai: ["", Validators.required],
      ngaySinh: ["", Validators.required],
      diaChi: ["", Validators.required],
      email: ["", Validators.required],
      ngayLap: ["", Validators.required],
      tongNo: ["", Validators.required],
      nhanVienId: ["", Validators.required]
    });
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
      console.log(res);
      this.filteredNhanVien = res.listNvs;
    }, (err) => console.log(err));
  }

  startEdit(id: string): void {
    this.editCache[id].edit = true;
  }

  cancelEdit(id: string): void {
    const index = this.listDocGia.findIndex((item: any) => item.id === id);
    this.editCache[id] = {
      data: { ...this.listDocGia[index] },
      edit: false
    };
  }

  saveEdit(id: string): void {
    const index = this.listDocGia.findIndex((item: any) => item.id === id);
    Object.assign(this.listDocGia[index], this.editCache[id].data);
    this._docgiaService.UpdateDocGia(id, this.listDocGia[index]).subscribe((res: any) => {
      this.message.create('success', "Sửa thành công");
      this.editCache[id].edit = false;
      this.getAllDocGias();
    },
      (err) => {
        console.log(err);
        this.message.create('error', "Đã có lỗi xảy ra");
      });
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
    this.isVisible = true;
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

}
