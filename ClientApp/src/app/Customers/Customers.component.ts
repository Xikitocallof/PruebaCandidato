import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ICustomers } from '../Interfaces/Customers.interface';
import { Customers } from '../Modelos/Customers';

@Component({
  selector: 'app-customers',
  templateUrl: './Customers.component.html',
  styleUrls: ['./Customers.component.css']
})

export class CustomersComponent {

  listadoCustomers: ICustomers[] = [];
  public listCustomers: Array<any> = [];
  verTabla = false
  public page: number = 1;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<ICustomers[]>(baseUrl + 'customers/GetCustomers').subscribe(result => {
      this.listadoCustomers = result;
      this.listCustomers = result;
      setTimeout(() => {
        this.verTabla = true;
      }, 500);

    }, error => console.error(error));
  }
}


