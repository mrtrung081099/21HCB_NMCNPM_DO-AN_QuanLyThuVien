import { Component, OnInit } from '@angular/core';
import { DocgiaService } from '../services/docgia/docgia.service';
import { SachService } from '../services/sach/sach.service';

@Component({
  selector: 'app-baocao',
  templateUrl: './baocao.component.html',
  styleUrls: ['./baocao.component.scss']
})
export class BaocaoComponent implements OnInit {
  listThongKeSachMuon:any[]=[];
  listThongKeSachTraTre:any[]=[];
  listThongKeDocGiaNoTien:any[]=[];
  total=0;
  totalTienNo=0;

  thang:Date = new Date;
  ngay:Date = new Date;
  ngay2:Date = new Date;

  constructor(
    private docgiaService: DocgiaService,
    private sachService: SachService
  ) { }

  ngOnInit() {
    this.getThongKeMuonSach();
    this.getThongKeSachTraTreTheoNgay();
    this.getThongKeDocGiaNoTienPhatTheoNgay();
  }
  getThongKeMuonSach(){
    this.sachService.GetThongKeSachMuonTheoThang(this.thang).subscribe((res: any) => {
      this.listThongKeSachMuon = res;
      this.total = 0;
      this.listThongKeSachMuon.forEach(element => {
        this.total += element?.soLuotMuon;
      });
    }, (err) => {
      console.log(err);
    });
  }
  getThongKeSachTraTreTheoNgay(){
    this.sachService.GetThongKeSachTraTreTheoNgay(this.ngay).subscribe((res: any) => {
      this.listThongKeSachTraTre = res;
      console.log(res);

    }, (err) => {
      console.log(err);
    });
  }
  getThongKeDocGiaNoTienPhatTheoNgay(){
    this.docgiaService.GetDocGiaNoTienTheoNgay(this.ngay2).subscribe((res: any) => {
      this.listThongKeDocGiaNoTien = res;
      console.log(res);
      this.totalTienNo = 0;
      this.listThongKeDocGiaNoTien.forEach(element => {
        this.totalTienNo += element?.tienNo;
      });
    }, (err) => {
      console.log(err);
    });
  }
  getMonth(input:Date){
    this.thang = input;
    this.getThongKeMuonSach();
  }
  getDay(input:Date){
    this.ngay = input;
    this.getThongKeSachTraTreTheoNgay();
  }
  getDay2(input:Date){
    this.ngay2 = input;
    this.getThongKeDocGiaNoTienPhatTheoNgay();
  }
}
