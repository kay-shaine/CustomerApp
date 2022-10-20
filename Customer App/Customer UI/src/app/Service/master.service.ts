import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject,tap } from 'rxjs';
import { Customer } from '../Model/Customer';

@Injectable({
  providedIn: 'root'
})
export class MasterService {

  apiurl = 'https://localhost:7037/api/Customer';

  private _refreshrequired=new Subject<void>();
  get RequiredRefresh(){
    return this._refreshrequired;
  }

  constructor(private http: HttpClient) {

  }
  GetCustomer(): Observable<Customer> {
    return this.http.get<Customer>(this.apiurl);
  }
  GetCustomerbyid(id:any){
    return this.http.get(`https://localhost:7037/api/Customer/${id}`, id);
  }
  Remove(inputdata:any){
    return this.http.delete(`https://localhost:7037/api/Customer/DeleteCustomer?id=${inputdata}`, inputdata);
  }
  Save(inputdata:any){
    console.log(inputdata)
    return this.http.put(`https://localhost:7037/api/Customer/UpdateCustomer?id=${inputdata.id}`,inputdata).pipe(      
    tap(()=>{
          this.RequiredRefresh.next();
      })
    );
  }

  Saved(inputdata:any){
    console.log(inputdata)
    return this.http.post(`https://localhost:7037/api/Customer/CreateCustomer`,inputdata).pipe(      
    tap(()=>{
          this.RequiredRefresh.next();
      })
    );
  }
 
}
