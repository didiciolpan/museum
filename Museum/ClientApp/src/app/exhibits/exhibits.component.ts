import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Exhibits } from './exhibits.model';

@Component({
  selector: 'app-exhibits',
  templateUrl: './exhibits.component.html',
  styleUrls: ['./exhibits.component.css']
})
export class ExhibitsComponent {

  public exhibits: Exhibits[];

  constructor(http: HttpClient, @Inject('API_URL') apiUrl: string) {
    http.get<Exhibits[]>(apiUrl + 'exhibits').subscribe(result => {
      this.exhibits = result;
    }, error => console.error(error));
  }

  ngOnInit() {
  }

}
