import { Component, OnInit } from '@angular/core';
import { FormGroup , FormBuilder, Validators} from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NhanvienService } from '../services/nhanvien/nhanvien.service';
import { SachService } from '../services/sach/sach.service';

@Component({
  selector: 'app-sach',
  templateUrl: './sach.component.html',
  styleUrls: ['./sach.component.scss']
})

export class SachComponent implements OnInit {
  totalSach:number=0;
  pageNum=1;
  pageSize=10;
  listSach:any[] = [];
  filteredNhanVien:any[] = [];
  stt:any[] = [];
  isShowInfoSach:boolean=false;
  isOkLoading:boolean=false;
  isVisible:boolean=false;
  isCreate:boolean=false;
  isUpdate:boolean=false;
  currentUser:any;
  tempId:any;
  infoSachSimple:any;
  search:string | null = null;
  searchState:string ="";
  arrTypeSach: Array<string> = ["A","B","C"];
  arrStateSach: Array<string> = ["Chưa Mượn","Đã Mượn","Đã Thanh Lý","Đã Mất"];
  createForm!: FormGroup;

  constructor(
    private sachService: SachService,
    private fb: FormBuilder,
    private message: NzMessageService,
    private nhanvienService: NhanvienService
    ) { }

  ngOnInit() {
    this.currentUser = JSON.parse(localStorage.getItem('currentUser') || '{}');
    this.getAllSach();
    this.getAllNhanViens();
  }
  getAllSach(){
    this.sachService.GetAllSach(this.pageNum,this.pageSize).subscribe((res:any) => {
      this.listSach = res.listSachs;
      this.totalSach = res.total;
    },
    (err) => {
      console.log(err);
    });
  }
  getAllByName(){
    this.sachService.GetAllByName(this.pageNum,this.pageSize,this.search).subscribe((res:any) => {
      this.listSach = res.listSachs;
      this.totalSach = res.total;
    },
    (err) => {
      console.log(err);
    });
  }
  getAllByState(){
    this.sachService.GetAllByState(this.pageNum,this.pageSize,this.searchState).subscribe((res:any) => {
      this.listSach = res.listSachs;
      this.totalSach = res.total;
    },
    (err) => {
      console.log(err);
    });
  }
  handleCancel(): void {
    this.isShowInfoSach = false;
  }
  showInfoSach(input:any):void{
    this.infoSachSimple = input;
    this.isShowInfoSach = true;
  }
  showModalCreate(): void {
    this.createForm = this.fb.group({
      ten: ["", Validators.required],
      loai: ["", Validators.required],
      tacGia: ["", Validators.required],
      namSx: ["", Validators.required],
      nhaSx: ["", Validators.required],
      tinhTrang: [this.arrStateSach[0], Validators.required],
      gia: ["", Validators.required],
      ngayTiepNhan:["", Validators.required],
      nhanVienId: ["", Validators.required]
    });
    this.isCreate=true;
    this.isVisible = true;
  }
  handleOk(): void {
    // this.isVisible = false;
    if(this.createForm.valid){
      this.isOkLoading = true;
      this.sachService.CreateSach(this.createForm.value).subscribe((res:any) => {
        this.message.create('success', "Thêm thành công");
        this.isVisible = false;
        this.isCreate = false;
        this.isOkLoading = false;
        this.getAllSach();
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
  handleCancelModalCreate(): void {
    this.isVisible = false;
    this.isCreate = false;
    this.isUpdate = false;
  }
  getAllNhanViens(): void {
    this.nhanvienService.GetAllNhanVien().subscribe((res: any) => {
      this.filteredNhanVien = res.listNvs;
    }, (err) => console.log(err));
  }
  deleteSach(id: string): void {
    this.sachService.DeleteSach(id).subscribe((res:any) => {
      this.message.create('success', "Xóa thành công");
      const index = this.listSach.findIndex((item:any) => item.id === id);
      this.listSach = this.listSach.filter((item:any) => item !== this.listSach[index]);
      this.totalSach--;
    },
    (err) => {
      console.log(err);
      this.message.create('error', "Đã có lỗi xảy ra");
    });
  }
  startEdit(input:any){
    this.tempId= input.id;
    this.createForm = this.fb.group({
      ten: [input.ten, Validators.required],
      loai: [input.loai, Validators.required],
      tacGia: [input.tacGia, Validators.required],
      namSx: [input.namSx, Validators.required],
      nhaSx: [input.nhaSx, Validators.required],
      tinhTrang: [input.tinhTrang, Validators.required],
      gia: [input.gia, Validators.required],
      ngayTiepNhan:[input.ngayTiepNhan, Validators.required],
      nhanVienId: [input.nhanVienId, Validators.required]
    });
    this.isUpdate=true;
    this.isVisible = true;
  }
  saveEdit(): void {
    const index = this.listSach.findIndex((item: any) => item.id === this.tempId);
    if(this.createForm.valid){
      this.isOkLoading = true;
      this.sachService.UpdateSach(this.tempId,this.createForm.value).subscribe((res:any) => {
        this.message.create('success', "Sửa thành công");
        Object.assign(this.listSach[index], res);
        this.isVisible = false;
        this.isUpdate=false;
        this.isOkLoading = false;
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
  getByPaging(input: any): void {
    this.pageNum = input;
    this.getAllSach();
  }
  searchSach(isClear: any): void {
    if (isClear) {
      this.getAllByName();
    }
    else {
      this.search = '';
      this.getAllSach();
    }
  }
  searchSachByState(state:string){
    this.searchState = state;
    if(this.searchState == null){
      this.getAllSach();
    }else{
      this.getAllByState();
    }
  }
  onChangeNhanVien(id:any){
    if(id != ""){
      const index = this.filteredNhanVien.findIndex((item: any) => item.id === id);
      if(this.filteredNhanVien[index].boPhan != "Thủ Kho"){
        this.createForm.controls['nhanVienId'].setValue("");
        this.message.create('warning', "Người nhận sách phải là nhân viên thuộc bộ phận Thủ Kho");
      }
    }
  }
  onChangeYear(year: Date){
    // console.log(year.getFullYear());
    // var today = new Date();
    // var age = today.getFullYear() - date.getFullYear();
    if(year.toString() != ""){
      var today = new Date();
      var age = today.getFullYear() - year.getFullYear();
      var m = today.getMonth() - year.getMonth();
      if (m < 0 || (m === 0 && today.getDate() < year.getDate())) {
          age--;
      }
      if(age > 8){
        this.createForm.controls['namSx'].setValue("");
        this.message.create('warning', "Chỉ nhận các sách xuất bản trong vòng 8 năm");
      }
    }
  }
}
