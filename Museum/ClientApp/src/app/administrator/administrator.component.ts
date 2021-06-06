import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Administrator } from './administrator.model'

@Component({
  selector: 'app-administrator',
  templateUrl: './administrator.component.html',
  styleUrls: ['./administrator.component.css']
})
export class AdministratorComponent{

  public administrators: Administrator[];

  constructor(http: HttpClient, @Inject('API_URL') apiUrl: string) {
    http.get<Administrator[]>(apiUrl + 'administrators').subscribe(result => {
      this.administrators = result;
    }, error => console.error(error));
  }
}
