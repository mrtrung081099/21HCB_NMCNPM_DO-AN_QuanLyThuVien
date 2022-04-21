import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd/message';
import { DocgiaService } from '../services/docgia/docgia.service';
import { NhanvienService } from '../services/nhanvien/nhanvien.service';
import { PhieumatService } from '../services/phieumat/phieumat.service';
import { SachService } from '../services/sach/sach.service';

@Component({
  selector: 'app-phieumat',
  templateUrl: './phieumat.component.html',
  styleUrls: ['./phieumat.component.scss']
})
export class PhieumatComponent implements OnInit {
  listPhieuMat:any[]=[];
  listDocGia:any[]=[];
  listNhanVien:any[]=[];
  listSach:any[]=[];
  total:number=0;
  pageNum:number=1;
  pageSize:number=10;
  isVisible:boolean=false;
  isOkLoading:boolean=false;
  isShowDetai:boolean=false;
  phieuMatInFo:any;
  createForm!: FormGroup;

  constructor(
    private phieumatService:PhieumatService,
    private fb: FormBuilder,
    private docgiaService: DocgiaService,
    private sachService: SachService,
    private nhanvienService:NhanvienService,
    private message: NzMessageService

  ) { }

  ngOnInit() {
    this.getAllPhieuMat();
    this.getAllDocGia();
    this.getListNhanVien();
  }
  getAllPhieuMat(){
    this.phieumatService.GetAllPhieuMat(this.pageNum,this.pageSize).subscribe((res: any) => {
      this.listPhieuMat = res.listPhieuMatSachs;
      this.total = res.total;
    }, (err) => {
      console.log(err);
    });
  }
  getAllDocGia(){
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
  getSachMuonByDocGiaId(docgiaId:any){
    this.sachService.GetSachMuonByDocGiaId(docgiaId).subscribe((res: any) => {
      if(res.length>0){
        this.listSach = res;
      }else{
        this.message.create('warning', "Độc giả không có sách mượn");
      }
    }, (err) => {
      console.log(err);
    });
  }
  showModalCreate(){
    this.isVisible=true;
    this.createForm = this.fb.group({
      sachId: ["", Validators.required],
      docGiaId: ["", Validators.required],
      nhanVienId: ["", Validators.required],
      ngayGhiNhan: ["", Validators.required],
      tienPhat: ["", Validators.required],
    });
  }
  getDetailPhieuMat(data:any){
    this.phieuMatInFo = data;
    this.isShowDetai = true;
  }
  getByPaging(pageNum:number){
    this.pageNum = pageNum;
    this.getAllPhieuMat();
  }
  handleCancelModalCreate(){
    this.isVisible = false;
  }
  handleOk(){
    if(this.createForm.valid){
      console.log(this.createForm.value);
      this.phieumatService.CreatePhieuMat(this.createForm.value).subscribe((res: any) => {
        console.log(res);
        this.message.create('success', "Ghi nhận mất sách thành công");
        this.isVisible =false;
        this.getAllPhieuMat();
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
  handleCancel2(){
    this.isShowDetai = false;
  }
  onSelectDocGia(docgiaId:any){
    this.getSachMuonByDocGiaId(docgiaId);
  }
  onSelectSach(sachId:any){
    this.sachService.GetSachById(sachId).subscribe((res: any) => {
        this.createForm.get('tienPhat')?.setValue(res.gia);
    }, (err) => {
      console.log(err);
    });
  }
}
