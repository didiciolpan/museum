import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Incidents } from './incidents.module';

@Component({
  selector: 'app-incidents',
  templateUrl: './incidents.component.html',
  styleUrls: ['./incidents.component.css']
})
export class IncidentsComponent {

  public incidents: Incidents[];

  constructor(http: HttpClient, @Inject('API_URL') apiUrl: string) {
    http.get<Incidents[]>(apiUrl + 'incidents').subscribe(result => {
      this.incidents = result;
    }, error => console.error(error));
  }

 

}
