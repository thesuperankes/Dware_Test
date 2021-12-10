import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Client } from './client.model';
import { ClientService } from './client.service';
import { ClientdialogComponent } from './clientdialog/clientdialog.component';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrls: ['./client.component.css'],
  providers: [ClientService],
})
export class ClientComponent implements OnInit {
  clients: Client[] = [];
  displayColumns: string[] = [
    'ClientId',
    'FirstName',
    'LastName',
    'Age',
    'Identification',
    'Email',
    'Tools',
  ];
  constructor(
    private service: ClientService,
    private dialog: MatDialog,
    private snack: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.getAllClients();
  }

  getAllClients() {
    this.service.getAllClient().subscribe((data: any) => {
      this.clients = data.client;
    });
  }

  open(data?: Client) {
    const dialogRef = this.dialog.open(ClientdialogComponent, {
      disableClose: true,
      data: data,
    });

    dialogRef.afterClosed().subscribe((result) => this.getAllClients());
  }

  confirmDelete(clientId: number) {
    this.snack
      .open('¿Seguro que quiere eliminar el registro?', 'confirmar')
      .onAction()
      .subscribe(() => this.delete(clientId));
  }

  delete(clientId:number){
    this.service.deleteClient(clientId).subscribe(data=>this.getAllClients());
  }
}
