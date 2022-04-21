import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd/message';
import { DocgiaService } from '../services/docgia/docgia.service';
import { NhanvienService } from '../services/nhanvien/nhanvien.service';
import { PhieuphatService } from '../services/phieuphat/phieuphat.service';

@Component({
  selector: 'app-phieuphat',
  templateUrl: './phieuphat.component.html',
  styleUrls: ['./phieuphat.component.scss']
})
export class PhieuphatComponent implements OnInit {
  listPhieuPhat:any[]=[];
  listDocGia:any[]=[];
  listNhanVien:any[]=[];
  total:number=0;
  pageNum:number=1;
  pageSize:number=10;
  isVisible:boolean=false;
  isOkLoading:boolean=false;
  isShowDetai:boolean=false;
  createForm!: FormGroup;
  phieuPhatInFo:any;
  tienThu:number=0;
  tienNo:number=0;
  tienNoConlai:number=0;
  constructor(
    private message: NzMessageService,
    private fb: FormBuilder,
    private phieuphatService:PhieuphatService,
    private docgiaService:DocgiaService,
    private nhanvienService:NhanvienService
    ) { }

  ngOnInit() {
    this.getAllPhieuPhat();
    this.getListDocGia();
    this.getListNhanVien();
  }
  getAllPhieuPhat(){
    this.phieuphatService.GetAllPhieuPhat(this.pageNum,this.pageSize).subscribe((res: any) => {
      this.listPhieuPhat = res.listPhieuPhats;
      this.total = res.total;
    }, (err) => {
      console.log(err);
    });
  }
  getListDocGia(){
    this.docgiaService.GetAllDocGiaNoPaging().subscribe((res: any) => {
      this.listDocGia = res.listDgs;
    }, (err) => {
      console.log(err);
    });
  }
  getListNhanVien(){
    this.nhanvienService.GetAllNhanVien().subscribe((res: any) => {
      this.listNhanVien = res.listNvs;
    }, (err) => {
      console.log(err);
    });
  }
  showModalCreate(){
    this.isVisible = true;
    this.createForm = this.fb.group({
      docGiaId: ["", Validators.required],
      nhanVienId: ["", Validators.required],
      tienThu: [this.tienThu],
      tienNo: [this.tienNo],
      tienNoConlai: [this.tienNoConlai],
    });
  }
  getDetailPhieuPhat(data:any){
    this.isShowDetai = true;
    this.phieuPhatInFo = data;
  }
  getByPaging(pageNum:number){
    this.pageNum=pageNum;
    this.getAllPhieuPhat();
  }
  handleCancelModalCreate(){
    this.isVisible = false;
  }
  handleOk(){
    this.createForm.value.tienNo = this.tienNo;
    this.createForm.value.tienThu = this.tienThu;
    this.createForm.value.tienNoConlai = this.tienNoConlai;
    if(this.createForm.valid && this.tienThu>0){
      console.log(this.createForm.value);
      this.phieuphatService.CreatePhieuPhat(this.createForm.value).subscribe((res: any) => {
        console.log(res);
        this.message.create('success', "Thêm phiếu trả thành công");
        this.isVisible =false;
        this.tienNo = 0;
        this.tienThu = 0;
        this.tienNoConlai = 0;
        this.getAllPhieuPhat();
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
  onSelectDocGia(docgiaId:any){
    const index = this.listDocGia.findIndex((item:any) => item.id === docgiaId);
    this.tienNo = this.listDocGia[index].tongNo;
    if(this.tienNo == 0){
      this.message.create('warning', "Độc giả không bị nợ tiền");
    }
  }
  handleCancel2(){
    this.isShowDetai = false;
  }
  onChangeTienThu(tienThu:number){
    if(tienThu <= this.tienNo){
      this.tienThu = tienThu;
      this.tienNoConlai = this.tienNo - this.tienThu;
    }
    else{
      this.tienNoConlai = 0;
      this.message.create('error', "Tiền thu không vượt tiền nợ");
    }
  }
}
