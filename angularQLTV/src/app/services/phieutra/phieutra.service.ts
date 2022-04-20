import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PhieutraService {

constructor(private http: HttpClient) { }
  CreatePhieuTra(data:any){
    return this.http.post(environment.apiUrl + "phieutras/CreatePhieuTra", JSON.stringify(data), {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        'Accept': 'application/json',
        // 'Authorization': `Bearer ${localStorage.getItem('token')}`
      }),
    });
  }
  GetAllPhieuTra(pageNum:any,pageSize:any) {
    return this.http.get(environment.apiUrl + 'phieutras/GetAll?PageNumber='+pageNum+'&PageSize='+pageSize, {
      headers: new HttpHeaders({ "Content-Type": "application/json" }),
    });
  }
}
