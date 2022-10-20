import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MasterService } from '../Service/master.service';
import * as alertify from 'alertifyjs'
import { MatDialogRef,MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-add-customer',
  templateUrl: './add-customer.component.html',
  styleUrls: ['./add-customer.component.css']
})
export class AddCustomerComponent implements OnInit {

  constructor(private service: MasterService, public dialogref: MatDialogRef<AddCustomerComponent>,@Inject(MAT_DIALOG_DATA) public data:any) { }

  desdata: any;
  respdata: any;
  editdata: any;

  ngOnInit(): void {
    
    if(this.data.cusid!=null && this.data.cusid!=''){
      this.LoadEditData(this.data.cusid);
    }
  }

  
  

  LoadEditData(id: any) {
    this.service.GetCustomerbyid(id).subscribe(item => {
      this.editdata = item;
      this.Reactiveform.setValue({name:this.editdata.name,email:this.editdata.email,
        phone:this.editdata.phone, image:this.editdata.imageUrl })
    });
  }

  Reactiveform = new FormGroup({
    
    name: new FormControl("", Validators.required),
    email: new FormControl("", Validators.required),
    phone: new FormControl("", Validators.required),
    image: new FormControl("", Validators.required),
    
  });
  SaveCustomer() {
    if (this.Reactiveform.valid) {
      this.service.Saved(this.Reactiveform.value).subscribe(result => {
        this.respdata = result;
        if (this.respdata.result == 'pass') {
          alertify.success("saved successfully.")
          this.dialogref.close();
        }
      });

    } else {
      alertify.error("Please Enter valid data")
    }
  }

}
