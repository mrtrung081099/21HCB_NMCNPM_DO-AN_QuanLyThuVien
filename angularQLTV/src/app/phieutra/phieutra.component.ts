import { Component, OnInit } from '@angular/core';
import { FormGroup , FormBuilder, Validators} from '@angular/forms';
import { NzMessageService } from 'ng-zorro-antd/message';
import { DocgiaService } from '../services/docgia/docgia.service';
import { PhieutraService } from '../services/phieutra/phieutra.service';
import { SachService } from '../services/sach/sach.service';

@Component({
  selector: 'app-phieutra',
  templateUrl: './phieutra.component.html',
  styleUrls: ['./phieutra.component.scss']
})
export class PhieutraComponent implements OnInit {
  listPhieuTra:any[]=[];
  listDocGia:any[]=[];
  listSachTraTemp:any[]=[];
  listSach:any[]=[];
  listSachTra:any[]=[];
  total:number=0;
  tienPhat:number=0;
  tienNo:number=0;
  tongNo:number=0;
  pageNum:number=1;
  pageSize:number=10;
  isVisible:boolean=false;
  isOkLoading:boolean=false;
  isShowDetai:boolean=false;
  isAddSach:boolean=true;
  phieuTraInFo:any;
  selectSach:string="";
  createForm!: FormGroup;
  constructor(
    private phieutraService: PhieutraService,
    private message: NzMessageService,
    private fb: FormBuilder,
    private docgiaService: DocgiaService,
    private sachService: SachService,

    ) { }

  ngOnInit() {
    this.getAllPhieuTra();
    this.getAllDocGia();
  }
  getAllPhieuTra(){
    this.phieutraService.GetAllPhieuTra(this.pageNum,this.pageSize).subscribe((res: any) => {
      this.listPhieuTra = res.listPhieuTras;
      this.total = res.total;
    }, (err) => {
      console.log(err);
      this.message.create('error', "Đã có lỗi xảy ra");
    });
  }
  getAllDocGia(){
    this.docgiaService.GetAllDocGiaNoPaging().subscribe((res: any) => {
      this.listDocGia = res.listDgs;
    }, (err) => {
      console.log(err);
    });
  }
  getSachMuonByDocGiaId(docgiaId:any){
    this.sachService.GetSachMuonByDocGiaId(docgiaId).subscribe((res: any) => {
      console.log(res);
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
    this.isVisible = true;
    this.createForm = this.fb.group({
      docGiaId: ["", Validators.required],
      ngayTra: ["", Validators.required],
      tienPhat: [this.tienPhat],
      tienNo: [this.tienNo],
      tongNo: [this.tongNo],
      sachTras: [this.listSachTraTemp],
    });
  }
  getDetailPhieuTra(input:any){
    this.isShowDetai = true;
    this.phieuTraInFo = input;
  }
  getByPaging(input:any){

  }
  handleCancelModalCreate(){
    this.isVisible = false;
  }
  handleOk(){
    console.log(this.createForm.value);
    if(this.createForm.valid && this.listSachTraTemp.length > 0){
      console.log(this.createForm.value);
      this.phieutraService.CreatePhieuTra(this.createForm.value).subscribe((res: any) => {
        console.log(res);
        this.message.create('success', "Thêm phiếu trả thành công");
        this.listSachTraTemp=[];
        this.isVisible =false;
        this.getAllPhieuTra();
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
    this.tienPhat=this.tienPhat - data.tienPhat;
    this.tongNo = this.tongNo - data.tienPhat;
    const index = this.listSachTraTemp.findIndex((item:any) => item.id === data.id);
    this.listSachTraTemp = this.listSachTraTemp.filter((item:any) => item !== this.listSachTraTemp[index]);
    this.listSach.push(data);
    this.createForm.value.sachTras = this.listSachTraTemp;
    this.createForm.value.tienPhat = this.tienPhat;
    this.createForm.value.tongNo = this.tongNo;
  }
  onChangeListSachTemp(input:any){
    this.listSachTraTemp.push(input);
    this.tienPhat=this.tienPhat+input.tienPhat;
    this.tongNo = this.tienNo + this.tienPhat;
    console.log(this.listSachTraTemp);
    this.isAddSach=false;
    this.createForm.value.tienPhat = this.tienPhat;
    this.createForm.value.tongNo = this.tongNo;
    this.selectSach="";
    const index = this.listSach.findIndex((item:any) => item.id === input.id);
    this.listSach = this.listSach.filter((item:any) => item !== this.listSach[index]);
  }
  cancel(){
    this.isAddSach = false;
  }
  addSach(){
    this.isAddSach=true;
  }
  handleCancel2(){
    this.isShowDetai = false;
  }
  onSelectDocGia(docgiaId:any){
    console.log(docgiaId);
    const index = this.listDocGia.findIndex((item:any) => item.id === docgiaId);
    this.tienNo = this.listDocGia[index].tongNo;
    this.createForm.value.tienNo = this.tienNo;
    this.getSachMuonByDocGiaId(docgiaId);
  }
}
