import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IItems } from '../Interfaces/Items.interface';

@Component({
  selector: 'app-web-tree-view',
  templateUrl: './WebTreeView.component.html',
  styleUrls: ['./WebTreeView.component.css']
})

export class WebTreeViewComponent {

  listadoItems: IItems[] = [];

  //constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  //  const url = baseUrl + "webtreeview/GetListado";
  //  /*return this.http.get<any>(url);*/
  //  http.get<WeatherForecast[]>(url).subscribe(result => {
  //    this.forecasts = result;
  //  }, error => console.error(error));
  //}
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<IItems[]>(baseUrl + 'webtreeview/GetListado').subscribe(result => {
      this.listadoItems = result;
    }, error => console.error(error));
  }
}


