import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PhieuphatService {

constructor(private http: HttpClient) { }
  CreatePhieuPhat(data:any){
    return this.http.post(environment.apiUrl + "phieuphats/CreatePhieuPhat", JSON.stringify(data), {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        'Accept': 'application/json',
        // 'Authorization': `Bearer ${localStorage.getItem('token')}`
      }),
    });
  }
  GetAllPhieuPhat(pageNum:any,pageSize:any) {
    return this.http.get(environment.apiUrl + 'phieuphats/GetAll?PageNumber='+pageNum+'&PageSize='+pageSize, {
      headers: new HttpHeaders({ "Content-Type": "application/json" }),
    });
  }
}
