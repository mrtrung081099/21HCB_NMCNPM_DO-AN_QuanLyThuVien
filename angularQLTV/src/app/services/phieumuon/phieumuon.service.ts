import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PhieumuonService {

constructor(private http: HttpClient) { }
  CreatePhieuMuon(data:any){
    return this.http.post(environment.apiUrl + "phieumuons/CreatePhieuMuon", JSON.stringify(data), {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        'Accept': 'application/json',
        // 'Authorization': `Bearer ${localStorage.getItem('token')}`
      }),
    });
  }
  GetAllPhieuMuon(pageNum:any,pageSize:any) {
    return this.http.get(environment.apiUrl + 'phieumuons/GetAll?PageNumber='+pageNum+'&PageSize='+pageSize, {
      headers: new HttpHeaders({ "Content-Type": "application/json" }),
    });
  }
}
