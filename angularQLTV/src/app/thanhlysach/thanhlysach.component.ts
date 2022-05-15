import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NhanvienService } from '../services/nhanvien/nhanvien.service';
import { SachService } from '../services/sach/sach.service';
import { ThanhlysachService } from '../services/thanhlysach/thanhlysach.service';

@Component({
  selector: 'app-thanhlysach',
  templateUrl: './thanhlysach.component.html',
  styleUrls: ['./thanhlysach.component.scss']
})
export class ThanhlysachComponent implements OnInit {
  createForm!: FormGroup;
  listThanhLySach:any[]=[];
  listNhanVien:any[]=[];
  listSachThanhLyTemp:any[]=[];
  listSachThanhLy:any[] = [];
  listSach:any[] = []
  listLyDo:any[] = ["Mất","Hư Hỏng","Người Dùng Làm Mất"]
  total:number=0;
  pageNum:number=1;
  pageSize:number=10;
  isVisible:boolean=false;
  isOkLoading:boolean=false;
  isAddSach:boolean=true;
  isShowDetai:boolean=false;
  thanhLySachInFo:any;
  selectSach:any;
  selectLyDo:any;
  dataSachTemp={
    sachId:null,
    tenSach:null,
    lyDoThanhLy:null
  };
  dataSachThanhLyTemp={
    sachId:null,
    lyDoThanhLy:null
  };
  constructor(
    private sachService: SachService,
    private fb: FormBuilder,
    private message: NzMessageService,
    private nhanvienService:NhanvienService,
    private thanhlysachService:ThanhlysachService
  ) { }

  ngOnInit() {
    this.getAllThanhLySach();
    this.getAllSach();
    this.getAllNhanVien();
  }
  getAllThanhLySach(){
    this.thanhlysachService.GetAllThanhLySach(this.pageNum,this.pageSize).subscribe((res: any) => {
      this.listThanhLySach = res.listThanhLySachs;
      this.total = res.total;
    }, (err) => {
      console.log(err);
      this.message.create('error', "Đã có lỗi xảy ra");
    });
  }
  getAllSach(){
    this.sachService.GetAllSachNoPaging().subscribe((res: any) => {
      this.listSach = res;
    }, (err) => {
      console.log(err);
    });
  }
  getAllNhanVien(){
    this.nhanvienService.GetAllNhanVien().subscribe((res: any) => {
      this.listNhanVien = res.listNvs;
    }, (err) => {
      console.log(err);
    });
  }
  showModalCreate(){
    this.isVisible = true;
    this.createForm = this.fb.group({
      nhanVienId: ["", Validators.required],
      ngayThanhLy: ["", Validators.required],
      sachThanhLys: [this.listSachThanhLy],
    });
  }
  getDetailThanhLySach(data:any){
    this.thanhLySachInFo = data;
    this.isShowDetai = true;
  }
  getByPaging(pageNum:any){
    this.pageNum = pageNum;
    this.getAllThanhLySach();
  }
  handleCancelModalCreate(){
    this.isVisible = false;
    this.listSachThanhLy = [];
    this.listSachThanhLyTemp = [];
  }
  handleOk(){
    if(this.createForm.valid && this.listSachThanhLy.length > 0){
      this.thanhlysachService.CreateThanhLySach(this.createForm.value).subscribe((res: any) => {
        this.message.create('success', "Thêm phiếu mượn thành công");
        this.listSachThanhLy=[];
        this.listSachThanhLyTemp=[];
        this.isVisible =false;
        this.getAllThanhLySach();
      }, (err) => {
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
  delSach(data:any){
    const index = this.listSachThanhLyTemp.findIndex((item:any) => item.sachId === data.sachId);
    const index2 = this.listSachThanhLy.findIndex((item:any) => item.sachId === data.sachId);
    this.listSachThanhLyTemp = this.listSachThanhLyTemp.filter((item:any) => item !== this.listSachThanhLyTemp[index]);
    this.listSachThanhLy = this.listSachThanhLy.filter((item:any) => item !== this.listSachThanhLy[index2]);
    this.createForm.value.sachThanhLys = this.listSachThanhLy;
    this.sachService.GetSachById(data.sachId).subscribe((res: any) => {
      this.listSach.push(res);
    }, (err) => {
      console.log(err);
    });
  }
  onChangeListSachTemp(data:any){
    this.dataSachTemp.sachId = data.id;
    this.dataSachThanhLyTemp.sachId=data.id
    this.dataSachTemp.tenSach = data.ten;
    const index = this.listSach.findIndex((item:any) => item.id === data.id);
    this.listSach = this.listSach.filter((item:any) => item !== this.listSach[index]);
    if(this.dataSachTemp.lyDoThanhLy != null){
      this.listSachThanhLyTemp.push(this.dataSachTemp);
      this.listSachThanhLy.push(this.dataSachThanhLyTemp);
      this.isAddSach = false;
    }
  }
  cancel(){
    this.isAddSach = false;
  }
  addSach(){
    this.isAddSach = true;
    this.selectLyDo="";
    this.selectSach="";
    this.dataSachTemp = {
      sachId:null,
      tenSach:null,
      lyDoThanhLy:null
    };
    this.dataSachThanhLyTemp={
      sachId:null,
      lyDoThanhLy:null
    };
  }
  handleCancel2(){
    this.isShowDetai = false;
  }
  onChangeLyDo(input:any){
    this.dataSachTemp.lyDoThanhLy = input;
    this.dataSachThanhLyTemp.lyDoThanhLy = input;
    if(this.dataSachTemp.sachId != null){
      this.listSachThanhLyTemp.push(this.dataSachTemp);
      this.listSachThanhLy.push(this.dataSachThanhLyTemp);
      this.isAddSach = false;
    }
  }
  onChangeNhanVien(nhanVienId:any){
    if(nhanVienId != ''){
      const index = this.listNhanVien.findIndex(
      (item: any) => item.id === nhanVienId
      );
      if(this.listNhanVien[index].boPhan != 'Thủ Kho'){
        this.message.create('error', "Người thanh lý sách phải là nhân viên thuộc bộ phận thủ kho");
        this.createForm.controls['nhanVienId'].setValue('');
      }
    }
  }
}
