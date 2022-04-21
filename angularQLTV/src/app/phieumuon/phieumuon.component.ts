import { Component, OnInit } from '@angular/core';
import { FormGroup , FormBuilder, Validators} from '@angular/forms';
import { DocgiaService } from '../services/docgia/docgia.service';
import { SachService } from '../services/sach/sach.service';
import { NzMessageService } from 'ng-zorro-antd/message';
import { PhieumuonService } from '../services/phieumuon/phieumuon.service';

@Component({
  selector: 'app-phieumuon',
  templateUrl: './phieumuon.component.html',
  styleUrls: ['./phieumuon.component.scss']
})
export class PhieumuonComponent implements OnInit {
  createForm!: FormGroup;
  isOkLoading:boolean=false;
  isShowDetai:boolean=false;
  isVisible:boolean=false;
  listPhieuMuon:any[] = [];
  listDocGia:any[] = [];
  listSach:any[] = [];
  listSachMuon:any[] = [];
  listSachMuonTemp:any[] = [];
  selectSach:any;
  isAddSach:boolean=true;
  total:number = 0;
  pageNum:number = 1;
  pageSize:number = 10;
  phieuMuonInFo:any;
  constructor(
    private docgiaService: DocgiaService,
    private sachService: SachService,
    private fb: FormBuilder,
    private message: NzMessageService,
    private phieumuonService: PhieumuonService
  ) { }

  ngOnInit() {
    this.getAllPhieuMuon();
    this.getAllDocGia();
    this.getAllSach();
  }
  getAllPhieuMuon(){
    this.phieumuonService.GetAllPhieuMuon(this.pageNum,this.pageSize).subscribe((res: any) => {
      this.listPhieuMuon = res.listPhieuMuons;
      this.total = res.total;
    }, (err) => {
      console.log(err);
      this.message.create('error', "Đã có lỗi xảy ra");
    });
  }
  getByPaging(indexPaging:any){
    this.pageNum = indexPaging;
    this.getAllPhieuMuon();
  }
  handleCancelModalCreate(){
    this.isVisible = false;
    this.listSachMuonTemp = [];
    this.listSachMuon = [];
  }
  handleOk(){
    if(this.createForm.valid && this.listSachMuon.length > 0){
      console.log(this.createForm.value);
      this.phieumuonService.CreatePhieuMuon(this.createForm.value).subscribe((res: any) => {
        console.log(res);
        this.message.create('success', "Thêm phiếu mượn thành công");
        this.listSachMuon=[];
        this.listSachMuonTemp=[];
        this.isVisible =false;
        this.getAllPhieuMuon();
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
  showModalCreate(){
    this.isVisible = true;
    this.createForm = this.fb.group({
      docGiaId: ["", Validators.required],
      ngayMuon: ["", Validators.required],
      sachMuons: [this.listSachMuon],
    });
  }
  getAllDocGia(){
    this.docgiaService.GetAllDocGiaNoPaging().subscribe((res: any) => {
      this.listDocGia = res.listDgs;
    }, (err) => {
      console.log(err);
    });
  }
  getAllSach(){
    this.sachService.GetAllByStateNoPaging("Chưa Mượn").subscribe((res: any) => {
      this.listSach = res.listSachs;
    }, (err) => {
      console.log(err);
    });
  }
  onChangeListSachTemp(input:any){
    var data={
      sachId: input.id
    };
    this.listSachMuonTemp.push(input);
    this.listSachMuon.push(data)
    this.createForm.value.sachMuons = this.listSachMuon;
    const index = this.listSach.findIndex((item:any) => item.id === input.id);
    this.listSach = this.listSach.filter((item:any) => item !== this.listSach[index]);
    this.isAddSach = false;
  }
  addSach(){
    this.selectSach="";
    this.isAddSach = true;
  }
  delSach(data:any){
    const index = this.listSachMuonTemp.findIndex((item:any) => item.id === data.id);
    const index2 = this.listSachMuon.findIndex((item:any) => item.sachId === data.id);
    this.listSachMuonTemp = this.listSachMuonTemp.filter((item:any) => item !== this.listSachMuonTemp[index]);
    this.listSachMuon = this.listSachMuon.filter((item:any) => item !== this.listSachMuon[index2]);
    this.listSach.push(data);
    this.createForm.value.sachMuons = this.listSachMuon;
  }
  cancel(){
    this.isAddSach = false;
  }
  getDetailPhieuMuon(input:any){
    console.log(input);
    this.phieuMuonInFo = input;
    this.isShowDetai = true;
  }
  handleCancel2(){
    this.isShowDetai = false;

  }
}
