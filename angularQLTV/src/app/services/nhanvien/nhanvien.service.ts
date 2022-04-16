import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class NhanvienService {

  constructor(private http: HttpClient) { }
  GetAllNhanVienByPaging(pageNum:any,pageSize:any,search:any) {
    return this.http.get(environment.apiUrl + 'nhanviens/GetAll?PageNumber='+pageNum+'&PageSize='+pageSize+'&Search='+search, {
      headers: new HttpHeaders({ "Content-Type": "application/json" }),
    });
  }
  GetAllNhanVien() {
    return this.http.get(environment.apiUrl + 'nhanviens/GetAll', {
      headers: new HttpHeaders({ "Content-Type": "application/json" }),
    });
  }
  CreateNhanVien(nhanvienData:any){
    return this.http.post(environment.apiUrl + "nhanviens/CreateNhanVien", JSON.stringify(nhanvienData), {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        'Accept': 'application/json',
        // 'Authorization': `Bearer ${localStorage.getItem('token')}`
      }),
    });
  }
  DeleteNhanvien(id : any){
    return this.http.delete(environment.apiUrl + "nhanviens/DeleteNhanVien/" +id, {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        'Accept': 'application/json',
      }),
    })
  }
  UpdateNhanVien(id:any,nhanvienData:any){
    return this.http.put(environment.apiUrl + "nhanviens/UpdateNhanVien/" +id, JSON.stringify(nhanvienData), {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        'Accept': 'application/json',
        // 'Authorization': `Bearer ${localStorage.getItem('token')}`
      }),
    });
  }
}
