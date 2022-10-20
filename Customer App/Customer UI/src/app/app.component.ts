import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ModalpopupComponent } from './modalpopup/modalpopup.component';
import { Customer } from './Model/Customer';
import { MasterService } from './Service/master.service';
import * as alertify from 'alertifyjs'
import { AddCustomerComponent } from './add-customer/add-customer.component';



@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title = 'Customer';
  displayedColumns: string[] = ['id', 'name', 'phone', 'email', 'action'];
  dataSource: any;
  cusdata: any;

  @ViewChild(MatPaginator) paginator !: MatPaginator;
  @ViewChild(MatSort) sort !: MatSort;

  constructor(private service: MasterService, private dialog: MatDialog) {

  }
  ngOnInit(): void {
    this.GetAll();
    this.service.RequiredRefresh.subscribe(r => {
      this.GetAll();
    });
  }

  GetAll() {
    this.service.GetCustomer().subscribe(result => {
      this.cusdata = result;
      this.dataSource = new MatTableDataSource<Customer>(this.cusdata)
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }
  Filterchange(event: Event) {
    const filvalue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filvalue;
  }
  getrow(row: any) {
    //console.log(row);
  }
  FunctionEdit(id: any) {
    this.OpenDialog('1000ms','600ms',id)
  }
  FunctionDelete(id: any) {
    alertify.confirm("Remove Customer","Do you want to remove?",()=>{
      this.service.Remove(id).subscribe(result => {
        this.GetAll();
        alertify.success("Removed successfully.")
      });

    },function(){

    })
    
  }

  OpenDialog(enteranimation: any, exitanimation: any,id:any) {

    this.dialog.open(ModalpopupComponent, {
      enterAnimationDuration: enteranimation,
      exitAnimationDuration: exitanimation,
      width: "50%",
      data:{
        cusid:id
      }
    })
  }

  OpenDialogg(enteranimation: any, exitanimation: any,id:any) {

    this.dialog.open(AddCustomerComponent, {
      enterAnimationDuration: enteranimation,
      exitAnimationDuration: exitanimation,
      width: "50%",
      data:{
        cusid:id
      }
    })
  }

}
