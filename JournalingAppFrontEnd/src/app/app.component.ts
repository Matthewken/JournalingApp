import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public journals?: Journal[];

  constructor(http: HttpClient) {
    //http.get<Journal[]>('/api/journals/').subscribe(result => {
    //  this.journals = result;
    //}, error => console.error(error));
    http.get<Journal[]>('/api/journals').subscribe(result => {
      console.log(result);
      this.journals = result;
    }, error => console.error(error));
  }

  title = 'JournalingAppFrontEnd';
}

interface Journal {
  id: number;
  name: string;
  entries: Array<Entry>;
}

interface Entry {
  id: number;
  text: string;
}

