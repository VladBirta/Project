import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Education } from './education.models';

@Component({
  selector: 'app-education',
  templateUrl: './education.component.html'
})
export class EducationsComponent {
  public educations: Education[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Education[]>(baseUrl + 'api/educations').subscribe(result => {
      this.educations = result;
    }, error => console.error(error));
  }
  }


