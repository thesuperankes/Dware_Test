import { Client } from './../client.model';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ClientService } from '../client.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-clientdialog',
  templateUrl: './clientdialog.component.html',
  styleUrls: ['./clientdialog.component.css'],
  providers: [ClientService],
})
export class ClientdialogComponent implements OnInit {
  formGroup = {} as FormGroup;
  isEdit = false;
  isSubmit = false;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private dialogRef: MatDialogRef<ClientdialogComponent>,
    private service: ClientService,
    private snack: MatSnackBar
  ) {
    console.log(data);
    if (data != undefined) this.isEdit = true;
  }

  ngOnInit(): void {
    this.editForm();
  }

  editForm() {
    this.formGroup = new FormGroup({
      clientId: new FormControl(this.isEdit ? this.data.ClientId : ''),
      firstname: new FormControl(this.isEdit ? this.data.FirstName : '',[Validators.required]),
      lastname: new FormControl(this.isEdit ? this.data.LastName : '',[Validators.required]),
      age: new FormControl(this.isEdit ? this.data.Age : '',[Validators.required]),
      identification: new FormControl(
        this.isEdit ? this.data.Identification : '', [Validators.required]
      ),
      email: new FormControl(this.isEdit ? this.data.Email : '', [Validators.required, Validators.email]),
    });
  }

  onSubmit() {
    this.isSubmit = true;
    if(this.formGroup.valid){
      let {
        clientId: ClientId,
        firstname: FirstName,
        lastname: LastName,
        age: Age,
        identification: Identification,
        email: Email,
      } = this.formGroup.value;
  
      let obj = {
        ClientId,
        FirstName,
        LastName,
        Age,
        Identification,
        Email,
      };
  
      if (this.isEdit)
        this.onUpdateClient(obj)
      else
        this.onCreateClient(obj);
    }else{
      this.snack.open('Debe llenar todos los campos');
    }

    
  }

  onCreateClient(data: Client) {
    this.service.createClient(data).subscribe((res) => this.dialogRef.close());
  }

  onUpdateClient(data:Client){
    this.service
    .updateClient(data)
    .subscribe((res) => this.dialogRef.close());
  }
}
