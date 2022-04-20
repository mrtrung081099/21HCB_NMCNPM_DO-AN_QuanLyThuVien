import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

export class DocGiaForCreationUpdateDto {
  hoten!: string;
  loai!: string;
  ngaySinh!: string;
  diaChi!: string;
  email!: string;
  ngayLap!: string;
  tongNo!: string;
  nhanVienId!: string;
}


@Injectable({
  providedIn: 'root'
})
export class DocgiaService {

  constructor(private http: HttpClient) { }

  GetAllDocGia(pageNum: number, pageSize: number, search: string) {
    return this.http.get(environment.apiUrl + 'docgias/GetAll?PageNumber=' + pageNum + '&PageSize=' + pageSize + '&Search=' + search, {
      headers: new HttpHeaders({ "Content-Type": "application/json" }),
    });
  }
  GetAllDocGiaNoPaging() {
    return this.http.get(environment.apiUrl + 'docgias/GetAll', {
      headers: new HttpHeaders({ "Content-Type": "application/json" }),
    });
  }
  CreateDocGia(val: DocGiaForCreationUpdateDto) {
    return this.http.post(environment.apiUrl + "docgias/CreateDocGia", JSON.stringify(val), {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        'Accept': 'application/json',
      }),
    });
  }

  DeleteDocGia(id: string) {
    return this.http.delete(environment.apiUrl + "docgias/DeleteDocGia/" + id, {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        'Accept': 'application/json',
      }),
    })
  }

  UpdateDocGia(id: string, val: DocGiaForCreationUpdateDto) {
    return this.http.put(environment.apiUrl + "docgias/UpdateDocGia/" + id, JSON.stringify(val), {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        'Accept': 'application/json',
      }),
    });
  }
}
