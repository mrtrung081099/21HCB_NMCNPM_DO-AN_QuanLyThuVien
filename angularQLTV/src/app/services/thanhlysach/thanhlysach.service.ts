import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ThanhlysachService {

constructor(private http: HttpClient) { }
  CreateThanhLySach(data:any){
    return this.http.post(environment.apiUrl + "thanhlysachs/CreateThanhLySach", JSON.stringify(data), {
      headers: new HttpHeaders({
        "Content-Type": "application/json",
        'Accept': 'application/json',
        // 'Authorization': `Bearer ${localStorage.getItem('token')}`
      }),
    });
  }
  GetAllThanhLySach(pageNum:any,pageSize:any) {
    return this.http.get(environment.apiUrl + 'thanhlysachs/GetAll?PageNumber='+pageNum+'&PageSize='+pageSize, {
      headers: new HttpHeaders({ "Content-Type": "application/json" }),
    });
  }
}
