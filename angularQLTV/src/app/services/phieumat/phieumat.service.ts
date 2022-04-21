import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PhieumatService {

constructor(private http: HttpClient) { }
  CreatePhieuMat(data:any){
    return this.http.post(environment.apiUrl + "phieumatsachs/CreatePhieuMatSach", JSON.stringify(data), {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        'Accept': 'application/json',
        // 'Authorization': `Bearer ${localStorage.getItem('token')}`
      }),
    });
  }
  GetAllPhieuMat(pageNum:any,pageSize:any) {
    return this.http.get(environment.apiUrl + 'phieumatsachs/GetAll?PageNumber='+pageNum+'&PageSize='+pageSize, {
      headers: new HttpHeaders({ "Content-Type": "application/json" }),
    });
  }
}
